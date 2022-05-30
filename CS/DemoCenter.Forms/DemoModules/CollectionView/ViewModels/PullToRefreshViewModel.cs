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
﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Forms.DemoModules.Drawer.Data;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class PullToRefreshViewModel : NotificationObject {
        readonly MailMessagesRepository repository;

        public PullToRefreshViewModel(MailMessagesRepository repository) {
            this.repository = repository;
            ItemSource = GetSortedMessages(this.repository);
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }

        IList<MailData> itemSource;
        public IList<MailData> ItemSource {
            get => this.itemSource;
            set => SetProperty(ref this.itemSource, value);
        }

        bool isRefreshing = false;
        public bool IsRefreshing {
            get => this.isRefreshing;
            set => SetProperty(ref this.isRefreshing, value);
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get => this.pullToRefreshCommand;
            set => SetProperty(ref this.pullToRefreshCommand, value);
        }

        void ExecutePullToRefreshCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                this.repository.GenerateMessages();
                ItemSource = GetSortedMessages(this.repository);
                IsRefreshing = false;
            });
        }

        IList<MailData> GetSortedMessages(MailMessagesRepository repository) {
            return repository.MailMessages.OrderByDescending(x => x.SentDate).ToList();
        }
    }
}
