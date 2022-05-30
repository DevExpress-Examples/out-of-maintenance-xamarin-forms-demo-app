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
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.Services;
using DemoCenter.Forms.Themes;
using DemoCenter.Forms.ViewModels;
using DemoCenter.Forms.Views;
using DevExpress.XamarinForms.Core.Themes;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace DemoCenter.Forms {
    public partial class App : Xamarin.Forms.Application {
        readonly NavigationService navigationService;
        bool themeIsSetting = false;
        internal event EventHandler ThemeChagedEvent;
        public App() {
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Pan);
            InitializeComponent();

            this.navigationService = new NavigationService();
            this.navigationService.PageBinders.Add(typeof(ControlViewModel), () => new ControlPage());

            MainViewModel mainViewModel = new MainViewModel(this.navigationService);
            AboutViewModel aboutViewModel = new AboutViewModel(new XFUriOpener());
            RootPage rootPage = new RootPage();
            rootPage.MainContent.BindingContext = mainViewModel;
            rootPage.DrawerContent.BindingContext = aboutViewModel;

            MainPage = rootPage;

            this.navigationService.SetNavigator(rootPage.NavPage);
            ThemeLoader.Instance.LoadTheme();
        }

        public async void ProcessNotificationIfNeed(Guid reminderId, int recurrenceIndex) {
            if (reminderId == Guid.Empty)
                return;
            IEnumerable<Page> openedPages = this.navigationService.GetOpenedPages<RemindersDemo>();
            RemindersDemo remindersDemo = (openedPages.Any() ? openedPages.Last() : await this.navigationService.PushPage(SchedulerData.GetItem(typeof(RemindersDemo)))) as RemindersDemo; 
            remindersDemo?.OpenAppointmentEditForm(reminderId, recurrenceIndex);
        }

        protected override async void OnStart() {
            base.OnStart();
            bool lightTheme = await DependencyService.Get<IEnvironment>().IsLightOperatingSystemTheme();
            ApplyTheme(lightTheme);
        }

        protected override void OnSleep() {
        }

        protected override async void OnResume() {
            base.OnResume();
            if (!this.themeIsSetting) {
                bool lightTheme = await DependencyService.Get<IEnvironment>().IsLightOperatingSystemTheme();
                ApplyTheme(lightTheme);
            }
        }
        void ApplyTheme(bool isLightTheme) {
            ThemeManager.ThemeName = isLightTheme ? Theme.Light : Theme.Dark;
            ThemeChagedEvent?.Invoke(this, new EventArgs());
        }
        internal void ApplyTheme(bool isLightTheme, bool force) {
            if (force) {
                ApplyTheme(isLightTheme);
                this.themeIsSetting = true;
            }
        }
    }
}
