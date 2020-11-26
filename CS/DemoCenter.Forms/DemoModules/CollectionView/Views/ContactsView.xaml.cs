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
﻿using System.Threading.Tasks;
using DemoCenter.Forms.DemoModules.TabView.Pages;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.CollectionView;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class ContactsView : ContentPage {
        bool inNavigation = false;

        public ContactsView() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();
            BindingContext = new ContactsViewModel();
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
    }

    public class ContactItemTemplateSelector : DataTemplateSelector {
        public DataTemplate PhotoTemplate { get; set; }
        public DataTemplate IconTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is PhoneContact contact)
                return contact.HasPhoto ? PhotoTemplate : IconTemplate;
            if (item is CallInfo callInfo)
                return callInfo.Contact.HasPhoto ? PhotoTemplate : IconTemplate;

            return IconTemplate;
        }
    }
}
