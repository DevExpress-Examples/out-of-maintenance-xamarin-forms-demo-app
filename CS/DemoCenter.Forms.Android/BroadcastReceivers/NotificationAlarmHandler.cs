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
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;

namespace DemoCenter.Forms.Droid {
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { NotificationHandler })]
    public class NotificationAlarmHandler : BroadcastReceiver {
        public const string NotificationHandler = "NotificationAlarmHandler";
        public const string ReminderId = "ReminderId";
        public const string RecurrenceIndex = "RecurrenceIndex";
        public const string Subject = "Subject";
        public const string Interval = "Interval";
        

        static Intent GetLauncherActivity() {
            return Application.Context.PackageManager.GetLaunchIntentForPackage(CurrentPackageName);
        }

        static string CurrentPackageName => Application.Context.PackageName;
        static string ReminderChannelId => $"{CurrentPackageName}.reminders";

        readonly NotificationChannel notificationChannel;
        NotificationManager NotificationManager => (NotificationManager)Application.Context.GetSystemService(Context.NotificationService);

        public NotificationAlarmHandler() {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O) {
                this.notificationChannel = new NotificationChannel(ReminderChannelId, "Reminders", NotificationImportance.High);
                this.notificationChannel.EnableVibration(true);
                this.notificationChannel.EnableLights(true);
                this.notificationChannel.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm), new AudioAttributes.Builder()
                    .SetContentType(AudioContentType.Sonification)
                    .SetUsage(AudioUsageKind.Alarm)
                    .Build());
                this.notificationChannel.Importance = NotificationImportance.High;
                NotificationManager.CreateNotificationChannel(this.notificationChannel);
            }
        }

        public override void OnReceive(Context context, Intent intent) {
            Guid reminderId = intent.GetReminderId();
            if (reminderId == Guid.Empty)
                return;

            int notificationId = reminderId.GetHashCode();

            Intent resultIntent = GetLauncherActivity().PutExtras(intent.Extras).SetFlags(ActivityFlags.SingleTop );
            PendingIntent resultPendingIntent = PendingIntent.GetActivity(context, notificationId, resultIntent, PendingIntentFlags.UpdateCurrent);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(Application.Context, ReminderChannelId);
            builder.SetContentIntent(resultPendingIntent);
            builder.SetDefaults((int)NotificationDefaults.All);
            
            builder.SetContentTitle(intent.GetStringExtra(Subject));
            builder.SetContentText(intent.GetStringExtra(Interval));
            builder.SetSmallIcon(Resource.Mipmap.app_icon);
            builder.SetChannelId(ReminderChannelId);
            builder.SetPriority((int)NotificationPriority.High);
            builder.SetAutoCancel(true);
            builder.SetVisibility((int)NotificationVisibility.Public);
            NotificationManager.Notify(notificationId, builder.Build());
        }
    }
}
