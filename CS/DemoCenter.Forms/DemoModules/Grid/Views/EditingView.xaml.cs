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
using System;
using System.Globalization;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.DataGrid;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class EditingView : BaseGridContentPage {
        public EditingView() {
            InitializeComponent();
        }

        private void DataGridView_ValidationError(object sender, ValidationErrorEventArgs e) {
            DisplayAlert("Validation Error", e.ErrorContent, "OK");
        }

        private void DataGridView_ValidateCell(object sender, DataGridValidationEventArgs e) {
            if (e.FieldName == "From.Name" && string.IsNullOrWhiteSpace((string)e.NewValue))
                e.ErrorContent = "The From field is required.";
            if (e.FieldName == "Sent" && (DateTime)e.NewValue > DateTime.Now.Date)
                e.ErrorContent = "The Sent field cannot be in the future.";
        }

        protected override object LoadData() {
            return new OutlookDataRepository(300);
        }

        void Handle_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item == null || dataGridView.EditorShowMode == EditorShowMode.Tap)
                return;
            var editFormPage = new EditFormPage(dataGridView, dataGridView.GetItem(e.RowHandle));
            editFormPage.Disappearing += EditFormPage_Disappearing;
            editFormPage.ValidateCell += DataGridView_ValidateCell;
            Navigation.PushAsync(editFormPage);
        }

        private void EditFormPage_Disappearing(object sender, EventArgs e) {
            var editFormPage = (EditFormPage)sender;
            editFormPage.Disappearing -= EditFormPage_Disappearing;
            editFormPage.ValidateCell -= DataGridView_ValidateCell;
        }

        async void OnItemClicked(object sender, EventArgs e) {
            if (!dataGridView.CloseEditor(true)) {
                dataGridView.CloseEditor(false);
            }
            string action = await DisplayActionSheet("Edit Mode", "Cancel", null, "Inplace", "Edit Form");
            if (action == "Cancel")
                return;
            dataGridView.EditorShowMode = action == "Inplace" ? EditorShowMode.Tap : EditorShowMode.Never;            
        }
    }

    public class DoubleToProgressConverter : IValueConverter {
        public double MaxValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (double)value / MaxValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
