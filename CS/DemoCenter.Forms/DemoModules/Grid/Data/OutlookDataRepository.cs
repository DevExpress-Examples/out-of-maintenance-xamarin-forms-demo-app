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
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public class OutlookDataRepository : NotificationObject {
        public ObservableCollection<OutlookData> OutlookData { get; private set; }
        int loadRowsCount = 30;
        int lastId = 0;

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

        public OutlookDataRepository() {
            LoadData();
            this.LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        public OutlookDataRepository(int rowsCount) {
            loadRowsCount = rowsCount;
            LoadData();
            this.LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        void ExecuteLoadMoreCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                Device.BeginInvokeOnMainThread(() => {
                    LoadData();
                    IsRefreshing = false;
                });
            });
        }

        void LoadData() {
            if (OutlookData == null)
                OutlookData = new ObservableCollection<OutlookData>();

            for (int i = 0; i < loadRowsCount; i++) {
                OutlookData.Add(OutlookDataGenerator.CreateOutlookData(lastId));
                lastId++;
            }
        }
    }

    static class OutlookDataGenerator {
        static readonly int[] UserIds = new int[] {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9
        };
        static string[] Subjects = new string[] {
            "Developer Express MasterView. Integrating the control into an Accounting System.",
            "Web Edition: Data Entry Page. There is an issue with date validation.",
            "Payables Due Calculator is ready for testing.",
            "Web Edition: Search Page is ready for testing.",
            "Main Menu: Duplicate Items. Somebody has to review all menu items in the system.",
            "Receivables Calculator. Where can I find the complete specs?",
            "Ledger: Inconsistency. Please fix it.",
            "Receivables Printing module is ready for testing.",
            "Screen Redraw. Somebody has to look at it.",
            "Email System. What library are we going to use?",
            "Cannot add new vendor. This module doesn't work!",
            "History. Will we track sales history in our system?",
            "Main Menu: Add a File menu. File menu item is missing.",
            "Currency Mask. The current currency mask in completely unusable.",
            "Drag & Drop operations are not available in the scheduler module.",
            "Data Import. What database types will we support?",
            "Reports. The list of incomplete reports.",
            "Data Archiving. We still don't have this features in our application.",
            "Email Attachments. Is it possible to add multiple attachments? I haven't found a way to do this.",
            "Check Register. We are using different paths for different modules.",
            "Data Export. Our customers asked us for export to Microsoft Excel"
        };
        static Random random = new Random();
        static GridOrdersRepository gridOrdersRepository = new GridOrdersRepository();

        public static OutlookData CreateOutlookData(int id) {
            OutlookData data = new OutlookData();
            data.Id = id;
            data.From = GetCustomer(UserIds[random.Next(UserIds.Length - 1)]);
            data.Sent = DateTime.Today.AddDays(-random.Next(50));
            data.Time = TimeSpan.FromMinutes(random.Next(24 * 60));
            data.HasAttachment = random.Next(2) == 0;
            data.Size = random.Next(3000);
            data.Priority = (Priority)random.Next(5);
            data.HoursActive = random.Next(1000);
            data.Subject = Subjects[random.Next(Subjects.Length - 1)];
            return data;
        }

        static Customer GetCustomer(int id) {
            return gridOrdersRepository.Customers.First(c => c.Id == id).Clone();
        }

        public static IList<OutlookData> CreateOutlookDataSource(int count) {
            List<OutlookData> data = new List<OutlookData>(count);
            for (int i = 0; i < count; i++) {
                data.Add(CreateOutlookData(i));
            }
            return data;
        }
    }
}
