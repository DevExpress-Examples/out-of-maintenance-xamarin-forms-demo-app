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
using Xamarin.Forms;
using DevExpress.XamarinForms.Editors;
using DemoCenter.Forms.DemoModules.Controls.ViewModels;

namespace DemoCenter.Forms.Views {
    public partial class CalendarView : ContentPage {
        public static readonly BindablePropertyKey OrientationPropertyKey = BindableProperty.CreateReadOnly("Orientation", typeof(StackOrientation), typeof(CalendarView), StackOrientation.Vertical);
        public static readonly BindableProperty OrientationProperty = OrientationPropertyKey.BindableProperty;
        public StackOrientation Orientation => (StackOrientation)GetValue(OrientationProperty);

        public CalendarView() {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();
            ViewModel = new CalendarViewModel();
            BindingContext = ViewModel;
        }

        CalendarViewModel ViewModel { get; }

        void CustomDayCellStyle(object sender, CustomSelectableCellStyleEventArgs e) {
            if (e.Date == DateTime.Today)
                return;

            if (ViewModel.SelectedDate != null && e.Date == ViewModel.SelectedDate.Value)
                return;

            SpecialDate specialDate = ViewModel.TryFindSpecialDate(e.Date);
            if (specialDate == null)
                return;

            e.FontAttributes = FontAttributes.Bold;
            Color textColor;
            if (specialDate.IsHoliday) {
                textColor = (Color)Application.Current.Resources["CalendarViewHolidayTextColor"];
                e.EllipseBackgroundColor = Color.FromRgba(textColor.R, textColor.G, textColor.B, 0.25);
                e.TextColor = textColor;
                
                return;
            }
            textColor = (Color)Application.Current.Resources["CalendarViewTextColor"];
            e.EllipseBackgroundColor = Color.FromRgba(textColor.R, textColor.G, textColor.B, 0.15);
            e.TextColor = textColor;
        }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            SetValue(OrientationPropertyKey, width > height ? StackOrientation.Horizontal : StackOrientation.Vertical);
        }
    }
}
