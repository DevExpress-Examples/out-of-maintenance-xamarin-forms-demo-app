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
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;

namespace DemoCenter.Forms.Data {
    public class GridData : IDemoData {
        readonly List<DemoItem> demoItems;

        public GridData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description = "Demonstrates the DataGridView’s basic features.",
                    Module = typeof(FirstLookView),
                    Icon = "grid_firstlook"
                },
                new DemoItem() {
                    Title = "Auto Filter Row",
                    Description = "Demonstrates the Auto Filter Row that supports a straightforward search for data in columns.",
                    Module = typeof(AutoFilterRowView),
                    Icon = "grid_autofilterrow"
                },
                new DemoItem() {
                    Title = "Virtual Scrolling",
                    Description = "Demonstrates the virtual scrolling feature, which significantly improves the performance of grids with many columns.",
                    Module = typeof(HorizontalVirtualizationView),
                    Icon = "grid_horizontalvirtualization"
                },
                new DemoItem() {
                    Title = "Drag and Drop",
                    Description = "Demonstrates the grid's drag-and-drop functionality that allows users to reorder rows.",
                    Module = typeof(DragDropView),
                    Icon = "grid_dragdrop"
                },
                new DemoItem() {
                    Title = "Editing",
                    Description = "Demonstrates the grid’s inplace data editors.",
                    Module = typeof(EditingView),
                    Icon = "grid_editing",
                    DemoItemStatus = DemoItemStatus.Updated
                },
                new DemoItem() {
                    Title = "Custom Appearance",
                    Description = "Shows how to customize the appearance of individual data cells.",
                    Module = typeof(CustomAppearanceView),
                    Icon = "grid_customappearance"
                },
                new DemoItem() {
                    Title = "Advanced Layout",
                    Description = "Demonstrates how the grid arranges data cells and column headers across multiple rows.",
                    Module = typeof(AdvancedLayoutView),
                    Icon = "grid_advancedlayout"
                },
                new DemoItem() {
                    Title = "Real-Time Data",
                    Description = "Demonstrates a grid view that automatically displays new data when the data source changes.",
                    Module = typeof(RealTimeDataView),
                    Icon = "grid_realtimedata"
                },
                new DemoItem() {
                    Title = "Row Auto Height",
                    Description = "Shows how the grid can automatically adjust row height to display the entire content of cells.",
                    Module = typeof(RowAutoHeightView),
                    Icon = "grid_rowautoheight"
                },
                new DemoItem() {
                    Title = "Swipe" + Environment.NewLine + "Actions",
                    ControlsPageTitle = "Swipe Actions",
                    Description = "Illustrates the UI that is extended with extra buttons when you swipe a data row.",
                    Module = typeof(SwipeButtonsView),
                    Icon = "grid_swipebuttons"
                },
                new DemoItem() {
                    Title = "Pull To Refresh",
                    Description = "Shows how to update the grid’s content with the pull-down gesture.",
                    Module = typeof(PullToRefreshView),
                    Icon = "grid_pulltorefresh"
                },
                new DemoItem() {
                    Title = "Infinite" + Environment.NewLine + "Data Source",
                    ControlsPageTitle = "Infinite Data Source",
                    Description = "Shows how the grid requests new data when users scroll the grid to the end.",
                    Module = typeof(LoadMoreView),
                    Icon = "grid_infinitedatasource"
                },
                new DemoItem() {
                    Title = "Grouping",
                    Description = "Illustrates how the grid groups data against a column and calculates data summaries.",
                    Module = typeof(GroupingView),
                    Icon = "grid_grouping",
                    ShowItemUnderline = false
                }
            };
        }
        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "DataGridView";
    }
}
