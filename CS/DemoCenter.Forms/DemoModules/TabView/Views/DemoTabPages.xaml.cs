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
using System.Globalization;
using System.Threading.Tasks;
using DemoCenter.Forms.DemoModules.TabView.Pages;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.DataGrid;
using DevExpress.XamarinForms.Navigation;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class DemoTabPages : TabPage {
        public DemoTabPages() {
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            BindingContext = new DemoTabPagesViewModel();
            InitializeComponent();
        }

        public async void On_ItemSelected(object sender, DataGridGestureEventArgs args) {
            if (args.Item != null)
                await OpenDetailPage(GetContactInfo(args.Item));
        }

        private PhoneContact GetContactInfo(object item) {
            if (item is PhoneContact contact)
                return contact;
            if (item is CallInfo callInfo)
                return callInfo?.Contact;
            return null;
        }

        Task OpenDetailPage(PhoneContact contact) {
            if (contact == null)
                return Task.CompletedTask;
            return Navigation.PushAsync(new ContactDetailPage(contact));
        }
    }

    public class UpperCaseConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            return value?.ToString().ToUpperInvariant();
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return value?.ToString().ToLowerInvariant();
        }
    }

    public class CallTypeToIconConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                             object parameter, CultureInfo culture) {
            return String.Format("demotabview_{0}", value.ToString().ToLowerInvariant());
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return null;
        }
    }

    public class ContactIconTemplateSelector : DataTemplateSelector {
        public DataTemplate PhotoTemplate { get; set; }
        public DataTemplate IconTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is CellData gridData)
                return OnSelectTemplate(gridData.Item, container);
            if (item is PhoneContact contact)
                return contact.HasPhoto ? PhotoTemplate : IconTemplate;
            if (item is CallInfo callInfo)
                return OnSelectTemplate(callInfo.Contact, container);
            return IconTemplate;
        }
    }
}
