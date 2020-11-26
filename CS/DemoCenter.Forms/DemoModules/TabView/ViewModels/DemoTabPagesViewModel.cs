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
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.DemoModules.Grid.Data;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class DemoTabPagesViewModel : NavigationViewModelBase {
        readonly Random rand;

        ObservableCollection<PhoneContact> contacts;
        public ObservableCollection<PhoneContact> Contacts {
            get => this.contacts;

            private set {
                this.contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        ObservableCollection<CallInfo> recent;
        public ObservableCollection<CallInfo> Recent {
            get => this.recent;
            private set {
                this.recent = value;
                OnPropertyChanged(nameof(Recent));
            }
        }

        public ObservableCollection<PhoneContact> Favorites => new ObservableCollection<PhoneContact>(Contacts.Where(c => c.Favorite));

        public DemoTabPagesViewModel() {
            this.rand = new Random();
            InitContacts();
        }

        private void InitContacts() {
            GridOrdersRepository repository = new GridOrdersRepository();
            IList<PhoneContact> customersList = repository.Customers.ToList().ConvertAll((customer) => new PhoneContact(customer));

            GenerateCallList(customersList);
            GenerateFavoritesList(customersList);
            Contacts = new ObservableCollection<PhoneContact>(customersList);
        }

        
        void GenerateCallList(IList<PhoneContact> contacts) {
            int recordsCount = this.rand.Next(2, 10);
            Recent = new ObservableCollection<CallInfo>();
            for (int i = 0; i < recordsCount; i++) {
                int randomData = this.rand.Next(2, 10);
                int randomTime = this.rand.Next(40, 620);
                Recent.Add(new CallInfo() {
                    Date = DateTime.UtcNow.AddDays(-randomData).AddMinutes(randomTime),
                    CallType = (CallType)((randomTime - randomData) % 3),
                    Contact = contacts[(randomData + randomTime) % contacts.Count]
                });
            }
        }

        void GenerateFavoritesList(IList<PhoneContact> contacts) {
            int recordsCount = this.rand.Next(5, 15);
            for (int i = 0; i < recordsCount; i++) {
                int randomContactNum = this.rand.Next(0, contacts.Count - 1);
                contacts[randomContactNum].Favorite = true;
            }
        }
    }
    public class PhoneContact : Customer {
        Color contactColor = Color.Default;

        public PhoneContact(string name) : base(name) { }
        public PhoneContact(Customer customer) : base(customer.Name) {
            Id = customer.Id;
            Notes = customer.Notes;
            Phone = customer.Phone;
            Photo = customer.Photo;
            Email = customer.Email;
            BirthDate = customer.BirthDate;
        }
        public bool HasPhoto { get; } = new Random().Next(0, 18) % 3 == 0;
        public bool Favorite { get; set; }
        public Color CategoryColor => GetContactColor();
        public string Initials => Name.Substring(0, 1) + Name.Split(null)[1].Substring(0, 1);

        internal Color GetContactColor() {
            if (this.contactColor == Color.Default) {
                this.contactColor = ContactColors.GetRandomColor();
            }
            return this.contactColor;
        }
    }
    public class CallInfo {
        public DateTime Date { get; set; }
        public CallType CallType { get; set; }
        public string Name => Contact?.Name;
        public string Phone => Contact?.Phone;
        public Color CategoryColor => Contact != null ? Contact.CategoryColor : Color.Default;
        public string Initials => Contact?.Initials;
        public PhoneContact Contact { get; set; }
    }
    public enum CallType {
        Incoming,
        Outgoing,
        Missed
    }
}
