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
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Editors;

namespace DemoCenter.Forms.DemoModules.Controls.ViewModels {
    public class CalendarViewModel : NotificationObject {
        DateTime displayDate;
        DateTime? selectedDate;
        DXCalendarViewType activeViewType;
        bool isHolidaysAndObservancesListVisible;
        IEnumerable<SpecialDate> specialDates;

        public CalendarViewModel() {
            DisplayDate = DateTime.Today;
            UpdateHolidaysAndObservancesListVisible();
        }

        public IEnumerable<SpecialDate> SpecialDates {
            get => this.specialDates;
            set => SetProperty(ref this.specialDates, value);
        }

        public DateTime DisplayDate {
            get => this.displayDate;
            set => SetProperty(ref this.displayDate, value, () => {
                UpdateCurrentCalendarIfNeeded();
                SpecialDates = USCalendar.GetSpecialDatesForMonth(DisplayDate.Month);
            });
        }

        public DateTime? SelectedDate {
            get => this.selectedDate;
            set => SetProperty(ref this.selectedDate, value);
        }

        public DXCalendarViewType ActiveViewType {
            get => this.activeViewType;
            set => SetProperty(ref this.activeViewType, value, UpdateHolidaysAndObservancesListVisible);
        }

        public bool IsHolidaysAndObservancesListVisible {
            get => this.isHolidaysAndObservancesListVisible;
            set => SetProperty(ref this.isHolidaysAndObservancesListVisible, value);
        }

        USCalendar USCalendar { get; set; }

        public SpecialDate TryFindSpecialDate(DateTime date) {
            return SpecialDates.FirstOrDefault(x => x.Date == date);
        }

        void UpdateHolidaysAndObservancesListVisible() {
            IsHolidaysAndObservancesListVisible = ActiveViewType == DXCalendarViewType.Month;
        }

        void UpdateCurrentCalendarIfNeeded() {
            if (USCalendar == null || USCalendar.Year != DisplayDate.Year)
                USCalendar = new USCalendar(DisplayDate.Year);
        }
    }
}
