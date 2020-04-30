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
using DemoCenter.Forms.Demo;
using DevExpress.XamarinForms.Core.Themes;

namespace DemoCenter.Forms.Models {
    public class DemoItem {
        string pageTitle = null;
        string icon = null;
        string controlsPageTitle = null;
        DemoItemStatus demoItemStatus = DemoItemStatus.None;
        bool showItemUnderline = true;

        public string Icon {
            get => icon;
            set {
                icon = value;
                PreloadIcon();
            }
        }
        public string Title { get; set; }
        public string PageTitle {
            get => pageTitle ?? ControlsPageTitle;
            set { pageTitle = value; }
        }
        public string ControlsPageTitle {
            get => controlsPageTitle ?? Title;
            set { controlsPageTitle = value; }
        }
        public string Description { get; set; }
        public Type Module { get; set; }
        public bool ShowItemUnderline { get { return showItemUnderline; } set { showItemUnderline = value; } }
        public DemoItemStatus DemoItemStatus { get { return demoItemStatus; } set { demoItemStatus = value; } }

        public bool ShowBadge { get { return demoItemStatus != DemoItemStatus.None; } }

        public string BadgeIcon {
            get {
                if (demoItemStatus == DemoItemStatus.Updated) {
                    return "badgeUpdated.svg";
                } else if (demoItemStatus == DemoItemStatus.New) {
                    return "badgeNew.svg";
                } else return string.Empty;
            }
        }

        void PreloadIcon() {
            IconView.LoadImage(Icon, ThemeManager.ThemeName);
        }
    }
}