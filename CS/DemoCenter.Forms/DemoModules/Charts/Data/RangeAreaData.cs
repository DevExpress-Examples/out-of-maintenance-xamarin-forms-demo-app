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
using System.Collections.Generic;

namespace DemoCenter.Forms.Data {
    public class RangeAreaData {
        public List<List<RangeDateTimeData>> SeriesData { get; } = new List<List<RangeDateTimeData>> {
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 9, -2),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 11, -1),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 16, 3),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 21, 8),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 26, 13),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 29, 18),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 31, 21),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 29, 20),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 27, 16),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 22, 9),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 15, 4),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 10, 0),
            },
            new List<RangeDateTimeData> {
                new RangeDateTimeData(new DateTime(2019, 1, 1), 17, 6),
                new RangeDateTimeData(new DateTime(2019, 2, 1), 19, 8),
                new RangeDateTimeData(new DateTime(2019, 3, 1), 23, 11),
                new RangeDateTimeData(new DateTime(2019, 4, 1), 26, 15),
                new RangeDateTimeData(new DateTime(2019, 5, 1), 30, 20),
                new RangeDateTimeData(new DateTime(2019, 6, 1), 33, 23),
                new RangeDateTimeData(new DateTime(2019, 7, 1), 34, 24),
                new RangeDateTimeData(new DateTime(2019, 8, 1), 35, 24),
                new RangeDateTimeData(new DateTime(2019, 9, 1), 32, 21),
                new RangeDateTimeData(new DateTime(2019, 10, 1), 28, 16),
                new RangeDateTimeData(new DateTime(2019, 11, 1), 23, 11),
                new RangeDateTimeData(new DateTime(2019, 12, 1), 18, 7),
            }
        };
    }
}
