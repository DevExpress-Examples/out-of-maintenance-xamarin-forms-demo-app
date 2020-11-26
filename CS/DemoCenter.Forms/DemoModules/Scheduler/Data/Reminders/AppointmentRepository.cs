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
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class AppointmentRepository {
        const string APPOINTMENT_TABLE_NAME = "appointments.db";
        static AppointmentRepository appointmentsDB;
        static object collisionLock = new object();

        readonly SQLiteConnection database;

        public static AppointmentRepository Instance {
            get => appointmentsDB = appointmentsDB ?? new AppointmentRepository(APPOINTMENT_TABLE_NAME);
        }

        AppointmentRepository(string filename) {
            database = new SQLiteConnection(DependencyService.Get<IStoragePathProvider>().GetPath(filename));
            database.CreateTable<ReminderAppointment>();
        }

        public IEnumerable<ReminderAppointment> GetItems() {
            lock (collisionLock) 
                return (from i in database.Table<ReminderAppointment>() select i).ToList();
        }
        public ReminderAppointment GetItem(int id) {
            lock (collisionLock) 
                return database.Get<ReminderAppointment>(id);              
        }
        public int DeleteItem(int id) {
            lock (collisionLock)
                return database.Delete<ReminderAppointment>(id);
        }
        public int SaveItem(ReminderAppointment item) {
            lock (collisionLock) {
                if (item.Id == 0)
                    return database.Insert(item);
                database.Update(item);
                return item.Id;
            }
        }
    }
}
