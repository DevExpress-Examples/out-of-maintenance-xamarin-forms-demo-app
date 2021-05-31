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
using System.Linq;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;

namespace DemoCenter.Forms.Data {
    public class SchedulerData : IDemoData {
        public static DemoItem GetItem(Type module) {
            IEnumerable<DemoItem> items = demoItems.Where((d) => d.Module == module);
            return items.Any() ? items.Last() : null;
        }

        static readonly List<DemoItem> demoItems;

        static SchedulerData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Day View",
                    Description="This is a detailed view of appointments for one or several days.",
                    Module = typeof(DayViewDemo),
                    Icon = "scheduler_dayview"},
                 new DemoItem() {
                    Title = "Work Week View",
                    Description="Displays appointments for working days in a week.",
                    Module = typeof(ReceptionDesk),
                    Icon = "scheduler_workweekview"},
                new DemoItem() {
                    Title = "Week View",
                    Description="Displays appointments for an entire week.",
                    Module = typeof(WeekViewDemo),
                    Icon = "scheduler_weekview"},
                new DemoItem() {
                    Title = "Month View",
                    Description="An overview of appointments for a month.",
                    Module = typeof(MonthViewDemo),
                    Icon = "scheduler_monthview"},
                new DemoItem() {
                    Title = "Reminders",
                    Description="Illustrates how to add reminders to appointments.",
                    Module = typeof(RemindersDemo),
                    Icon = "scheduler_reminders",
                    ShowItemUnderline = false},
            };
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title => "SchedulerView";
    }
}
