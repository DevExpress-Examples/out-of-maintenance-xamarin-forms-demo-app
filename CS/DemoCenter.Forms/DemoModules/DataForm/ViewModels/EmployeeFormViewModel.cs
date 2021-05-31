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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.DataForm.ViewModels {
    public class EmployeeInfo : IDataErrorInfo {
        public EmployeeInfo() {
            FirstName = "Arvil";
            LastName = "Chase";
            BirthDate = DateTime.Parse("1978-06-26T00:00:00");
            Position = "Research and Development Engineer";
            HireDate = DateTime.Parse("1998-10-20T00:00:00");
            Notes = FirstName + " has been in the Audio/ Video industry since 1990. He has led DevAV as its CEO since 2003. " +
                    "When not working hard as the CEO, John loves to golf and bowl. He once bowled a perfect game of 300";
            Address = "351 S Hill St.";
            City = "Los Angeles";
            State = "CA";
            Zip = 90013;
            HomePhoneNumber = "(718) 193-6521";
            MobilePhoneNumber = HomePhoneNumber;
            Email = "Arvil_Chase@example.com";
            Skype = FirstName + LastName + "_DX_skype";

            Photo = ImageSource.FromResource("DemoCenter.Forms.DemoModules.DataForm.Images.Arvil.jpg");
        }

        public ImageSource Photo { get; private set; }

        [Required(ErrorMessage = "First Name shouldn't be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name shouldn't be empty")]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        public DateTime HireDate { get; set; }

        public string Notes { get; set; }

        [Required(ErrorMessage = "Address shouldn't be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City shouldn't be empty")]
        public string City { get; set; }

        [Required(ErrorMessage = "State shouldn't be empty")]
        public string State { get; set; }

        [RegularExpression(@"(^\d{5}$)|(^\d{5}-\d{4}$)", ErrorMessage = "Invalid zip-code")]
        public int? Zip { get; set; }

        [Required(ErrorMessage = "Number shouldn't be empty")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number should contain 10 characters")]
        public string HomePhoneNumber { get; set; }

        [Required(ErrorMessage = "Number shouldn't be empty")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The phone number should contain 10 characters")]
        public string MobilePhoneNumber { get; set; }

        public string Email { get; set; }
        public string Skype { get; set; }

        string IDataErrorInfo.Error => String.Empty;
        string IDataErrorInfo.this[string columnName] => String.Empty;
    }

    public partial class EmployeeFormViewModel : NotificationObject, IPickerSourceProvider {
        readonly string[] positions = {
            "Chief Executive Officer", "Database Administrator", "Application Specialist",
            "Network Manager", "Network Administrator", "Marketing Manager",
            "Marketing Specialist", "Research and Development Engineer"
        };
        public EmployeeInfo Model { get; }

        bool firstLayout;
        bool isVertical;
        public bool IsVertical {
            get => this.isVertical;
            set => SetProperty(ref this.isVertical, value);
        }

        public EmployeeFormViewModel() {
            Model = new EmployeeInfo();
            IsVertical = true;
            this.firstLayout = true;
        }

        public void Rotate(DataFormView dataForm, bool newIsVertical) {
            if (newIsVertical != IsVertical || this.firstLayout) {
                this.firstLayout = false;

                if (dataForm.Items != null) {
                    IsVertical = newIsVertical;
                    foreach (DataFormItem item in dataForm.Items) {
                        int rowOrder = GetFieldOrder(item.FieldName);
                        if (rowOrder >= 0)
                            item.RowOrder = rowOrder;
                        if (item.FieldName == nameof(EmployeeInfo.Photo)) {
                            SetPhotoItemProperties(item);
                        }
                    }
                }
            }
        }

        public IEnumerable GetSource(string propertyName) {
            if (propertyName == nameof(EmployeeInfo.Position)) {
                return positions.ToList();
            }
            return null;
        }

        void SetPhotoItemProperties(DataFormItem item) {
            if (Device.Idiom == TargetIdiom.Phone && IsVertical) {
                item.RowSpan = 1;
            } else {
                item.RowSpan = 3;
            }
        }

        int GetFieldOrder(string fieldName) {
            if(Device.Idiom == TargetIdiom.Tablet) {
                return IsVertical ?
                    EmloyeeLayoutTemplate.TabletVertical.GetFieldOrder(fieldName) :
                    EmloyeeLayoutTemplate.TabletHorizontal.GetFieldOrder(fieldName);
            } else {
                return IsVertical ?
                    EmloyeeLayoutTemplate.PhoneVertical.GetFieldOrder(fieldName) :
                    EmloyeeLayoutTemplate.PhoneHorizontal.GetFieldOrder(fieldName);
            }
        }
    }
}
