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
using DemoCenter.Forms.Charts.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms {
    class AreaChartTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is AreaChartItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.AreaType) {
                case AreaType.Range: return RangeAreaChartTemplate;
                case AreaType.Simple: return AreaChartTemplate;
                case AreaType.Stacked: return StackedAreaChartTemplate;
                case AreaType.FullStacked: return FullStackedAreaChartTemplate;
                case AreaType.Step: return StepAreaChartTemplate;
                default: throw new ArgumentException("The selector cannot handle the passed BarType value.");
            }
        }

        public DataTemplate RangeAreaChartTemplate { get; set; }
        public DataTemplate AreaChartTemplate { get; set; }
        public DataTemplate StackedAreaChartTemplate { get; set; }
        public DataTemplate FullStackedAreaChartTemplate { get; set; }
        public DataTemplate StepAreaChartTemplate { get; set; }
    }

    class BarChartTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is BarChartItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.BarType) {
                case BarType.SideBySideRange: return SideBySideRangeBarChartTemplate;
                case BarType.Range: return RangeBarChartTemplate;
                case BarType.Simple: return BarChartTemplate;
                case BarType.PopulationPyramid: return PopulationPyramidTemplate;
                case BarType.Stacked: return StackedBarChartTemplate;
                case BarType.SideBySideStacked: return SideBySideStackedBarChartTemplate;
                case BarType.FullStacked: return FullStackedBarChartTemplate;
                case BarType.SideBySideFullStacked: return SideBySideFullStackedBarChartTemplate;
                case BarType.RotatedStacked: return RotatedStackedBarChartTemplate;
                case BarType.RotatedSideBySide: return RotatedSideBySideStackedBarChartTemplate;
                default: throw new ArgumentException("The selector cannot handle the passed BarType value.");
            }
        }

        public DataTemplate SideBySideRangeBarChartTemplate { get; set; }
        public DataTemplate RangeBarChartTemplate { get; set; }
        public DataTemplate BarChartTemplate { get; set; }
        public DataTemplate PopulationPyramidTemplate { get; set; }
        public DataTemplate FullStackedBarChartTemplate { get; set; }
        public DataTemplate RotatedSideBySideStackedBarChartTemplate { get; set; }
        public DataTemplate RotatedStackedBarChartTemplate { get; set; }
        public DataTemplate SideBySideFullStackedBarChartTemplate { get; set; }
        public DataTemplate SideBySideStackedBarChartTemplate { get; set; }
        public DataTemplate StackedBarChartTemplate { get; set; }
    }

    class LineChartTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is LineChartItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.LineType) {
                case LineType.Simple: return LineChartTemplate;
                case LineType.Scatter: return ScatterChartTemplate;
                case LineType.Step: return StepLineChartTemplate;
                case LineType.Spline: return SplineChartTemplate;
                default: throw new ArgumentException("The selector cannot handle the passed LineType value.");
            }
        }

        public DataTemplate LineChartTemplate { get; set; }
        public DataTemplate ScatterChartTemplate { get; set; }
        public DataTemplate StepLineChartTemplate { get; set; }
        public DataTemplate SplineChartTemplate { get; set; }
    }

    class PieChartTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is PieChartItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.PieType) {
                case PieType.Donut: return DonutChartTemplate;
                case PieType.Pie: return PieChartTemplate;
                default: throw new ArgumentException("The selector cannot handle the passed PieType value.");
            }
        }

        public DataTemplate DonutChartTemplate { get; set; }
        public DataTemplate PieChartTemplate { get; set; }
    }

    class PointChartTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is PointChartItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.PointType) {
                case PointType.Bubble: return BubbleChartTemplate;
                case PointType.Point: return PointChartTemplate;
                default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public DataTemplate BubbleChartTemplate { get; set; }
        public DataTemplate PointChartTemplate { get; set; }
    }

    class ColorizerTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is ColorizerItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.CustomAppearanceModuleType) {
                case CustomAppearanceType.AreaGradientFillEffect: return AreaGradientFillEffectTemplate;
                case CustomAppearanceType.Bubble: return BubbleColorizerTemplate;
                case CustomAppearanceType.Bar: return BarColorizerTemplate;
                case CustomAppearanceType.OperationSurfaceTemperature: return OperationSurfaceTemperatureTemplate;
                case CustomAppearanceType.GradientSegmentColorizer: return GradientSegmentColorizerTemplate;
                default:throw new ArgumentException("The selector cannot handle the passed ColorizerType value.");
            }
        }

        public DataTemplate AreaGradientFillEffectTemplate { get; set; }
        public DataTemplate BubbleColorizerTemplate { get; set; }
        public DataTemplate BarColorizerTemplate { get; set; }
        public DataTemplate OperationSurfaceTemperatureTemplate { get; set; }
        public DataTemplate GradientSegmentColorizerTemplate { get; set; }
    }

    class LabelModeTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is AxisLabelOptionsItemInfoContainer infoContainer))
                return null;

            switch (infoContainer.LabelModeType) {
                case AxisLabelOptionsType.RotatedAndStaggered: return RotatedLabelTemplate;
                case AxisLabelOptionsType.CryptocurrencyPortfolio: return CryptocurrencyPortfolioTemplate;
                default:
                    throw new ArgumentException("The selector cannot handle the passed LabelModeType value.");
            }
        }

        public DataTemplate RotatedLabelTemplate { get; set; }
        public DataTemplate CryptocurrencyPortfolioTemplate { get; set; }
    }
}
