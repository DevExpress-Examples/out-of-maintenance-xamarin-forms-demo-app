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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.DataForm;

namespace DemoCenter.Forms.DemoModules.DataForm.ViewModels {
    public class AccountInfo {
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; } = DateTime.Now.Date;

        [Required(ErrorMessage = "Number cannot be empty")]
        [StringLength(11, MinimumLength = 10, ErrorMessage = "The phone number should contain 10 characters")]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Required")]

        public string Login { get; set; }

        [StringLength(64, MinimumLength = 8, ErrorMessage = "The password should contain at least 8 characters")]
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        public bool ReceiveNotification { get; set; }
    }

    public class AccountFormViewModel : NotificationObject {
        public AccountInfo Model { get; set; }

        bool isVertical;
        public bool IsVertical {
            get => isVertical;
            set => SetProperty(ref isVertical, value);
        }

        public AccountFormViewModel() {
            Model = new AccountInfo() { ReceiveNotification = true };
            IsVertical = true;
        }

        List<string> fieldNamesToReorder = new List<string>() {
            nameof(AccountInfo.LastName),
            nameof(AccountInfo.PhoneNumber),
            nameof(AccountInfo.Password),
        };

        public void Rotate(DataFormView dataForm, bool newIsVertical) {
            if (newIsVertical != IsVertical) {
                if (dataForm.Items != null) {
                    IsVertical = newIsVertical;
                    foreach (string fieldName in fieldNamesToReorder) {
                        DataFormItem item = dataForm.Items.FirstOrDefault(i => i.FieldName == fieldName);
                        int modifier = newIsVertical ? 1 : -1;
                        if (item != null)
                            item.RowOrder += modifier;
                    }
                }
            }
        }
    }
}
