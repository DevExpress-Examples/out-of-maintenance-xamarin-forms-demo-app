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
using DemoCenter.Forms.DemoModules.DataForm.ViewModels;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class DeliveryFormView : ContentPage {
        public DeliveryFormView() {
            DevExpress.XamarinForms.DataForm.Initializer.Init();
            InitializeComponent();
            BindingContext = new DeliveryFormViewModel();
            dataForm.ValidateProperty += DataFormOnValidateProperty;
        }

        void DataFormOnValidateProperty(object sender, DataFormPropertyValidationEventArgs e) {
            if (e.PropertyName == nameof(DeliveryInfo.DeliveryTimeFrom)) {
                ((DeliveryInfo) dataForm.DataObject).DeliveryTimeFrom = (DateTime)e.NewValue;
                Device.BeginInvokeOnMainThread(() => {
                    dataForm.Validate(nameof(DeliveryInfo.DeliveryTimeTo));    
                });
            }
            if (e.PropertyName == nameof(DeliveryInfo.DeliveryTimeTo)) {
                DateTime timeFrom = ((DeliveryInfo) dataForm.DataObject).DeliveryTimeFrom;
                if(timeFrom > (DateTime)e.NewValue) {
                    e.HasError = true;
                    e.ErrorText = "The end time cannot be less than the start time";
                    return;
                }
            }
        }

        protected override void OnSizeAllocated(double width, double height) {
            ((DeliveryFormViewModel) this.BindingContext).Rotate(dataForm, height > width);
            base.OnSizeAllocated(width, height);
        }

        private void Submit_OnClicked(object sender, EventArgs e) {
            dataForm.Commit();
            if (dataForm.Validate()) 
                DisplayAlert("Success", "Your delivery information has been successfully saved", "OK");
        }
    }
}
