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
using System.Collections.Generic;
using DemoCenter.Forms.ViewModels;

namespace DemoCenter.Forms.Charts.ViewModels {
    public class BarChartsViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new BarChartItemInfoContainer(
                viewModel: new SideBySideRangeBarChartViewModel(),
                type: BarType.SideBySideRange
            ),
            new BarChartItemInfoContainer(
                viewModel: new RangeBarChartViewModel(),
                type: BarType.Range
            ),
            new BarChartItemInfoContainer(
                viewModel: new PopulationPyramidViewModel(),
                type: BarType.PopulationPyramid
            ),
            new BarChartItemInfoContainer(
                viewModel: new BarChartViewModel(),
                type: BarType.Simple
            ),
            new BarChartItemInfoContainer(
                viewModel: new StackedBarChartViewModel(),
                type: BarType.Stacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new SideBySideStackedBarChartViewModel(),
                type: BarType.SideBySideStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new FullStackedBarChartViewModel(),
                type: BarType.FullStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new SideBySideStackedBarChartViewModel(),
                type: BarType.SideBySideFullStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new StackedBarChartViewModel(),
                type: BarType.RotatedStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new SideBySideStackedBarChartViewModel(),
                type: BarType.RotatedSideBySide
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class BarChartItemInfoContainer : ChartItemInfoContainerBase {
        public BarType BarType { get; }

        public BarChartItemInfoContainer(BarType type, ChartViewModelBase viewModel) {
            BarType = type;
            ChartModel = viewModel;
        }
    }
}
