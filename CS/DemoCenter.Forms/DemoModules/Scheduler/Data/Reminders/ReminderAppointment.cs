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
using System;
using SQLite;

namespace DemoCenter.Forms.ViewModels {
    [Table("Appointments")]
    public class ReminderAppointment : DataItem {
        int appointmentType;
        bool allDay;
        DateTime start;
        DateTime end;
        string subject;
        string description;
        int status;
        int label;
        string location;
        string reminderInfo;
        string recurrenceInfo;
        string timeZoneId;

        [PrimaryKey, AutoIncrement, Column("_id")]
        public override int Id { get => base.Id; set => base.Id = value; }

        public int AppointmentType {
            get => appointmentType;
            set => SetProperty(ref appointmentType, value);
        }
        public bool AllDay {
            get => allDay;
            set => SetProperty(ref allDay, value);
        }
        public DateTime Start {
            get => start;
            set => SetProperty(ref start, value);
        }
        public DateTime End {
            get => end;
            set => SetProperty(ref end, value);
        }

        public string Subject {
            get => subject;
            set => SetProperty(ref subject, value);
        }
        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }
        public int Status {
            get => status;
            set => SetProperty(ref status, value);
        }
        public int Label {
            get => label;
            set => SetProperty(ref label, value);
        }
        public string Location {
            get => location;
            set => SetProperty(ref location, value);
        }
        public string ReminderInfo {
            get => reminderInfo;
            set => SetProperty(ref reminderInfo, value);
        }
        public string RecurrenceInfo {
            get => recurrenceInfo;
            set => SetProperty(ref recurrenceInfo, value);
        }
        public string TimeZoneId {
            get => timeZoneId;
            set => SetProperty(ref timeZoneId, value);
        }
    }
}
