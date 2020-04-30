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
using System.Collections.Generic;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.Views;

namespace DemoCenter.Forms.Data {
    public class ChartsData: IDemoData {
        readonly List<DemoItem> demoItems;

        public ChartsData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Spectrum Analyzer",
                    Description="Shows multiple charts that allow real-time frequency spectrum analysis.",
                    Module = typeof(SpectrumAnalyzer),
                    Icon = "ChartsList.SpectrumAnalyzer.svg",
                    DemoItemStatus = DemoItemStatus.New},
                new DemoItem() {
                    Title = "Logarithmic Scale",
                    Description = "Demonstrates a chart axis that uses the logarithmic scale to display numeric values.",
                    Module = typeof(LogarithmicScale),
                    Icon = "ChartsList.Headphones.svg",
                    DemoItemStatus = DemoItemStatus.New},
                new DemoItem() {
                    Title = "Oscillator",
                    Description="Demonstrates how the chart performs full data updates in real time.",
                    Module = typeof(Oscillator),
                    Icon = "ChartsList.Oscillator.svg",
                    DemoItemStatus = DemoItemStatus.New},
                new DemoItem() {
                    Title = "Financial" + Environment.NewLine + "Chart",
                    ControlsPageTitle = "Financial Chart",
                    Description="Displays Open-High-Low-Close stock price statistics as Candles Bars.",
                    Module = typeof(FinancialChart),
                    Icon = "ChartsList.FinancialCharts.svg"},
                new DemoItem() {
                    Title = "Real-Time Data Updates",
                    Description="Displays an auto-refreshed Line Chart bound to a frequently updated dataset.",
                    Module = typeof(RealTimeData),
                    Icon = "ChartsList.RealTimeUpdates.svg"},
                new DemoItem() {
                    Title = "Selection",
                    Description="Demonstrates support for series and point selection within a chart.",
                    Module = typeof(Selection),
                    Icon = "ChartsList.Selection.svg"},
                new DemoItem() {
                    Title = "Multiple Axes",
                    Description="Demonstrates multiple axes within a single chart.",
                    Module = typeof(MultipleAxes),
                    Icon = "ChartsList.MultipleAxes.svg"},
                new DemoItem() {
                    Title = "Large" + Environment.NewLine + "Dataset",
                    ControlsPageTitle = "Large Dataset",
                    Description="Demonstrates the speed with which DevExpress Charts can render a large number of points.",
                    Module = typeof(LargeDataset),
                    Icon = "ChartsList.LargeDataset.svg"},
                new DemoItem() {
                    Title = "Bar" + Environment.NewLine + "Charts",
                    ControlsPageTitle = "Bar Charts",
                    Description="Demonstrates Stacked and Side-by-Side Bar series chart views.",
                    Module = typeof(BarCharts),
                    Icon = "ChartsList.BarCharts.svg",
                    DemoItemStatus = DemoItemStatus.Updated},
                new DemoItem() {
                    Title = "Line" + Environment.NewLine + "Charts",
                    ControlsPageTitle = "Line Charts",
                    Description="Demonstrates use of Simple, Scatter, and Step Line chart series views.",
                    Module = typeof(LineCharts),
                    Icon = "ChartsList.LineCharts.svg",
                    DemoItemStatus = DemoItemStatus.Updated},
                new DemoItem() {
                    Title = "Point & Bubble" + Environment.NewLine + "Charts",
                    ControlsPageTitle = "Point & Bubble Charts",
                    Description="Demonstrates the use of Point and Bubble chart series views.",
                    Module = typeof(PointsCharts),
                    Icon = "ChartsList.PointandBubleCharts.svg"},
                new DemoItem() {
                    Title = "Area" + Environment.NewLine + "Charts",
                    ControlsPageTitle = "Area Charts",
                    Description="Demonstrates Simple, Stacked and Step Area chart series views.",
                    Module = typeof(AreaCharts),
                    Icon = "ChartsList.AreaCharts.svg",
                    DemoItemStatus = DemoItemStatus.Updated},
                new DemoItem() {
                    Title = "Pie & Donut" + Environment.NewLine + "Charts",
                    ControlsPageTitle = "Pie & Donut Charts",
                    Description="Demonstrates the use of multi-series Pie and Donut chart views.",
                    Module = typeof(PieCharts),
                    Icon = "ChartsList.PieandDonutCharts.svg",
                    ShowItemUnderline = false},
            };
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title { get { return "ChartView"; } }
    }
}
