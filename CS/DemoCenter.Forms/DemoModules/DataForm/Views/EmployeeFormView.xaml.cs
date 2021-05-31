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
using DemoCenter.Forms.DemoModules.DataForm.ViewModels;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class EmployeeFormView : ContentPage {
        readonly EmployeeFormViewModel viewModel;

        public EmployeeFormView() {
            DevExpress.XamarinForms.DataForm.Initializer.Init();
            InitializeComponent();
            this.viewModel = new EmployeeFormViewModel();
            BindingContext = this.viewModel;
        }

        protected override void OnSizeAllocated(double width, double height) {
            bool isVertical = height > width;

            if (isVertical && Device.Idiom == TargetIdiom.Phone) {
                photoFrame.Margin = new Thickness(0, 0, 0, 0);
            } else if(Device.Idiom == TargetIdiom.Tablet) {
                photoFrame.Margin = new Thickness(0, 25, 0, 25);
            } else {
                photoFrame.Margin = new Thickness(0, 50, 0, 50);
            }

            this.viewModel.Rotate(dataForm, isVertical);

            base.OnSizeAllocated(width, height); 
        }
    }
}
