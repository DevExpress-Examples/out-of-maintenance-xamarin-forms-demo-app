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
using System.Collections.Generic;
using DemoCenter.Forms.Data;

namespace DemoCenter.Forms.ViewModels {
    public class AreaChartViewModel : ChartViewModelBase {
        readonly OutsideVendorCostsData chartData = new OutsideVendorCostsData();

        public override string Title => "Vendor Costs";
        public DataSetContainer<DateTimeData> DevAVNorth => chartData.DevAVNorth;
        public DataSetContainer<DateTimeData> DevAVSouth => chartData.DevAVSouth;
    }

    public class RangeAreaChartViewModel : ChartViewModelBase {
        readonly RangeAreaData chartData = new RangeAreaData();

        public override string Title => "Richmond vs Houston Temperatures";
        public List<RangeDateTimeData> RichmondWeatherData => chartData.SeriesData[0];
        public List<RangeDateTimeData> HoustonWeatherData => chartData.SeriesData[1];
    }

    public class StackedAreaChartViewModel : ChartViewModelBase {
        readonly SalesByLastYearsData chartData = new SalesByLastYearsData();

        public override string Title => "DevAV Sales";
        public DataSetContainer<DateTimeData> NorthAmerica => chartData.NorthAmerica;
        public DataSetContainer<DateTimeData> Europe => chartData.Europe;
        public DataSetContainer<DateTimeData> Australia => chartData.Australia;
    }

    public class FullStackedAreaChartViewModel : ChartViewModelBase {
        readonly BranchesSalesData chartData = new BranchesSalesData();

        public override string Title => "Market Share Over Time";
        public DataSetContainer<DateTimeData> DevAVEast => chartData.DevAVEast;
        public DataSetContainer<DateTimeData> DevAVWest => chartData.DevAVWest;
        public DataSetContainer<DateTimeData> DevAVSouth => chartData.DevAVSouth;
        public DataSetContainer<DateTimeData> DevAVCenter => chartData.DevAVCenter;
        public DataSetContainer<DateTimeData> DevAVNorth => chartData.DevAVNorth;
    }

    public class StepAreaChartViewModel : ChartViewModelBase {
        readonly AverageDieselPricesData chartData = new AverageDieselPricesData();

        public override string Title => "U.S. Average Diesel Prices";
        public DataSetContainer<DateTimeData> DieselPrices => chartData.DieselPrices;
    }
}
