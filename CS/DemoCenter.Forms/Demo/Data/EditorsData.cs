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
using System.Collections.Generic;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;

namespace DemoCenter.Forms.Data {
    public class EditorsData : IDemoData {
        List<DemoItem> demoItems;

        public EditorsData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Editors",
                    Description="Shows the TextEdit, PasswordEdit, MultilineEdit, and SimpleButton editors on a registration form.",
                    Module = typeof(AccountFormView),
                    Icon = "Editors.DataForms.svg",
                    DemoItemStatus = DemoItemStatus.New
                },
                new DemoItem() {
                    Title = "Combo Box",
                    Description = "Shows how to customize the ComboBoxEdit.",
                    Module = typeof(ComboBoxEditView),
                    Icon = "Editors.ComboBoxEdit.svg",
                    DemoItemStatus = DemoItemStatus.New,
                    ShowItemUnderline = false

                },
                new DemoItem() {
                    Title = "Text Edit",
                    Description = "Demonstrates different TextEdit customization options.",
                    Module = typeof(TextEditView),
                    Icon = "Editors.TextEdit.svg",
                    DemoItemStatus = DemoItemStatus.New,
                    ShowItemUnderline = false

                },
                new DemoItem() {
                    Title = "Simple Button",
                    Description = "Illustrates SimpleButton customization options.",
                    Module = typeof(SimpleButtonView),
                    Icon = "Controls.Buttons.svg",
                    DemoItemStatus = DemoItemStatus.New,
                    ShowItemUnderline = false
                }

            };
        }

        public List<DemoItem> DemoItems => demoItems;
        public string Title { get { return "Editors"; } }
    }
}
