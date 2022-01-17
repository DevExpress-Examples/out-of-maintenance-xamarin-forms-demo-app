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
    public class EditorsData : IDemoData {
        readonly List<DemoItem> demoItems;

        public EditorsData() {
            this.demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Editors",
                    Description="Shows the TextEdit, PasswordEdit, MultilineEdit, and SimpleButton editors on a registration form.",
                    Module = typeof(AccountFormView),
                    Icon = "editors_dataforms"
                },
                new DemoItem() {
                    Title = "Combo Box",
                    Description = "Shows how to customize the ComboBoxEdit.",
                    Module = typeof(ComboBoxEditView),
                    Icon = "editors_comboboxedit"
                },
                new DemoItem() {
                    Title = "Auto Complete",
                    ControlsPageTitle = "Text Editor with Autocomplete",
                    Description = "Shows how to customize the AutoCompleteEdit.",
                    Module = typeof(AutoCompleteEditAsyncView),
                    Icon = "editors_autocomplete"
                },
                new DemoItem() {
                    Title = "Phone Book",
                    PageTitle = "Phone Number Editor"+Environment.NewLine+"with Autocomplete",
                    ControlsPageTitle = "Phone Book with Autocomplete",
                    Description = "Shows how to use the AutoCompleteEdit in a phone book.",
                    Module = typeof(AutoCompleteEditView),
                    Icon = "editors_autocomplete_custom"
                },
                new DemoItem() {
                    Title = "Text Edit",
                    Description = "Demonstrates different TextEdit customization options.",
                    Module = typeof(TextEditView),
                    DemoItemStatus = DemoItemStatus.Updated,
                    Icon = "editors_textedit"
                },
                new DemoItem() {
                    Title = "Numeric Edit",
                    Description = "Demonstrates different NumericEdit customization options.",
                    Module = typeof(NumericEditView),
                    Icon = "editors_numericedit"
                },
                new DemoItem() {
                    Title = "Date Edit",
                    Description = "Demonstrates different DateEdit customization options.",
                    Module = typeof(DateEditView),
                    Icon = "editors_dateedit"
                },
                new DemoItem() {
                    Title = "Time Edit",
                    Description = "Demonstrates different TimeEdit customization options.",
                    Module = typeof(TimeEditView),
                    Icon = "editors_timeedit"
                },
                new DemoItem() {
                    Title = "Check Edit",
                    Description = "Demonstrates different CheckEdit customization options.",
                    Module = typeof(CheckEditView),
                    Icon = "editors_checkedit"
                }
            };
        }

        public List<DemoItem> DemoItems => this.demoItems;
        public string Title => "Editors";
    }
}
