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
using System;
using System.Collections.Generic;
using DemoCenter.Forms.Data;
using DevExpress.XamarinForms.Charts;

namespace DemoCenter.Forms.ViewModels {
    public class LineChartViewModel : ChartViewModelBase {
        readonly TrendPopulationData trendPopulationData = new TrendPopulationData();

        public override string Title => "Historic, Current and Future Population";

        public DataSetContainer<DateTimeData> Europe => trendPopulationData.Europe;
        public DataSetContainer<DateTimeData> Americas => trendPopulationData.Americas;
        public DataSetContainer<DateTimeData> Africa => trendPopulationData.Africa;

        public DateTime CurrentDate => DateTime.Now;
    }

    public class ScatterLineChartViewModel : ChartViewModelBase {
        readonly ArchimedeanSpiralSeriesData seriesData = new ArchimedeanSpiralSeriesData();

        public override string Title => "Function in Cartesian Coordinates";
        public ArchimedeanSpiralSeriesData SeriesData => seriesData;
    }

    public class StepLineChartViewModel : ChartViewModelBase {
        readonly AverageDieselPricesData chartData = new AverageDieselPricesData();

        public override string Title => "U.S. Average Diesel Prices";
        public DataSetContainer<DateTimeData> DieselPrices => chartData.DieselPrices;
    }

    public class SplineChartViewModel : ChartViewModelBase {
        readonly SplineData chartData = new SplineData();
        readonly DateTimeRange visualRange;

        public DateTimeRange VisualRange => visualRange;
        public override string Title => "Energy Released by Earthquakes";
        public IList<DateTimeData> SeriesData => chartData.SeriesData;

        public SplineChartViewModel() {
            visualRange = new DateTimeRange() { VisualMin = new DateTime(1999, 1, 1), VisualMax = new DateTime(1999, 5, 1), SideMargin = 10 };
        }
    }
}
