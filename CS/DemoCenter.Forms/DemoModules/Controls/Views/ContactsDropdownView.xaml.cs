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
﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Forms.DemoModules.TabView.Pages;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.CollectionView;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Popup.Views {
    public partial class ContactsDropdownView : ContentPage {

        ContactsDropdownViewModel viewModel = new ContactsDropdownViewModel();
        bool inNavigation = false;

        public ActiveItemCommand ItemCommand { get; }

        public ContactsDropdownView() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();

            BindingContext = this.viewModel;
            ItemCommand = new ActiveItemCommand(this.viewModel);
        }

         protected override void OnAppearing() {
            base.OnAppearing();
            this.inNavigation = false;
        }

        public async void ItemSelected(object sender, CollectionViewGestureEventArgs args) {
            if (args.Item != null)
                await OpenDetailPage(GetContactInfo(args.Item));
        }

        private PhoneContact GetContactInfo(object item) {
            if (item is CallInfo callInfo)
                return callInfo?.Contact;
            return null;
        }

        Task OpenDetailPage(PhoneContact contact) {
            if (contact == null)
                return Task.CompletedTask;

            if (this.inNavigation)
                return Task.CompletedTask;

            this.inNavigation = true;
            return Navigation.PushAsync(new ContactDetailPage(contact));
        }

        void OnRemoveClick(object sender, EventArgs e) {
            ItemCommand.RemoveFromList();
            this.viewModel.IsOpenPopup = false;
        }

        void OnCallClick(object sender, EventArgs e) {
            ItemCommand.CallNow();
            this.viewModel.IsOpenPopup = false;
        }

        void OnContactClick(object sender, EventArgs e) {
            this.viewModel.PlacementTarget = sender;
            this.viewModel.IsOpenPopup = !this.viewModel.IsOpenPopup;
        }
    }

    public class ActiveItemCommand: ICommand {
        public event EventHandler CanExecuteChanged;

        readonly ContactsDropdownViewModel vm;
        CallInfo activeItem;

        public ActiveItemCommand(ContactsDropdownViewModel vm) {
            this.vm = vm;
        }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter) {
            this.activeItem = parameter as CallInfo;
        }

        public void RemoveFromList() {
            this.vm.Recent.Remove(this.activeItem);
        }

        public void CallNow() {
            this.vm.Recent.Remove(this.activeItem);
            this.activeItem.Date = DateTime.Now;
            this.activeItem.CallType = CallType.Outgoing;
            this.vm.Recent.Add(this.activeItem);
        }
    }
}
