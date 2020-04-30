/*
               Copyright (c) 2015-2020 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2020 Developer Express Inc.              }
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
            get { return isRefreshing; }
            set {
                if (isRefreshing != value) {
                    isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        bool isUpdateLocked = false;
        public bool IsUpdateLocked {
            get { return isUpdateLocked; }
            set {
                if (isUpdateLocked != value) {
                    isUpdateLocked = value;
                    OnPropertyChanged("IsUpdateLocked");
                }
            }
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get { return pullToRefreshCommand; }
            set {
                if (pullToRefreshCommand != value) {
                    pullToRefreshCommand = value;
                    OnPropertyChanged("PullToRefreshCommand");
                }
            }
        }

        ICommand loadMoreCommand = null;
        public ICommand LoadMoreCommand {
            get { return loadMoreCommand; }
            set {
                if (loadMoreCommand != value) {
                    loadMoreCommand = value;
                    OnPropertyChanged("LoadMoreCommand");
                }
            }
        }

        ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get { return orders; }
            set {
                if (orders != value) {
                    orders = value;
                    OnPropertyChanged("Orders");
                }
            }
        }
        public ObservableCollection<Customer> Customers { get { return repository.Customers; } }
        public BindingList<Quote> Quotes { get { return market.Quotes; } }
        public Command SwipeButtonCommand { get; set; }
        public Command RefreshCommand { get { return refreshCommand; } }

        public MainGridViewModel(OrdersRepository repository) {
            this.repository = repository;
            Orders = repository.Orders;
            this.refreshCommand = new Command(ExecuteRefreshCommand);
            this.market = new MarketSimulator();
            this.PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
            this.LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        void ExecuteRefreshCommand() {
            repository.RefreshOrders();
            Orders = repository.Orders;
        }
        
        public void OnOrderRemove(int row) {
            Console.WriteLine("before" + this.Orders.Count);
            this.Orders.RemoveAt(row);
            Console.WriteLine("after" + this.Orders.Count);
        }

        bool marketSimulationOn;
        public void StartMarketSimulation() {
            if (marketSimulationOn)
                return;

            marketSimulationOn = true;
            Device.StartTimer(TimeSpan.FromSeconds(0.5), SimulateMarketWorker);
        }

        public void StopMarketSimulation() {
            this.marketSimulationOn = false;
        }

        public void ForceSimulateMarketWorker() {
            SimulateNextStep();
        }

        bool SimulateMarketWorker() {
            if (!marketSimulationOn)
                return false;

            SimulateNextStep();
            return true;
        }

        void SimulateNextStep() {
            IsUpdateLocked = true;
            Device.BeginInvokeOnMainThread(() => {
                market.SimulateNextStep();
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

        void ExecuteLoadMoreCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                Device.BeginInvokeOnMainThread(() => {
                    repository.LoadMoreOrders();
                    IsRefreshing = false;
                });
            });
        }
    }

    public class LoadMoreDataCommand : ICommand {
        readonly Action execute;

        int numOfLoadMore;
        public event EventHandler CanExecuteChanged;
        bool canExecute = true;

        public LoadMoreDataCommand(Action execute) {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) {
            return canExecute;
        }

        public void Execute(object parameter) {
            numOfLoadMore++;
            if (numOfLoadMore < 3) {
                ChangeCanExecute(true);
                this.execute();
            } else {
                ChangeCanExecute(false);
                TryDownloadAgain();
            }
        }

        async void TryDownloadAgain() {
            await Task.Delay(5000);
            numOfLoadMore = 0;
            ChangeCanExecute(true);
        }
        void ChangeCanExecute(bool canExecute) {
            this.canExecute = canExecute;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }
    }
}
