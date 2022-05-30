/*
               Copyright (c) 2015-2022 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2022 Developer Express Inc.              }
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
using System.Threading.Tasks;
using DemoCenter.Forms.iOS;
using DemoCenter.Forms.Themes;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ThemeLoaderImplementation))]
[assembly: Xamarin.Forms.Dependency(typeof(Environment_iOS))]
namespace DemoCenter.Forms.iOS {
    public class ThemeLoaderImplementation : NSObject, IThemeLoader {
        public void LoadTheme(ResourceDictionary theme, bool isLightTheme) {
            Device.BeginInvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.SetStatusBarStyle(isLightTheme ? UIStatusBarStyle.Default: UIStatusBarStyle.LightContent, false);
                GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
            });
        }
        UIViewController GetCurrentViewController() {
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            UIViewController viewController = window.RootViewController;
            while(viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;
            return viewController;
        }
    }

    public class Environment_iOS : NSObject, IEnvironment {
        public async Task<bool> IsLightOperatingSystemTheme() {
            if (UIDevice.CurrentDevice.CheckSystemVersion(12, 0)) {
                UIViewController currentUIViewController = await GetVisibleViewController();

                UIUserInterfaceStyle userInterfaceStyle = currentUIViewController.TraitCollection.UserInterfaceStyle;

                switch (userInterfaceStyle) {
                    case UIUserInterfaceStyle.Light:
                        return true;
                    case UIUserInterfaceStyle.Dark:
                        return false;
                    default:
                        return true;
                }
            }
            else {
                return true;
            }
        }

        static Task<UIViewController> GetVisibleViewController() {
            TaskCompletionSource<UIViewController> tcs = new TaskCompletionSource<UIViewController>();
            Device.BeginInvokeOnMainThread(() => {
                try {
                    UIViewController rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

                    UINavigationController navigationController = rootController.PresentedViewController as UINavigationController;
                    UITabBarController tabBarController = rootController.PresentedViewController as UITabBarController;
                    if (navigationController != null)
                        tcs.SetResult(navigationController.TopViewController);
                    else if (tabBarController != null)
                        tcs.SetResult(tabBarController.SelectedViewController);
                    else if (rootController.PresentedViewController == null)
                        tcs.SetResult(rootController);
                    else
                        tcs.SetResult(rootController.PresentedViewController);
                }
                catch (Exception ex) {
                    tcs.SetException(ex);
                }

            });
            return tcs.Task;
        }
    }
}
