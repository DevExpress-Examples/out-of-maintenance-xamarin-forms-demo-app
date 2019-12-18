/*                                                         
               Copyright (c) 2019 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile UI for Xamarin.Forms               }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2019 Developer Express Inc.                   }   
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
    public interface IDrawerPages {
        bool CanBeShown();
    }

    public class DrawerViewData : IDemoData {
        List<DemoItem> demoItems;
        IDrawerPages drawerPages;

        public DrawerViewData() {
            drawerPages = DependencyService.Get<IDrawerPages>();

            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "First Look",
                    Description="Demonstrates the DrawerView’s general features.",
                    Module = typeof(DrawerMailBoxView),
                    Icon = "DrawerList.FirstLook.svg"
                },
                new DemoItem() {
                    Title = "Drawer"+Environment.NewLine+"Settings",
                    ControlsPageTitle = "Drawer Settings",
                    Description="This demo allows you to configure various settings and see how they affect the View.",
                    Module = typeof(DrawerSettingsView),
                    Icon = "DrawerList.DrawerSettings.svg"
                }
            };
            if (drawerPages.CanBeShown())
                demoItems.Add(new DemoItem() {
                    Title = "Root-Level" + Environment.NewLine + "Drawer",
                    ControlsPageTitle = "Root-Level Drawer",
                    Description = "Demonstrates the DrawerPage’s general features.",
                    Module = typeof(DrawerPageExample),
                    Icon = "DrawerList.Pages.svg",
                    ShowItemUnderline = false
                });
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title { get { return "Drawer"; } }
    }
}