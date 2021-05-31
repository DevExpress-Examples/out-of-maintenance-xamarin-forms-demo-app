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
﻿using System;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace DemoCenter.Forms {
    class SeriesTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(container is SeriesTemplateAdapter adapter))
                return null;

            return adapter.SeriesDataMember == "Country" ? YearSeriesTemplate : CountrySeriesTemplate;
        }

        public DataTemplate YearSeriesTemplate { get; set; }
        public DataTemplate CountrySeriesTemplate { get; set; }
    }
}

namespace DemoCenter.Forms.Views {
    public partial class SeriesTemplate : ContentPage {
        readonly string[] members = { "Year", "Country" };

        public SeriesTemplate() {
            InitializeComponent();
        }

        async void OnItemClicked(System.Object sender, System.EventArgs e) {
            SeriesTemplateViewModel viewModel = (SeriesTemplateViewModel) BindingContext;
            
            string action = await DisplayActionSheet("Data Source Field", "Cancel", null, members);
            if (!String.IsNullOrEmpty(action) && action != "Cancel" && action != viewModel.SeriesDataMember) {
                viewModel.SeriesDataMember = action;
                viewModel.ArgumentDataMember = action == members[0] ? members[1] : members[0];
            }
        }
    }
}
