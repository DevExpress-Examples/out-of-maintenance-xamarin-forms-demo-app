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
using SQLite;
using System;
using DevExpress.XamarinForms.Scheduler;
using DemoCenter.Forms.ViewModels;

namespace DemoCenter.Forms.Droid {
    [Table("Notifications")]
    public class NotificationInfo : DataItem {
        Guid reminderId;
        DateTime alertTime;
        string subject;
        string timeInterval;
        int recurrenceIndex;

        public NotificationInfo() {
        }
        public NotificationInfo(TriggeredReminder reminder) {
            reminderId = (Guid)reminder.Reminder.Id;
            alertTime = reminder.AlertTime;
            subject = reminder.Appointment.Subject;
            timeInterval = reminder.Appointment.Interval.ToString();
            recurrenceIndex = reminder.Appointment.RecurrenceIndex;
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public override int Id { get => base.Id; set => base.Id = value; }

        public Guid ReminderId {
            get => reminderId;
            set => SetProperty(ref reminderId, value);
        }
        public DateTime AlertTime {
            get => alertTime;
            set => SetProperty(ref alertTime, value);
        }
        public string Subject {
            get => subject;
            set => SetProperty(ref subject, value);
        }
        public string TimeInterval {
            get => timeInterval;
            set => SetProperty(ref timeInterval, value);
        }
        public int RecurrenceIndex {
            get => recurrenceIndex;
            set => SetProperty(ref recurrenceIndex, value);
        }        
    }
}