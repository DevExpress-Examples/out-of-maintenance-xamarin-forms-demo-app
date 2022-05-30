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
using DemoCenter.Forms.ViewModels;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public enum OrderPriority {
        High,
        Medium,
        Low
    }
    public enum Severity {
        Severe,
        Moderate,
        Minor
    }
    public class OrderSeverity {
        public Severity Severity { get; set; }
        public string DisplayText { get; set; }
    }
    public class Order : NotificationObject {
        readonly ObservableCollection<OrderEntry> entries;
        readonly ReadOnlyObservableCollection<OrderEntry> readOnlyEntries;
        DateTime date;
        int id;
        Customer customer;
        bool shipped;
        decimal total = Decimal.MinValue;
        string note;
        OrderPriority priority;

        public int Id {
            get { return id; }
            set {
                if (id != value) {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public Customer Customer {
            get { return customer; }
            set {
                if (customer != value) {
                    customer = value;
                    OnPropertyChanged("Customer");
                }
            }
        }
        public DateTime Date {
            get { return date; }
            set {
                if (date != value) {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public bool Shipped {
            get { return shipped; }
            set {
                if (shipped != value) {
                    shipped = value;
                    OnPropertyChanged("Shipped");
                }
            }
        }
        public double Discount { get; set; }
        public decimal Total {
            get {
                if (total == decimal.MinValue)
                    total = CalculateTotal();
                return total;
            }
        }
        public string Note {
            get { return note; }
            set {
                if (note != value) {
                    note = value;
                    OnPropertyChanged("Note");
                }
            }
        }
        public OrderPriority Priority {
            get { return priority; }
            set {
                if (priority != value) {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }
        public ReadOnlyObservableCollection<OrderEntry> Entries {
            get { return readOnlyEntries; }
        }

        public Order(Customer customer, int id, DateTime date, bool isDone) {
            this.entries = new ObservableCollection<OrderEntry>();
            this.readOnlyEntries = new ReadOnlyObservableCollection<OrderEntry>(this.entries);
            this.customer = customer;
            this.id = id;
            this.date = date;
            this.shipped = isDone;
            this.note = "test note";
        }

        public Order() {
            this.entries = new ObservableCollection<OrderEntry>();
            this.readOnlyEntries = new ReadOnlyObservableCollection<OrderEntry>(this.entries);
            this.customer = new Customer("");
            this.id = 0;
            this.date = new DateTime();
            this.shipped = false;
            this.note = "";
        }

        public void AddEntry(OrderEntry entry) {
            total = Decimal.MinValue;
            entries.Add(entry);
        }
        public void RemoveEntry(OrderEntry entry) {
            total = Decimal.MinValue;
            entries.Remove(entry);
        }

        decimal CalculateTotal() {
            decimal result = 0;
            int count = entries.Count;
            for (int i = 0; i < count; i++)
                result += (decimal)entries[i].Total;
            return result;
        }
    }
}
