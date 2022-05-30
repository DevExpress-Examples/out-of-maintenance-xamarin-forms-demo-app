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
﻿using System.Collections.Generic;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;
using DemoCenter.Forms.DemoModules.Popup.Views;

namespace DemoCenter.Forms.Data {
    public class ControlsData : IDemoData {
        public ControlsData() {
            DemoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Calendar",
                    Description = "A calendar that allows a user to select a date. The calendar highlights holidays and observances.",
                    Module = typeof(CalendarView),
                    DemoItemStatus = DemoItemStatus.New,
                    Icon = "controls_calendar"
                },
                new DemoItem() {
                    Title = "Choice Chip Group",
                    Description = "Choice chips allow users to select a single option from a set. These chips are best used when only one choice is possible.",
                    Module = typeof(SuperHeroTShirtView),
                    Icon = "chips_choicechipgroup"
                },
                new DemoItem() {
                    Title = "Chips",
                    Description = "Chips display information in a discrete and compact form. They allow users to make selections, filter content, or trigger actions.",
                    Module = typeof(ChipView),
                    Icon = "chips"
                },
                new DemoItem() {
                    Title = "Dialog",
                    Description = "A popup dialog is a floating window that appears on top of the current view and prevents access to it.",
                    Module = typeof(PopupDialogView),
                    Icon = "popup_dialog"
                },
                new DemoItem() {
                    Title = "Context Menu",
                    Description = "Shows how to implement a context menu that appears when a user taps a button.",
                    Module = typeof(ContactsDropdownView),
                    Icon = "popup_dropdown"
                },
                new DemoItem() {
                    Title = "Simple Button",
                    Description = "Illustrates how to customize a button.",
                    Module = typeof(SimpleButtonView),
                    Icon = "controls_buttons",
                    ShowItemUnderline = false
                }
            };
        }

        public List<DemoItem> DemoItems { get; }
        public string Title => "Controls";
    }
}
