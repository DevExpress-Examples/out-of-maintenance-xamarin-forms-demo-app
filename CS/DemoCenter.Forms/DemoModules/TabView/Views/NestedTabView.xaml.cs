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
using System.ComponentModel;
using DemoCenter.Forms.DemoModules.TabView;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class NestedTabView : ContentPage {
       
        public NestedTabView() {
            this.BindingContext = new NestedTabViewModel();
            ((NestedTabViewModel)this.BindingContext).PropertyChanged += OnModelPropertyChanged;
            InitializeComponent();
        }
        void UpdateSizeChanged(Object sender, EventArgs e) {
            if (Device.Idiom == TargetIdiom.Tablet) {
                ListView list = (ListView)sender;
                if (list != null)
                    UpdateItemSize(list.Width);
            }
        }

        void UpdateItemSize(double width) {
            int count = nestedTabView.Items.Count;
            if (count != 0) {
                double itemWidth = (width - (nestedTabView.HeaderPanelItemSpacing * (count-1))) / count;
                for (int i = 0; i < count; i++)
                    nestedTabView.Items[i].HeaderWidth = itemWidth;
            }
        }
        void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
            OnPropertyChanged(e.PropertyName);
        }

    }
}