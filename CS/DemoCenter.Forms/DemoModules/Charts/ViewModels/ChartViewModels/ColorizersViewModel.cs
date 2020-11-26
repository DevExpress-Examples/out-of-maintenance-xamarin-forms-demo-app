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
﻿using System.Collections.Generic;
using DemoCenter.Forms.Data;

namespace DemoCenter.Forms.ViewModels {
    public class BubbleColorizerViewModel : ChartViewModelBase {
        HpiIndexCustomColorizerAdapter dataAdapter = new HpiIndexCustomColorizerAdapter();

        public override string Title => "Bubble colorizer";
        public List<CountryStatistic> CountriesStatisticData => this.dataAdapter.SeriesData;
    }

    public class BarColorizerViewModel : ChartViewModelBase {
        CountriesStatisticData data = new CountriesStatisticData();

        public override string Title => "Bar colorizer";
        public List<CountryStatistic> CountriesStatisticData => this.data.SeriesData;
    }

    public class OperationSurfaceTemperatureViewModel : ChartViewModelBase {
        TemperatureData data = new TemperatureData();

        public override string Title => "Operation Surface Temperature";
        public double OptimalTemperature => this.data.OptimalTemperature;
        public List<TemperaturePoint> TemperaturePoints => this.data.SeriesData;
    }

    public class GradientSegmentColorizerViewModel : ChartViewModelBase {
        LightSpectorData data = new LightSpectorData();

        public override string Title => "Light Spector";
        public IList<NumericData> LightSpectorData => this.data.LightSpectors;
    }
}
