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
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public class Customer : NotificationObject, IComparable<Customer>, IEquatable<Customer> {
        string name;

        public string Name {
            get => this.name;
            set {
                this.name = value;
                if (Photo == null) {
                    string resourceName = "DemoCenter.Forms.DemoModules.Grid.Images." + value.Replace(" ", "_") + ".jpg";
                    if (!String.IsNullOrEmpty(resourceName))
                        Photo = ImageSource.FromResource(resourceName);
                }
            }
        }

        public Customer() {
        }

        public Customer(string name) {
            Name = name;
        }

        public int Id { get; set; }
        public ImageSource Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }

        public int CompareTo(Customer other) {
            return Comparer<string>.Default.Compare(Name, other.Name);
        }

        bool IEquatable<Customer>.Equals(Customer other) {
            return Name == other.Name;
        }

        public Customer Clone() {
            Customer result = new Customer(Name) {
                Id = Id,
                BirthDate = BirthDate,
                HireDate = HireDate,
                Position = Position,
                Address = Address,
                Phone = Phone,
                Notes = Notes,
                Email = Email
            };

            return result;
        }
    }
}
