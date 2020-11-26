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
using Foundation;
using UIKit;
using UserNotifications;

namespace DemoCenter.Forms.iOS {
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions) {
            global::Xamarin.Forms.Forms.Init();
            DevExpress.XamarinForms.Charts.iOS.Initializer.Init();
            DevExpress.XamarinForms.DataGrid.iOS.Initializer.Init();
            DevExpress.XamarinForms.Editors.iOS.Initializer.Init();
            DevExpress.XamarinForms.CollectionView.iOS.Initializer.Init();
            DevExpress.XamarinForms.Navigation.iOS.Initializer.Init();
            DevExpress.XamarinForms.Scheduler.iOS.Initializer.Init();

            App formsApplication = new App();
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                UNUserNotificationCenter.Current.Delegate = new CustomUserNotificationCenterDelegate(formsApplication);
            LoadApplication(formsApplication);

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }

    public class CustomUserNotificationCenterDelegate : UNUserNotificationCenterDelegate {
        readonly App app;

        public CustomUserNotificationCenterDelegate(App app) {
            this.app = app;
        }

        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler) {
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
            string identifier = response.Notification.Request.Identifier;
            string recurrenceId = identifier.Split(':')[0];
            int recurrenceIndex = Int32.Parse(identifier.Split(':')[1]);
            Guid reminderGuid = Guid.Parse(recurrenceId);
            this.app.ProcessNotificationIfNeed(reminderGuid, recurrenceIndex);
            completionHandler();
        }
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler) {
            completionHandler(UNNotificationPresentationOptions.Alert | UNNotificationPresentationOptions.Badge | UNNotificationPresentationOptions.Badge);
        }
    }
}
