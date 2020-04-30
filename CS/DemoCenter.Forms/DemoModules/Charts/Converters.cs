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
                case AreaType.Range: return "TabItems.RangeArea.svg";
                case AreaType.Simple: return "TabItems.Area.svg";
                case AreaType.Stacked: return "TabItems.StackedArea.svg";
                case AreaType.FullStacked: return "TabItems.FullStackedArea.svg";
                case AreaType.Step: return "TabItems.StepArea.svg";
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
                case BarType.SideBySideRange: return "TabItems.SideBySideRangeBar.svg";
                case BarType.Range: return "TabItems.RangeBar.svg";
                case BarType.Simple: return "TabItems.Bar.svg";
                case BarType.PopulationPyramid: return "TabItems.PopulationPyramid.svg";
                case BarType.CryptocurrencyPortfolio: return "TabItems.CryptocurrencyPortfolio.svg";
                case BarType.Stacked: return "TabItems.StackedBar.svg";
                case BarType.SideBySideStacked: return "TabItems.SideBySideStackedBar.svg";
                case BarType.FullStacked: return "TabItems.FullStackedBar.svg";
                case BarType.SideBySideFullStacked: return "TabItems.SideBySideFullStackedBar.svg";
                case BarType.RotatedStacked: return "TabItems.RotatedStackedBar.svg";
                case BarType.RotatedSideBySide: return "TabItems.RotatedSideBySideStackedBar.svg";
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
                case LineType.Simple: return "TabItems.Line.svg";
                case LineType.Scatter: return "TabItems.Scatter.svg";
                case LineType.Step: return "TabItems.StepLine.svg";
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
                case PieType.Donut: return "TabItems.Donut.svg";
                case PieType.Pie: return "TabItems.Pie.svg";
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
                case PointType.Point: return "TabItems.Point.svg";
                case PointType.Bubble: return "TabItems.Bubble.svg";
                default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
