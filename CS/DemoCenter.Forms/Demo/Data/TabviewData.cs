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
using System.Collections.Generic;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;
using Xamarin.Forms;

namespace DemoCenter.Forms.Data {
    public interface INestedTabView {
        bool CanBeShown();
    }
    public interface ITabPages {
        bool CanBeShown();
    }

    public class TabviewData : IDemoData {
        List<DemoItem> demoItems;
        INestedTabView nestedTabView;
        ITabPages tabPages;

        public TabviewData() {
            nestedTabView = DependencyService.Get<INestedTabView>();
            tabPages = DependencyService.Get<ITabPages>();

            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Header Panel" + Environment.NewLine + "Position",
                    ControlsPageTitle = "Header Panel Position",
                    PageTitle = "Contacts",
                    Description = "This demo illustrates a View that docks its header to different screen edges.",
                    Module = typeof(PhoneListView),
                    Icon = "TabViewList.HeaderPanelPosition.svg"},
                new DemoItem() {
                    Title = "Data" + Environment.NewLine + "Binding",
                    ControlsPageTitle = "Data Binding",
                    PageTitle = "Companies",
                    Description="The Tab View populates its tabs from an item source in this demo.",
                    Module = typeof(CompaniesTabView),
                    Icon = "TabViewList.DataBinding.svg"}
            };

            if (nestedTabView.CanBeShown())
                demoItems.Add(new DemoItem() {
                    Title = "Nested" + Environment.NewLine + "Tab Views",
                    ControlsPageTitle = "Nested Tab Views",
                    PageTitle = "Nested Tab Views",
                    Description = "The tab view is moved to another tab view in this demo.",
                    Module = typeof(NestedTabView),
                    Icon = "TabViewList.NestedTabsViews.svg"
                });

            if (tabPages.CanBeShown())
                demoItems.Add(new DemoItem() {
                    Title = "Root-Level" + Environment.NewLine + "Tabs",
                    ControlsPageTitle = "Root-Level Tabs",
                    PageTitle = "Tab Pages",
                    Description = "Demonstrates the TabPage’s general features.",
                    Module = typeof(DemoTabPages),
                    Icon = "TabViewList.TabsWithPages.svg"
                });

            demoItems[demoItems.Count - 1].ShowItemUnderline = false;
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title { get { return "Tabs"; } }
    }
}