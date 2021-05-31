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
using System.Xml.Serialization;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.Data {
    public class PhoneListData : List<GroupedPhoneList> {
        public PhoneListData(int capacity) : base(capacity) {
        }
    }
    public class GroupedPhoneList: NotificationObject {
        bool isSelected;
        public string GroupName { get; set; }
        public ImageSource GroupIconSource { get; set; }
        public bool ShowGroupIcon { get; set; }
        public PhoneList Contacts { get; set; }
        public bool IsSelected {
            get => this.isSelected;
            set => SetProperty(ref this.isSelected, value);
        }
    }

    [XmlRoot(ElementName = "PhoneListData")]
    public class PhoneList : List<Contact> {
    }

    public class Contact {
        Color contactColor = Color.Default;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => String.Format("{0} {1}", FirstName, LastName);
        public string Phone { get; set; }
        public string ContactCategory { get; set; }
        public string Initials => FirstName.Substring(0, 1) + LastName.Substring(0, 1);
        public Color CategoryColor => GetContactColor();

        internal Color GetContactColor() {
            if (this.contactColor == Color.Default) {
                this.contactColor = ContactColors.GetRandomColor();
            }
            return this.contactColor;
        }
    }
    public class ContactColors {
        public static Color GetRandomColor() {
            return GetColor(new Random().Next(10));
        }

        public static Color GetColor(int colorNumber) {
            switch(colorNumber) {
                case 1: return Color.FromHex("#f15558");
                case 2: return Color.FromHex("#ff7c11");
                case 3: return Color.FromHex("#ffbf22");
                case 4: return Color.FromHex("#ff6e86");
                case 5: return Color.FromHex("#9865b0");
                case 6: return Color.FromHex("#756cfd");
                case 7: return Color.FromHex("#0055d8");
                case 8: return Color.FromHex("#01b0ee");
                case 9: return Color.FromHex("#0097ad");
                case 0: return Color.FromHex("#00c831");
                default: return Color.FromHex("#949494");
            }
        }
    }
    public enum GroupParameterName {
        Category,
        Alphabeticaly
    }
}
