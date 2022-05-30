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
using System.Collections.Generic;
using DemoCenter.Forms.Models;

namespace DemoCenter.Forms.Data {
    public class DemoGroupsData {
        static readonly List<DemoItem> demoItems;

        static DemoGroupsData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "DataGrid",
                    Description = "Grid",
                    Module = typeof(GridData)
                },
                new DemoItem() {
                    Title = "Editors",
                    Description = "Editors",
                    Module = typeof(EditorsData)
                },
                new DemoItem() {
                    Title = "Controls",
                    Description = "Controls",
                    Module = typeof(ControlsData)
                },
                new DemoItem() {
                    Title = "Charts",
                    Description = "Charts",
                    Module = typeof(ChartsData)
                },
                new DemoItem() {
                    Title = "Scheduler",
                    Description = "Scheduler",
                    Module = typeof(SchedulerData)
                },
                new DemoItem() {
                    Title = "DataForm",
                    Description = "Data Form",
                    Module = typeof(DataFormData)
                },
                new DemoItem() {
                    Title = "Tabs",
                    Description = "Tabs",
                    Module = typeof(TabViewData)
                },
                new DemoItem() {
                    Title = "Drawer",
                    Description = "Drawer",
                    Module = typeof(DrawerViewData)
                },
                new DemoItem() {
                    Title = "CollectionView",
                    Description = "CollectionView",
                    Module = typeof(CollectionViewData)
                }
            };
         }

        public static List<DemoItem> DemoItems => demoItems;
    }
}
