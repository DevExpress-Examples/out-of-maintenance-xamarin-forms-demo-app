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
using DemoCenter.Forms.DemoModules.Drawer.Views.InnerViews;
using DevExpress.XamarinForms.DataGrid;
using DevExpress.XamarinForms.Navigation;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class DrawerPageExample : DrawerPage {
        readonly IDictionary<DemoPage, Page> cachedPages;

        IDictionary<DemoPage, Type> DemoPages => new Dictionary<DemoPage, Type>() {
            {DemoPage.Customers, typeof(DrawerCustomersPage)},
            {DemoPage.Orders, typeof(DrawerOrdersPage)},
            {DemoPage.Products, typeof(DrawerProductsPage)}
        };

        private DemoPage currentPage;

        public DemoPage CurrentPage {
            get => currentPage;
            set {
                if (currentPage != value) {
                    currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }

        public DrawerPageExample() {
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            cachedPages = new Dictionary<DemoPage, Page>();
            InitializeComponent();
            pagesList.ItemsSource = DemoPages.ToList();
            this.CurrentPage = DemoPage.Customers;
            this.BindingContext = this;
            MessagingCenter.Instance.Subscribe<View>(this, "OPEN_DRAWER",
                (sender) => { this.IsDrawerOpened = !this.IsDrawerOpened; });
        }

        protected override void OnPropertyChanged(string propertyName = null) {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(CurrentPage)) {
                SelectPage(CurrentPage);
            }
        }

        void OnSelectionChanged(object sender, RowEventArgs args) {
            IList<KeyValuePair<DemoPage, Type>> pages = pagesList.ItemsSource as IList<KeyValuePair<DemoPage, Type>>;
            SelectPage(pages[args.RowHandle].Key);
        }

        void SelectPage(DemoPage pageName) {
            if (pageName == DemoPage.Unset) {
                this.MainContent = null;
                return;
            }

            if (!cachedPages.TryGetValue(pageName, out Page newPage)) {
                Page requestedPage = Activator.CreateInstance(DemoPages[pageName]) as Page;
                requestedPage.Title = pageName.ToString();
                Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(requestedPage, true);
                NavigationPage.SetTitleView(requestedPage, new DrawerTitleView(pageName.ToString()));
                newPage = new NavigationPage(requestedPage);
                TitleViewExtensions.SetIsShadowVisible(requestedPage, true);
                cachedPages[pageName] = newPage;
            }

            Device.BeginInvokeOnMainThread(() => { this.MainContent = newPage; });
        }
    }
    
    public enum DemoPage {
        Unset = 0,
        Customers,
        Orders,
        Products
    }
}
