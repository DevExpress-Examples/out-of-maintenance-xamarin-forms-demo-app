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
﻿using System;
using System.Collections.Generic;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DemoCenter.Forms.Views;
using DevExpress.XamarinForms.DataGrid;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class HorizontalVirtualizationView : BaseGridContentPage {
        readonly double columnWidth = Device.Idiom == TargetIdiom.Tablet ? 180 : 150;

        public HorizontalVirtualizationView() {
            InitializeComponent();

            dataGridView.Columns.Add(new TextColumn() {
                FieldName = "Full Name",
                Width = columnWidth,
                FixedStyle = Device.Idiom == TargetIdiom.Tablet ? FixedStyle.Start : FixedStyle.None
            });
            for (int i = 0; i < 5; i++) {
                int year = DateTime.Now.Year - 5 + i;
                for (int j = 1; j < 5; j++) {
                    AddColumnAndSummary("Q" + j + ", " + year, columnWidth, "quaterColumnTemplate");
                }
                AddColumnAndSummary("" + year + " Total", columnWidth + 20, "yearTotalColumnTemplate");
            }
        }

        void AddColumnAndSummary(string fieldName, double width, string templateName) {
            dataGridView.Columns.Add(new TemplateColumn() {
                FieldName = fieldName,
                Width = width,
                HorizontalContentAlignment = TextAlignment.End,
                DisplayTemplate = (DataTemplate)Resources[templateName]
            });
            dataGridView.TotalSummaries.Add(new GridColumnSummary() { FieldName = fieldName, Type = SummaryType.Sum, DisplayFormat = "SUM={0:C2}" });
        }

        protected override object LoadData() {
            return new EmployeeSales();
        }
    }
}
