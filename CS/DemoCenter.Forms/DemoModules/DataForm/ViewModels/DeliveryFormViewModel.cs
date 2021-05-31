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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.DataForm;

namespace DemoCenter.Forms.DemoModules.DataForm.ViewModels {
    public class DeliveryInfo : IDataErrorInfo {
        const string leftColumnWidth = "40";

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editors_name")]
        [DataFormItemPosition(RowOrder = 0)]
        [DataFormTextEditor(InplaceLabelText = "First name")]
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelText = "")]
        [DataFormItemPosition(RowOrder = 1)]
        [DataFormTextEditor(InplaceLabelText = "Last name")]
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editors_location")]
        [DataFormItemPosition(RowOrder = 2)]
        [DataFormTextEditor(InplaceLabelText = "Address")]
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelText = "")]
        [DataFormItemPosition(RowOrder = 3)]
        [DataFormTextEditor(InplaceLabelText = "City")]
        [Required(ErrorMessage = "City cannot be empty")]
        public string City { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.65*", LabelText = "")]
        [DataFormItemPosition(RowOrder = 4, ItemOrderInRow = 0)]
        [DataFormTextEditor(InplaceLabelText = "State")]
        [Required(ErrorMessage = "State cannot be empty")]
        public string State { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.35*", EditorMaxWidth = 150, IsLabelVisible = false)]
        [DataFormItemPosition(RowOrder = 4, ItemOrderInRow = 1)]
        [DataFormNumericEditor(InplaceLabelText = "Zip")]
        [RegularExpression(@"(^\d{5}$)|(^\d{5}-\d{4}$)", ErrorMessage = "Invalid zip-code")]
        public int? Zip { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.3*", LabelIcon = "editors_phone", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 6)]
        [DataFormTextEditor(InplaceLabelText = "Code", Keyboard = "Numeric")]
        [Required(ErrorMessage = "Required")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "Phone code must be 3 numbers length")]
        public string PhoneCode { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, EditorWidth = "0.7*", IsLabelVisible = false)]
        [DataFormItemPosition(RowOrder = 6)]
        [DataFormMaskedEditor(Mask = "000-0000", InplaceLabelText = "Phone number", Keyboard = "Telephone")]
        [Required(ErrorMessage = "Number cannot be empty")]
        [StringLength(maximumLength: 10, MinimumLength = 7, ErrorMessage = "Phone number must be 7 to 10 numbers length")]
        public string PhoneNumber { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editors_email", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 7)]
        [DataFormTextEditor(InplaceLabelText = "Email", Keyboard = "Email")]
        public string Email { get; set; }

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editors_calendar", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 9)]
        [DisplayFormat(DataFormatString = "d")]
        [DataFormDateEditor]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.Date;

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, LabelIcon = "editors_time", IsLabelVisible = true)]
        [DataFormItemPosition(RowOrder = 10, ItemOrderInRow = 0)]
        [DisplayFormat(DataFormatString = "t")]
        [DataFormTimeEditor]
        public DateTime DeliveryTimeFrom { get; set; } = DateTime.Now;

        [DataFormDisplayOptions(LabelWidth = leftColumnWidth, IsLabelVisible = false)]
        [DataFormItemPosition(RowOrder = 10, ItemOrderInRow = 1)]
        [DisplayFormat(DataFormatString = "t")]
        [DataFormTimeEditor]
        public DateTime DeliveryTimeTo { get; set; } = DateTime.Now.AddHours(1);

        string IDataErrorInfo.Error => String.Empty;

        string IDataErrorInfo.this[string columnName] {
            get {
                if (columnName == nameof(DeliveryTimeTo)
                    && !CheckIsDeliveryTimeCorrect()) {
                    return "The end time cannot be less than the start time";
                }
                if (columnName == nameof(DeliveryDate) && DeliveryDate < DateTime.Now.Date) {
                    return "Delivery cannot be earlier than today";
                }
                return String.Empty;
            }
        }

        public bool CheckIsDeliveryTimeCorrect() {
            return DeliveryTimeTo > DeliveryTimeFrom;
        }
    }
    public class DeliveryFormViewModel : NotificationObject {
        public DeliveryInfo Model { get; set; }

        public DeliveryFormViewModel() {
            Model = new DeliveryInfo();
        }

        Dictionary<string, bool> fieldNamesToReorder = new Dictionary<string, bool>() {
            { nameof(DeliveryInfo.LastName), true },
            { nameof(DeliveryInfo.City), true },
            { nameof(DeliveryInfo.DeliveryTimeFrom), true },
            { nameof(DeliveryInfo.DeliveryTimeTo), false },
        };

        bool isVertical = true;

        public void Rotate(DataFormView dataForm, bool newIsVertical) {
            if (newIsVertical != isVertical) {
                if (dataForm.Items != null) {
                    isVertical = newIsVertical;
                    foreach (KeyValuePair<string, bool> fieldName in fieldNamesToReorder) {
                        DataFormItem item = dataForm.Items.FirstOrDefault(i => i.FieldName == fieldName.Key);
                        int modifier = newIsVertical ? 1 : -1;
                        if (item != null) {
                            item.RowOrder += modifier;
                            if (fieldName.Value)
                                item.IsLabelVisible = newIsVertical;
                        }
                    }
                }
            }
        }
    }
}
