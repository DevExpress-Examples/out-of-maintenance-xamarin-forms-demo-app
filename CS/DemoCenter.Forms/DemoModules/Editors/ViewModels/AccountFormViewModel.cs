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
using System.Text.RegularExpressions;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Editors;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class AccountFormViewModel : NotificationObject {
        BoxMode selectedBoxMode;
        public BoxMode SelectedBoxMode {
            get { return selectedBoxMode; }
            set { SetProperty(ref selectedBoxMode, value); }
        }

        string notes = "";
        public string Notes {
            get { return notes; }
            set { SetProperty(ref notes, value); }
        }
        bool notesHasError = false;
        public bool NotesHasError {
            get { return notesHasError; }
            set { SetProperty(ref notesHasError, value); }
        }

        string email;
        public string Email {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        bool emailHasError = false;
        public bool EmailHasError {
            get { return emailHasError; }
            set { SetProperty(ref emailHasError, value); }
        }

        DateTime? birthDate;
        public DateTime? BirthDate {
            get { return birthDate; }
            set { SetProperty(ref birthDate, value); }
        }

        bool birthDateHasError = false;
        public bool BirthDateHasError {
            get { return birthDateHasError; }
            set { SetProperty(ref birthDateHasError, value); }
        }

        string phone;
        public string Phone {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        bool phoneHasError = false;
        public bool PhoneHasError {
            get { return phoneHasError; }
            set { SetProperty(ref phoneHasError, value); }
        }

        string login = "";
        public string Login {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        bool loginHasError = false;
        public bool LoginHasError {
            get { return loginHasError; }
            set { SetProperty(ref loginHasError, value); }
        }

        string password = "";
        public string Password {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        bool passwordHasError = false;
        public bool PasswordHasError {
            get { return passwordHasError; }
            set { SetProperty(ref passwordHasError, value); }
        }

        public IList<BoxMode> BoxModes { get; }

        public AccountFormViewModel() {
            BoxModes = new List<BoxMode> {
                BoxMode.Outlined,
                BoxMode.Filled
            };
            SelectedBoxMode = BoxModes[0];
        }

        public bool Validate() {
            EmailHasError = string.IsNullOrEmpty(Email);
            LoginHasError = string.IsNullOrEmpty(Login);
            PasswordHasError = !CheckPassword();
            BirthDateHasError = BirthDate == null;
            PhoneHasError = Phone == null || Phone.Length != 10;
            NotesHasError = Notes.Length > 100;
            return !(NotesHasError || PhoneHasError || EmailHasError || LoginHasError || PasswordHasError);
        }

        bool CheckPassword() {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,}$");
        }
    }
}
