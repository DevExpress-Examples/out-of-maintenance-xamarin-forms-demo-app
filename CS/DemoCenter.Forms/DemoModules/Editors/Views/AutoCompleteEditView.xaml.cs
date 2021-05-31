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
using DemoCenter.Forms.DemoModules.Editors.ViewModels;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.Editors;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class AutoCompleteEditView : ContentPage {
        IList<Employee> employees;
        Color accentColor;

        public AutoCompleteEditView() {
            Initializer.Init();
            InitializeComponent();
            this.accentColor = ((AutoCompleteEditViewModel)BindingContext).SelectedAccentColor.Color;
            this.employees = new EmployeesRepository().Employees;
        }

        void AutocompleteEdit_TextChanged(object sender, AutoCompleteEditTextChangedEventArgs e) {
            if (e.Reason == AutoCompleteEditTextChangeReason.SuggestionChosen)
                return;

            if (String.IsNullOrEmpty(this.autocompleteEdit.Text)) {
                this.autocompleteEdit.ItemsSource = null;
                this.autocompleteEdit.IsDropDownOpen = false;
                return;
            }

            List<EmployeeCardViewModel> source = new List<EmployeeCardViewModel>();
            foreach (Employee employee in this.employees) {
                PhoneBookEntryMatch phoneNumberMatch = PhonebookMatchHelper.MatchPhoneNumber(employee.Phone, this.autocompleteEdit.Text);
                PhoneBookEntryMatch fullNameMatch = PhonebookMatchHelper.MatchPhoneLetters(employee.FullName, this.autocompleteEdit.Text);
                if (phoneNumberMatch == null && fullNameMatch == null)
                    continue;
                source.Add(new EmployeeCardViewModel(employee, phoneNumberMatch?.AsFormattedString(this.accentColor), fullNameMatch?.AsFormattedString(this.accentColor)));
            }

            this.autocompleteEdit.ItemsSource = source;
        }
    }
}
