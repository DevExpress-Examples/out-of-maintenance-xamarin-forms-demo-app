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
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.DataGrid;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class CustomAppearanceView : BaseGridContentPage {
        public CustomAppearanceView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return SalesDataGenerator.CreateData();
        }

        void DataGridView_CustomCellStyle(object sender, CustomCellStyleEventArgs e) {
            if(e.RowHandle % 2 == 0)
                e.BackgroundColor = GetColorFromResource("GridCustomAppearanceOddRowBackgroundColor");
            e.FontColor = GetColorFromResource("GridCustomAppearanceFontColor");
            if(e.FieldName == "ActualSales" || e.FieldName == "TargetSales") {
                double value = (double)dataGridView.GetCellValue(e.RowHandle, e.FieldName);
                if(value > 7000000)
                    e.FontColor = GetColorFromResource("GridCustomAppearancePositiveFontColor");
                else if (value < 4000000)
                    e.FontColor = GetColorFromResource("GridCustomAppearanceNegativeFontColor");
            }
        }

        Color GetColorFromResource(string resourceName) {
            return (Color)Application.Current.Resources[resourceName];
        }
    }
}
