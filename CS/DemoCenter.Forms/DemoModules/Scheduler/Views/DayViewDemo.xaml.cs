/*                                                         
               Copyright (c) 2019 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile UI for Xamarin.Forms               }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2019 Developer Express Inc.                   }   
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
using System.Linq;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Scheduler;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class DayViewDemo : ContentPage {
        readonly DailyEmployeeCalendarViewModel viewModel = new DailyEmployeeCalendarViewModel();
        bool inNavigation = false;

        public DayViewDemo() {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }

        async void DayView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation)
                return;
            Page appointmentPage = storage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                inNavigation = true;
                await Navigation.PushAsync(appointmentPage);
            }
        }
        async void OnItemClicked(object sender, EventArgs e) {
            Dictionary<string, int> daysCountKeyValues = new Dictionary<string, int>() {
                { "One day",    1 },
                { "Three days", 3 },
                { "Five days",  5 },
            };
            string action = await DisplayActionSheet("Day Count", "Cancel", null, daysCountKeyValues.Keys.ElementAt(0), daysCountKeyValues.Keys.ElementAt(1), daysCountKeyValues.Keys.ElementAt(2));
            if (!String.IsNullOrEmpty(action) && daysCountKeyValues.ContainsKey(action))
                viewModel.DaysCount = daysCountKeyValues[action];
        }
    }
}
