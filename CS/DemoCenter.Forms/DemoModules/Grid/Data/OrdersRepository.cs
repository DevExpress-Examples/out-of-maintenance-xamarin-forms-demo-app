/*
               Copyright (c) 2015-2021 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2021 Developer Express Inc.              }
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
using System.Collections.ObjectModel;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public abstract class OrdersRepository {
        readonly ObservableCollection<Customer> customers;

        public ObservableCollection<Order> Orders { get; private set; }
        public ObservableCollection<Customer> Customers { get { return this.customers; } }

        public OrdersRepository() {
            Orders = new ObservableCollection<Order>();
            this.customers = new ObservableCollection<Customer>();
        }

        protected abstract Order GenerateOrder(int number);
        protected abstract int GetOrderCount();

        internal void LoadMoreOrders() {
            for (int i = 0; i < GetOrderCount() / 2; i++)
                Orders.Add(GenerateOrder(i));
        }
        internal void RefreshOrders() {
            ObservableCollection<Order> newOrders = new ObservableCollection<Order>();
            for (int i = 0; i < GetOrderCount(); i++)
                newOrders.Add(GenerateOrder(i));

            Orders = newOrders;
        }
    }
}
