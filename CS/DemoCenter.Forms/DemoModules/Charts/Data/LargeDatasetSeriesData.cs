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
using DevExpress.XamarinForms.Charts;

namespace DemoCenter.Forms.Data {
    public class LargeDatasetSeriesData : IXYSeriesData {
        int dataCount;
        double lastPointValue = 0;
        double delta;
        Random random;

        public LargeDatasetSeriesData(int dataCount) {
            this.dataCount = dataCount;
            this.random = new Random(DateTime.Now.Millisecond * dataCount);
            this.delta = (random.NextDouble() - 0.5) / 100;
        }

        public int GetDataCount() => dataCount;
        public SeriesDataType GetDataType() => SeriesDataType.Numeric;
        public DateTime GetDateTimeArgument(int index) => DateTime.Now;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) {
            return lastPointValue = lastPointValue + random.NextDouble() - 0.5 + delta;
        }
        public double GetNumericArgument(int index) { return index; }
        public string GetQualitativeArgument(int index) { return string.Empty; }
        public object GetKey(int index) => string.Empty;
    }
}
