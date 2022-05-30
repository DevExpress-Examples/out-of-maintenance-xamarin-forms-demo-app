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
using System.Windows.Input;
using DemoCenter.Forms.Data;
using DevExpress.XamarinForms.Charts;

namespace DemoCenter.Forms.ViewModels {
    public class LargeDatasetViewModel : ChartViewModelBase {
        readonly AddSeriesCommand addSeriesCommand;
        readonly ChartView chart;

        int totalPointsCount;
        public int TotalPointsCount {
            get { return totalPointsCount; }
            set { SetProperty(ref totalPointsCount, value); }
        }
        public AddSeriesCommand AddSeries { get => addSeriesCommand; }

        public LargeDatasetViewModel(ChartView chart)
        {
            this.chart = chart;
            addSeriesCommand = new AddSeriesCommand((pointCount) => {
                LineSeries lineSeries = new LineSeries();
                lineSeries.Style = new LineSeriesStyle() { StrokeThickness = 1 };
                lineSeries.Data = new LargeDatasetSeriesData(pointCount);
                this.chart.Series.Add(lineSeries);
                TotalPointsCount += pointCount;
            });
            AddSeries.Execute(100000);
        }
    }

    public class AddSeriesCommand : ICommand {
        readonly Action<int> action;
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public AddSeriesCommand(Action<int> action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action(Convert.ToInt32(parameter));
    }
}
