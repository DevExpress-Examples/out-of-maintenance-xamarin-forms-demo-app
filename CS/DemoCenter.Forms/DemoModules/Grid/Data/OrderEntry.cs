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
using DemoCenter.Forms.ViewModels;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public class OrderEntry : NotificationObject {
        Commodity commodity;
        double amount;
        double price;
        double total;

        public Commodity Commodity {
            get { return commodity; }
            set {
                commodity = value;
                OnPropertyChanged("Commodity");
            }
        }
        public double Amount {
            get { return amount; }
            set {
                amount = value;
                OnPropertyChanged("Amount");
                UpdateTotal(raiseChanged: true);
            }
        }
        public double Price {
            get { return amount; }
            set {
                amount = value;
                OnPropertyChanged("Price");
                UpdateTotal(raiseChanged: true);
            }
        }
        public double Total {
            get { return total; }
        }

        public OrderEntry(Commodity commodity, double amount, double price) {
            this.commodity = commodity;
            this.amount = amount;
            this.price = price;
            UpdateTotal(raiseChanged: false);
        }

        void UpdateTotal(bool raiseChanged) {
            total = price * amount;
            if (raiseChanged)
                OnPropertyChanged("Total");
        }
    }
}
