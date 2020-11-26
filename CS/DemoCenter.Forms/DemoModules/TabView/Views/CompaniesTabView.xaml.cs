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
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class CompaniesTabView : ContentPage {
        public CompaniesTabView() {
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            InitializeComponent();
            BindingContext = new CompaniesTabViewModel();
        }

        void UpdateSizeChanged(object sender, EventArgs e) {
            Image image = (Image)sender;
            ResizeImageParent(image);

            if (Device.Idiom == TargetIdiom.Tablet)
                UpdateItemSize(image.Width);
        }

        void ResizeImageParent(Image image) {
            Grid parent = (Grid)image.Parent;

            double summaryHeight = 0;
            foreach (View subView in parent.Children)
                summaryHeight += subView.Height + subView.Margin.Top + subView.Margin.Bottom;
            summaryHeight += parent.RowSpacing * (parent.Children.Count - 1);

            if (summaryHeight > 0) {
                parent.HeightRequest = summaryHeight;
                parent.LayoutTo(new Rectangle(parent.Bounds.Left, parent.Bounds.Top, parent.Width, summaryHeight));
            }
        }

        void UpdateItemSize(double width) {
            int count = this.tabControl.Items.Count;

            if (count != 0) {
                double itemWidth = width / count;
                for (int i = 0; i < count; i++)
                    this.tabControl.Items[i].HeaderWidth = itemWidth;
            }
        }
    }
}
