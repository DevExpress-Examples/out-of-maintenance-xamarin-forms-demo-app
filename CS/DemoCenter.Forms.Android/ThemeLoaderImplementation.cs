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
using System.Threading.Tasks;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using DemoCenter.Forms.Droid;
using DemoCenter.Forms.Themes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(ThemeLoaderImplementation))]
[assembly: Xamarin.Forms.Dependency(typeof(Environment_Android))]
namespace DemoCenter.Forms.Droid {
    public class ThemeLoaderImplementation : IThemeLoader {

        public ThemeLoaderImplementation() { }

        public MainActivity Activity { get; set; }

        public void LoadTheme(ResourceDictionary theme, bool isLightTheme) {
            Android.Graphics.Color backgroundColor = ((Xamarin.Forms.Color)theme["BackgroundThemeColor"]).ToAndroid();
            Device.BeginInvokeOnMainThread(() => {
                var currentWindow = GetCurrentWindow();
                currentWindow.DecorView.SystemUiVisibility = isLightTheme ? (StatusBarVisibility)SystemUiFlags.LightStatusBar | (StatusBarVisibility)SystemUiFlags.LightNavigationBar : 0;
                if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                    currentWindow.SetStatusBarColor(backgroundColor);
                }
                if(Build.VERSION.SdkInt >= BuildVersionCodes.OMr1) {
                    currentWindow.SetNavigationBarColor(backgroundColor);
                }
            });
        }
        Window GetCurrentWindow() {
            var window = Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
    }


    public class Environment_Android : DemoCenter.Forms.Themes.IEnvironment {

        public MainActivity Activity { get; set; }

        public Task<bool> IsLightOperatingSystemTheme() { 
            //Ensure the device is running Android Froyo or higher because UIMode was added in Android Froyo, API 8.0
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Froyo) {
                UiMode uiModeFlags = Activity.ApplicationContext.Resources.Configuration.UiMode & UiMode.NightMask;
                switch (uiModeFlags) {
                    case UiMode.NightYes:
                        return Task.FromResult(false);

                    case UiMode.NightNo:
                        return Task.FromResult(true);

                    default:
                        return Task.FromResult(true);
                }
            }
            else {
                return Task.FromResult(true);
            }
        }
    }
}


