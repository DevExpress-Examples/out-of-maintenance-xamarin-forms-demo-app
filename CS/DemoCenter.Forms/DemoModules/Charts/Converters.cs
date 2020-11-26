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
using System.Globalization;
using DemoCenter.Forms.Charts.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms {
    class AreaTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is AreaType type))
                return null;

            switch (type) {
                case AreaType.Range: return "democharts_tabitems_rangearea";
                case AreaType.Simple: return "democharts_tabitems_area";
                case AreaType.Stacked: return "democharts_tabitems_stackedarea";
                case AreaType.FullStacked: return "democharts_tabitems_fullstackedarea";
                case AreaType.Step: return "democharts_tabitems_steparea";
                default: throw new ArgumentException("The selector cannot handle the passed AreaType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class BarTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is BarType type))
                return null;

            switch (type) {
                case BarType.SideBySideRange: return "democharts_tabitems_sidebysiderangebar";
                case BarType.Range: return "democharts_tabitems_rangebar";
                case BarType.Simple: return "democharts_tabitems_bar";
                case BarType.PopulationPyramid: return "democharts_tabitems_populationpyramid";
                case BarType.CryptocurrencyPortfolio: return "democharts_tabitems_cryptocurrencyportfolio";
                case BarType.Stacked: return "democharts_tabitems_stackedbar";
                case BarType.SideBySideStacked: return "democharts_tabitems_sidebysidestackedbar";
                case BarType.FullStacked: return "democharts_tabitems_fullstackedbar";
                case BarType.SideBySideFullStacked: return "democharts_tabitems_sidebysidefullstackedbar";
                case BarType.RotatedStacked: return "democharts_tabitems_rotatedstackedbar";
                case BarType.RotatedSideBySide: return "democharts_tabitems_rotatedsidebysidestackedbar";
                default: throw new ArgumentException("The selector cannot handle the passed BarType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class LineTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is LineType type))
                return null;

            switch (type) {
                case LineType.Simple: return "democharts_tabitems_line";
                case LineType.Scatter: return "democharts_tabitems_scatter";
                case LineType.Step: return "democharts_tabitems_stepline";
                case LineType.Spline: return "democharts_tabitems_spline";
                default: throw new ArgumentException("The selector cannot handle the passed LineType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class PieTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is PieType type))
                return null;

            switch (type) {
                case PieType.Donut: return "democharts_tabitems_donut";
                case PieType.Pie: return "democharts_tabitems_pie";
                default: throw new ArgumentException("The selector cannot handle the passed PieType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class PointTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is PointType type))
                return null;

            switch (type) {
                case PointType.Point: return "democharts_tabitems_point";
                case PointType.Bubble: return "democharts_tabitems_bubble";
                default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class ColorizerTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is ColorizerType type))
                return null;

            switch (type) {
                case ColorizerType.Bubble: return "democharts_tabitems_bubble";
                case ColorizerType.Bar: return "democharts_tabitems_bar";
                case ColorizerType.GradientSegmentColorizer: return "democharts_tabitems_lightspector";
                case ColorizerType.OperationSurfaceTemperature: return "democharts_tabitems_surfacetemperature";
                default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
