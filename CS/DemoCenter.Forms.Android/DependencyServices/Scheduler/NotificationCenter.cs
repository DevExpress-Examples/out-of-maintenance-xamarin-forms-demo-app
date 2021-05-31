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
using System.Collections.Generic;
using Android.App;
using Android.Content;
using DemoCenter.Forms.Droid;
using DevExpress.XamarinForms.Scheduler;
using Java.Sql;
using Xamarin.Forms;
using AAplication = Android.App.Application;

[assembly: Dependency(typeof(NotificationCenter))]
namespace DemoCenter.Forms.Droid {
    public class NotificationCenter : Java.Lang.Object, INotificationCenter {
        static Date ToNativeDate(DateTime dateTime) {
            long dateTimeUtcAsMilliseconds = (long)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }

        void INotificationCenter.UpdateNotifications(IList<TriggeredReminder> reminders, int maxCount) {
            AlarmManager alarm = (AlarmManager)AAplication.Context.GetSystemService(Context.AlarmService);
            for (int i = 0; i < maxCount; i++) {
                if (i < reminders.Count) {
                    TriggeredReminder reminder = reminders[i];
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(AAplication.Context, i, CreateIntent(reminder), PendingIntentFlags.UpdateCurrent);
                    alarm.Cancel(pendingIntent);
                    alarm.SetExact((int)AlarmType.RtcWakeup, ToNativeDate(reminder.AlertTime).Time, pendingIntent);
                } else {
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(AAplication.Context, i, CreateIntent(), PendingIntentFlags.UpdateCurrent);
                    alarm.Cancel(pendingIntent);
                }
            }
        }

        Intent CreateIntent() {
            return new Intent(AAplication.Context, typeof(NotificationAlarmHandler)).SetAction(NotificationAlarmHandler.NotificationHandler);
        }
        Intent CreateIntent(string id, int recurrenceIndex, string subject, string interval) {
            return CreateIntent()
                .PutExtra(NotificationAlarmHandler.ReminderId, id)
                .PutExtra(NotificationAlarmHandler.RecurrenceIndex, recurrenceIndex)
                .PutExtra(NotificationAlarmHandler.Subject, subject)
                .PutExtra(NotificationAlarmHandler.Interval, interval);
        }
        Intent CreateIntent(TriggeredReminder reminder) {
            AppointmentItem appointment = reminder.Appointment;
            return CreateIntent(reminder.Id.ToString(), appointment.RecurrenceIndex, appointment.Subject, appointment.Interval.ToString("{0:g} - {1:g}", null));
        }
    }
}
