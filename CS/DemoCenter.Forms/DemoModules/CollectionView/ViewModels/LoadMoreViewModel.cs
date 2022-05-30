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
﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Forms.DemoModules.Drawer.Data;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class LoadMoreViewModel : NotificationObject {
        readonly MailMessagesRepository repository;
        DateTime currentDate = DateTime.Now;
        readonly Random random;

        public LoadMoreViewModel(MailMessagesRepository repository) {
            this.random = new Random((int)DateTime.Now.Ticks);
            this.repository = repository;
            ItemSource = new List<MailData>();
            LoadData();
            LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        public IList<MailData> ItemSource { get; }

        bool isRefreshing = false;
        public bool IsRefreshing {
            get => this.isRefreshing;
            set => SetProperty(ref this.isRefreshing, value);
        }

        ICommand loadMoreCommand = null;
        public ICommand LoadMoreCommand {
            get => this.loadMoreCommand;
            set => SetProperty(ref this.loadMoreCommand, value);
        }

        void ExecuteLoadMoreCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                LoadData();
                IsRefreshing = false;
            });
        }

        void LoadData() {
            foreach (MailData mail in this.repository.MailMessages) {
                this.currentDate = this.currentDate.AddMinutes(-1 * this.random.Next(5, 240));

                ItemSource.Add(new MailData() {
                    Body = mail.Body,
                    Folders = mail.Folders,
                    SenderEmail = mail.SenderEmail,
                    SenderName = mail.SenderName,
                    SentDate = this.currentDate,
                    Subject = mail.Subject,
                });
            }
        }
    }
}
