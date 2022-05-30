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
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.DataGrid;
using Xamarin.Essentials;

namespace DemoCenter.Forms.Views {
    public partial class SwipeButtonsView : BaseGridContentPage { 
        public SwipeButtonsView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return new OutlookDataRepository();
        }
        
        void OnShowCustomerInfo(object sender, SwipeItemTapEventArgs e) {
            Customer customer = (e.Item as OutlookData).From;
            CustomerOrdersView customerOrdersView = new CustomerOrdersView(customer) {
                Title = customer.Name
            };
            Navigation.PushAsync(customerOrdersView);
        }
        
        void OnDelete(object sender, SwipeItemTapEventArgs e) {
            this.grid.DeleteRow(e.RowHandle);
        }

        void OnReply(object sender, SwipeItemTapEventArgs e) {
            try {
                Launcher.OpenAsync(new Uri("mailto:" + (e.Item as OutlookData).From.Email));
            } catch {
            }
        }
    }
}
