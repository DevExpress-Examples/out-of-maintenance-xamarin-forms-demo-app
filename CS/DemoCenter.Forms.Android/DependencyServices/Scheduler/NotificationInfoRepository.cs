/*                                                         
               Copyright (c) 2019 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile UI for Xamarin.Forms               }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2019 Developer Express Inc.                   }   
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
using DevExpress.XamarinForms.Scheduler;
using System.Collections.Generic;
using System.Linq;

namespace DemoCenter.Forms.Droid {
    public class NotificationInfoRepository : ItemRepository<NotificationInfo> {
        const string NOTIFICATION_TABLE_NAME = "notifications.db";
        static NotificationInfoRepository instance;

        public static NotificationInfoRepository Instance {
            get => instance = instance ?? new NotificationInfoRepository(NOTIFICATION_TABLE_NAME);
        }

        NotificationInfoRepository(string filename) : base(StoragePathProvider.GetFilePath(filename)) {
        }

        public IEnumerable<NotificationInfo> GetItems() {
            return (from i in DataBase.Table<NotificationInfo>() select i).ToList();
        }
        public NotificationInfo GetItem(int id) {
            return DataBase.Get<NotificationInfo>(id);
        }

        public void DeleteAll() {
            DataBase.DeleteAll<NotificationInfo>();
        }

        public int AddNewReminder(TriggeredReminder reminder) {
            return DataBase.Insert(new NotificationInfo(reminder));
        }
    }
}