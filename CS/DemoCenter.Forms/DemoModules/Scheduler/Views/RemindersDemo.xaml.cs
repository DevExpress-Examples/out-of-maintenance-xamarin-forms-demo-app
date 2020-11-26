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
using System.Threading.Tasks;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Scheduler;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class RemindersDemo : ContentPage {
        readonly Random rnd = new Random();
        readonly RemindersNotificationCenter remindersNotificationCenter = new RemindersNotificationCenter();
        readonly RemindersDemoViewModel viewModel = new RemindersDemoViewModel();
        bool inNavigation = false;

        public RemindersDemo() {
            Initializer.Init();
            InitializeComponent();
            BindingContext = viewModel;
        }

        public async void OpenAppointmentEditForm(Guid reminderId, int recurrenceIndex) {
            AppointmentItem appointment = storage.FindAppointmentByReminder(reminderId);
            if (appointment != null && recurrenceIndex >= 0)
                appointment = storage.GetOccurrenceOrException(appointment, recurrenceIndex);
            if (appointment != null)
                await OpenAppointmentEditForm(appointment);
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }

        Task OpenAppointmentEditForm(Page appointmentPage) {
            inNavigation = true;
            return Navigation.PushAsync(appointmentPage);
        }
        Task OpenAppointmentEditForm(AppointmentItem appointment) {
            return OpenAppointmentEditForm(new AppointmentDetailPage(appointment, storage, true));
        }

        void OnRemindersChanged(object sender, EventArgs e) {
            remindersNotificationCenter.UpdateNotifications(storage);
        }

        void OnClicked(object sender, EventArgs e) {
            AppointmentItem appointmentWithReminder = storage.CreateAppointmentItem();            
            DateTime start = DateTime.Now.AddSeconds(30);
            appointmentWithReminder.Start = start;
            appointmentWithReminder.End = start.AddHours(1);
            appointmentWithReminder.Subject = "Appointment with Reminder";
            appointmentWithReminder.LabelId = rnd.Next(0, storage.LabelItems.Count - 1);
            appointmentWithReminder.StatusId = rnd.Next(0, storage.StatusItems.Count - 1);
            appointmentWithReminder.Reminders.Add(new TimeSpan());
            storage.AppointmentItems.Add(appointmentWithReminder);
        }
        
        async void OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation)
                return;
            Page appointmentPage = storage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                inNavigation = true;
                await Navigation.PushAsync(appointmentPage);
            }
        }
    }
}
