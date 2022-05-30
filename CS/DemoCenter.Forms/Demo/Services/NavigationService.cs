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
using System.Threading.Tasks;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.ViewModels.Services;
using DemoCenter.Forms.Views;
using DevExpress.XamarinForms.Core.Internal;
using Xamarin.Forms;

namespace DemoCenter.Forms.Services {
    public class NavigationService : INavigationService {
        NavigationPage navigator;
        bool controlPagePushed;
        bool demoPagePushed;

        public Dictionary<Type, Func<Page>> PageBinders { get; }

        public NavigationService() {
            PageBinders = new Dictionary<Type, Func<Page>>();
            this.controlPagePushed = false;
            this.demoPagePushed = false;
        }
        public void SetNavigator(NavigationPage navPage) {
            this.navigator = navPage;
        }
        public async Task Push(object viewModel) {
            Type vmType = viewModel.GetType();
            if (PageBinders.TryGetValue(vmType, out Func<Page> pageBuilder)) {
                Page page = pageBuilder();
                if (!this.controlPagePushed) {
                    page.BindingContext = viewModel;
                    this.controlPagePushed = true;
                    await PushAsync(page);
                }
            }
        }

        void Page_Disappearing(object sender, EventArgs e) {
            Page page = sender as Page;
            if (page != null) {
                page.Disappearing -= Page_Disappearing;
                if (page is ControlPage) {
                    this.controlPagePushed = false;
                } else {
                    this.demoPagePushed = false;
                    GC.Collect();
                }
            }
        }

        public async Task<Page> PushPage(object viewModel) {
            Page page = null;
            DemoItem item = viewModel as DemoItem;

            if (!this.demoPagePushed &&
                item != null &&
                item.Module != null &&
                item.Module.IsSubclassOf(typeof(Page))
            ) {
                try {
                    page = (Page)Activator.CreateInstance(item.Module);
                    page.Title = item.PageTitle;

                    if (page != null) {
                        this.demoPagePushed = true;
                        await PushAsync(page);
                    }

                } catch(Exception e) {
                    throw e;
                }
            }
            return await Task.FromResult(page);
        }

        public IEnumerable<Page> GetOpenedPages<T>() where T : Page {
            return this.navigator.Navigation.NavigationStack.Where((p) => p.GetType() == typeof(T));
        }

        async Task PushAsync(Page page) {
            page.Disappearing += Page_Disappearing;
            NavigationPage.SetBackButtonTitle(page, "Back");
            this.navigator.BackgroundColor = (Color)Application.Current.Resources["BackgroundThemeColor"];
            await this.navigator.PushAsync(page);
        }
    }
}
