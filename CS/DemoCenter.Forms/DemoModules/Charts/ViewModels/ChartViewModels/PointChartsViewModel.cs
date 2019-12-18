/*                                                         
               Copyright (c) 2019 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile UI for Xamarin.Forms               }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2019 Developer Express Inc.                   }   
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
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class PointChartViewModel : ChartViewModelBase {
        readonly LondonWeatherData chartData = new LondonWeatherData();

        public DataSetContainer<DateTimeData> NightMin => chartData.NightMin;
        public DataSetContainer<DateTimeData> DayMax => chartData.DayMax;
        public int AverageTempNight => (int) chartData.NightMinAverageValue;
        public int AverageTempDay => (int) chartData.DayMaxAverageValue;

        public override string Title => "Average Temperature in London";
    }

    public class BubbleChartViewModel : ChartViewModelBase {
        HighestGrossingFilmsByYearData data = new HighestGrossingFilmsByYearData();

        public override string Title => "Highest-Grossing Films by Year";
        public List<FilmData> SeriesData => data.SeriesData;
        public Color[] Palette => Palettes.Extended;
    }
}
