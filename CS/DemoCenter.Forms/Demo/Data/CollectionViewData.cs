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
﻿using System;
using System.Collections.Generic;
using DemoCenter.Forms.DemoModules.CollectionView.Views;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;

namespace DemoCenter.Forms.Data {
    public class CollectionViewData : IDemoData {
        public CollectionViewData() {
            DemoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description = "Demonstrates the DXCollectionView's basic features.",
                    Module = typeof(ContactsView),
                    Icon = "collectionview_firstlook"
                },
                new DemoItem() {
                    Title = "Swipe Actions",
                    Description = "Illustrates the UI that is extended with extra buttons when you swipe an item row.",
                    Module = typeof(CollectionViewDefaultSwipes),
                    Icon = "grid_swipebuttons"
                },
                new DemoItem() {
                    Title = "Horizontal Scrolling",
                    Description = "Demonstrates the DXCollectionView's items Horizontal Scrolling.",
                    Module = typeof(CollectionViewHorizontalScrolling),
                    Icon = "collectionview_horvirt"
                },
                new DemoItem() {
                    Title = "Row Auto Height",
                    Description = "Shows how the list can automatically adjust item height to display the entire content of items.",
                    Module = typeof(CollectionViewRowAutoHeightView),
                    Icon = "grid_rowautoheight"
                },
                new DemoItem() {
                    Title = "Drag and Drop",
                    Description = "Demonstrates the list's drag-and-drop functionality. This feature allows users to reorder items.",
                    Module = typeof(CollectionViewDragDropView),
                    Icon = "grid_dragdrop"
                },
                new DemoItem() {
                    Title = "Pull To Refresh",
                    Description = "Shows how end users can use a pull-down gesture to update the list.",
                    Module = typeof(CollectionViewPullToRefreshView),
                    Icon = "grid_pulltorefresh"
                },
                new DemoItem() {
                    Title = "Infinite" + Environment.NewLine + "Data Source",
                    ControlsPageTitle = "Infinite Data Source",
                    Description = "Shows how the list requests new data when users scroll to the end of the list.",
                    Module = typeof(CollectionViewLoadMoreView),
                    Icon = "collectionview_loadmore",
                    ShowItemUnderline = false
                }
            };
        }

        public List<DemoItem> DemoItems { get; }
        public string Title => "CollectionView";
    }
}
