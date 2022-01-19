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
﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.Editors;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class ContactsDropdownViewModel: NotificationObject {
        readonly Random random;

        ObservableCollection<CallInfo> recent;
        public ObservableCollection<CallInfo> Recent {
            get => this.recent;
            private set => SetProperty(ref this.recent, value);
        }

        bool isOpenPopup;
        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set => SetProperty(ref this.isOpenPopup, value);
        }

        object placementTarget;
        public object PlacementTarget {
            get => this.placementTarget;
            set => SetProperty(ref this.placementTarget, value);
        }

        public ContactsDropdownViewModel() {
            this.random = new Random();
            GridOrdersRepository repository = new GridOrdersRepository();
            IList<PhoneContact> customersList = repository.Customers.ToList().ConvertAll((customer) => new PhoneContact(customer));

            GenerateCallList(customersList);
        }

        void GenerateCallList(IList<PhoneContact> contacts) {
            int recordsCount = 21;
            Recent = new ObservableCollection<CallInfo>();
            for (int i = 0; i < recordsCount; i++) {
                int randomData = i / 3;
                int randomTime = this.random.Next(40, 620);
                Recent.Add(new CallInfo() {
                    Date = DateTime.UtcNow.AddDays(-randomData).AddMinutes(randomTime),
                    CallType = (CallType)((randomTime - randomData) % 3),
                    Contact = contacts[(randomData + randomTime) % contacts.Count]
                });
            }
        }
    }
}
