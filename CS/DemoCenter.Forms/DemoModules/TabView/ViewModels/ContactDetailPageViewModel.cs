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
using System.Collections.Generic;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.TabView.ViewModels {
    public class ContactDetailPageViewModel : BaseViewModel {
        readonly Random rand;
        readonly PhoneContact contact;

        IList<CallInfo> calls;
        public IList<CallInfo> CallsHistory {
            get => this.calls;
            set {
                this.calls = value;
                OnPropertyChanged(nameof(CallsHistory));
            }
        }

        public string Name {
            get => this.contact.Name;
        }

        public ImageSource Photo {
            get => this.contact.Photo;
        }
        
        public bool HasPhoto {
            get => this.contact.HasPhoto;
        }

        public string Initials {
            get => this.contact.Initials;
        }
        
        public Color CategoryColor {
            get => this.contact.CategoryColor;
        }

        public string Email {
            get => this.contact.Email;
        }

        public string Phone {
            get => this.contact.Phone;
        }

        public ContactDetailPageViewModel(PhoneContact contact) {
            this.rand = new Random();
            this.contact = contact;
            GenerateCallsHistory();
        }

        void GenerateCallsHistory() {
            int callsCount = this.rand.Next(2, 7);
            List<CallInfo> callsHistory = new List<CallInfo>();
            for (int i = 0; i < callsCount; i++) {
                int randParameter = this.rand.Next(1, 35);
                callsHistory.Add(new CallInfo() {
                    CallType = (CallType)((i + randParameter) % 3),
                    Date = DateTime.UtcNow.AddHours( -1 * (i + randParameter)).AddMinutes(randParameter)
                });
            }
            CallsHistory = callsHistory;
        }
    }
}
