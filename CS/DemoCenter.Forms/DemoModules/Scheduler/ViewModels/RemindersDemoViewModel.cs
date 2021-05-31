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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DemoCenter.Forms.ViewModels {
    public class RemindersDemoViewModel {
        public RemindersDemoViewModel() {
            Appointments = new ObservableCollection<ReminderAppointment>(AppointmentRepository.Instance.GetItems());
            Appointments.CollectionChanged += OnAppointmentsCollectionChanged;
            foreach(ReminderAppointment appointment in Appointments)
                SubscribeAppointmentEvent(appointment);
        }

        void OnAppointmentsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null)
                foreach (ReminderAppointment obj in e.OldItems) {
                    UnSubscribeAppointmentEvent(obj);
                    AppointmentRepository.Instance.DeleteItem(obj.Id);
                }

            if (e.NewItems != null)
                foreach (ReminderAppointment obj in e.NewItems) {
                    SubscribeAppointmentEvent(obj);
                    AppointmentRepository.Instance.SaveItem(obj);
                }
        }

        public ObservableCollection<ReminderAppointment> Appointments { get; protected set; }

        void SubscribeAppointmentEvent(ReminderAppointment apt) {
            apt.PropertyChanged += OnAppointmentPropertyChanged;
        }
        void UnSubscribeAppointmentEvent(ReminderAppointment apt) {
            apt.PropertyChanged -= OnAppointmentPropertyChanged;
        }
        void OnAppointmentPropertyChanged(object sender, PropertyChangedEventArgs e) {
            AppointmentRepository.Instance.SaveItem(sender as ReminderAppointment);
        }
    }
}
