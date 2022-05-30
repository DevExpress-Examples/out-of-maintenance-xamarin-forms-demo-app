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
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class BarChartViewModel : ChartViewModelBase {
        readonly PopulationStructureData chartData = new PopulationStructureData();

        public override string Title => "Population Structure";
        public DataSetContainer<QualitativeData> MaleSeriesData => chartData.MaleSeriesData;
        public DataSetContainer<QualitativeData> FemaleSeriesData => chartData.FemaleSeriesData;
    }

    public class RangeBarChartViewModel : ChartViewModelBase {
        readonly RangeBarData chartData = new RangeBarData();
        readonly DateTimeRange visualRange;

        public DateTimeRange VisualRange => visualRange;
        public override string Title => "Crude Oil Prices in 2019";
        public List<RangeDateTimeData> WTISeriesData => chartData.SeriesData[0];
        public List<RangeDateTimeData> BrentSeriesData => chartData.SeriesData[1];

        public RangeBarChartViewModel() {
            visualRange = new DateTimeRange() { VisualMin = new System.DateTime(2019, 2, 1), VisualMax = new System.DateTime(2019, 9, 1) };
        }
    }

    public class SideBySideRangeBarChartViewModel : ChartViewModelBase {
        readonly SideBySideRangeBarData chartData = new SideBySideRangeBarData();
        readonly DateTimeRange visualRange;

        public DateTimeRange VisualRange => visualRange;
        public override string Title => "Crude Oil and Natural Gas Prices in 2019";
        public List<RangeDateTimeData> OilSeriesData => chartData.SeriesData[0];
        public List<RangeDateTimeData> GasSeriesData => chartData.SeriesData[1];

        public SideBySideRangeBarChartViewModel() {
            visualRange = new DateTimeRange() { VisualMin = new System.DateTime(2019, 2, 1), VisualMax = new System.DateTime(2019, 7, 1) };
        }
    }

    public class StackedBarChartViewModel : ChartViewModelBase {
        readonly AgeStructureData chartData = new AgeStructureData();

        public override string Title => "Age Structure";
        public DataSetContainer<QualitativeData> Male0to14and65SeriesData => chartData.Male0to14and65SeriesData;
        public DataSetContainer<QualitativeData> Male15to64SeriesData => chartData.Male15to64SeriesData;
    }

    public class SideBySideStackedBarChartViewModel : ChartViewModelBase {
        readonly AgeStructureData chartData = new AgeStructureData();
        Color[] palette = PaletteLoader.LoadPalette("#FF42A5F5", "#b342a5f5", "#FFFF5252", "#b3ff5252");

        public override string Title => "Age Structure";
        public Color[] Palette => palette;
        public DataSetContainer<QualitativeData> Male0to14and65SeriesData => chartData.Male0to14and65SeriesData;
        public DataSetContainer<QualitativeData> Male15to64SeriesData => chartData.Male15to64SeriesData;
        public DataSetContainer<QualitativeData> Female0to14and65SeriesData => chartData.Female0to14and65SeriesData;
        public DataSetContainer<QualitativeData> Female15to64SeriesData => chartData.Female15to64SeriesData;
    }

    public class FullStackedBarChartViewModel : ChartViewModelBase {
        readonly DevAVSalesMixByRegionData chartData = new DevAVSalesMixByRegionData();

        public override string Title => "DevAV Sales Mix By Region";
        public DataSetContainer<QualitativeData> ProjectorsSeriesData => chartData.ProjectorsSeriesData;
        public DataSetContainer<QualitativeData> TelevisionsSeriesData => chartData.TelevisionsSeriesData;
    }

    public class PopulationPyramidViewModel : ChartViewModelBase {
        readonly PopulationPyramidData chartData = new PopulationPyramidData();

        public override string Title => "Population Pyramid";
        public DataSetContainer<QualitativeData> PopulationPyramidMaleSeriesData => chartData.MaleSeriesData;
        public DataSetContainer<QualitativeData> PopulationPyramidFemaleSeriesData => chartData.FemaleSeriesData;
    }

    public class CryptocurrencyPortfolioViewModel : ChartViewModelBase {
        readonly CryptocurrencyPortfolioData chartData = new CryptocurrencyPortfolioData();

        public override string Title => "Cryptocurrency Portfolio";
        public DataSetContainer<QualitativeData> CryptocurrencyPortfolio => chartData.SymbolsData;
    }
}
