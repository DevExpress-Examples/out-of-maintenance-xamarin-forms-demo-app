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
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using DemoCenter.Forms.Themes;
using DevExpress.Logify.Xamarin;
using Xamarin.Forms;

namespace DemoCenter.Forms.Droid {
    [Activity(Label = "DemoCenter.Forms", Icon = "@mipmap/app_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ThemeLoaderImplementation themeLoader = DependencyService.Get<IThemeLoader>() as ThemeLoaderImplementation;
            if (themeLoader != null)
                themeLoader.Activity = this;
            Environment_Android environment = DependencyService.Get<IEnvironment>() as Environment_Android;
            if (environment != null)
                environment.Activity = this;

            CreateAndLoadApplication(Intent);
        }

        protected override void OnNewIntent(Intent intent) {
            base.OnNewIntent(intent);
            App application = Xamarin.Forms.Application.Current as App;
            application?.ProcessNotificationIfNeed(intent.GetReminderId(), intent.GetRecurrenceIndex());
        }

        void CreateAndLoadApplication(Intent intent) {
            App app = new App();
            app.ProcessNotificationIfNeed(intent.GetReminderId(), intent.GetRecurrenceIndex());
            LoadApplication(app);
            
        }
        internal void UpdateNightMode(bool isLightTheme) {
            AppCompatDelegate.DefaultNightMode = isLightTheme ? AppCompatDelegate.ModeNightNo : AppCompatDelegate.ModeNightYes;
            Delegate.ApplyDayNight();
        }
    }
}
