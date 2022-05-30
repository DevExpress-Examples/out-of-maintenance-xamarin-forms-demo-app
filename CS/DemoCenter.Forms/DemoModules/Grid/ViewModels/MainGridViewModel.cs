/*
               Copyright (c) 2015-2022 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2022 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING         }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Grid.ViewModels {
    public class MainGridViewModel : NotificationObject {
        readonly Command refreshCommand;
        readonly OrdersRepository repository;
        readonly MarketSimulator market;

        bool isRefreshing = false;
        public bool IsRefreshing {
            get { return this.isRefreshing; }
            set {
                if (this.isRefreshing != value) {
                    this.isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        bool isUpdateLocked = false;
        public bool IsUpdateLocked {
            get { return this.isUpdateLocked; }
            set {
                if (this.isUpdateLocked != value) {
                    this.isUpdateLocked = value;
                    OnPropertyChanged("IsUpdateLocked");
                }
            }
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get { return this.pullToRefreshCommand; }
            set {
                if (this.pullToRefreshCommand != value) {
                    this.pullToRefreshCommand = value;
                    OnPropertyChanged("PullToRefreshCommand");
                }
            }
        }

        ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get { return this.orders; }
            set {
                if (this.orders != value) {
                    this.orders = value;
                    OnPropertyChanged("Orders");
                }
            }
        }
        public ObservableCollection<Customer> Customers { get { return this.repository.Customers; } }
        public BindingList<Quote> Quotes { get { return this.market.Quotes; } }
        public Command SwipeButtonCommand { get; set; }
        public Command RefreshCommand { get { return this.refreshCommand; } }

        public MainGridViewModel(OrdersRepository repository) {
            this.repository = repository;
            Orders = repository.Orders;
            this.refreshCommand = new Command(ExecuteRefreshCommand);
            this.market = new MarketSimulator();
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }

        void ExecuteRefreshCommand() {
            this.repository.RefreshOrders();
            Orders = this.repository.Orders;
        }
        
        public void OnOrderRemove(int row) {
            Console.WriteLine("before" + Orders.Count);
            Orders.RemoveAt(row);
            Console.WriteLine("after" + Orders.Count);
        }

        bool marketSimulationOn;
        public void StartMarketSimulation() {
            if (this.marketSimulationOn)
                return;

            this.marketSimulationOn = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.5), SimulateMarketWorker);
        }

        public void StopMarketSimulation() {
            this.marketSimulationOn = false;
        }

        public void ForceSimulateMarketWorker() {
            SimulateNextStep();
        }

        bool SimulateMarketWorker() {
            if (!this.marketSimulationOn)
                return false;

            SimulateNextStep();
            return true;
        }

        void SimulateNextStep() {
            IsUpdateLocked = true;
            Device.BeginInvokeOnMainThread(() => {
                this.market.SimulateNextStep();
                IsUpdateLocked = false;
            });
        }

        void ExecutePullToRefreshCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                SimulateNextStep();
                IsRefreshing = false;
            });
        }
    }
}
