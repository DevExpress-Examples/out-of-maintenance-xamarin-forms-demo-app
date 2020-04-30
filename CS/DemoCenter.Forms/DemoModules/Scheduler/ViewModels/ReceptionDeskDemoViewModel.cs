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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DemoCenter.Forms.ViewModels {
    public class ReceptionDeskDemoViewModel: INotifyPropertyChanged {
        readonly ReceptionDeskData data = new ReceptionDeskData();
        Doctor selectedDoctor;
        IReadOnlyList<MedicalAppointment> visibleAppointments = new List<MedicalAppointment>();

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime StartDate { get { return ReceptionDeskData.BaseDate; } }
        public IReadOnlyList<Doctor> Doctors { get { return data.Doctors; } }
        public Doctor SelectedDoctor {
            get { return selectedDoctor; }
            set {
                selectedDoctor = value;
                VisibleAppointments = data.MedicalAppointments.Where(a => {
                    return a.DoctorId.HasValue && selectedDoctor?.Id == a.DoctorId.Value;
                }).ToList();
                NotifyPropertyChanged();
            }
        }
        public IReadOnlyList<MedicalAppointment> VisibleAppointments {
            get => visibleAppointments;
            private set {
                visibleAppointments = value;
                NotifyPropertyChanged();
            }
        }
        public IReadOnlyList<MedicalAppointmentType> AppointmentTypes { get => data.Labels; }
        public IReadOnlyList<PaymentState> PaymentStates { get => data.Statuses; }

        public ReceptionDeskDemoViewModel() {
            SelectedDoctor = Doctors.FirstOrDefault();
        }

        void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
