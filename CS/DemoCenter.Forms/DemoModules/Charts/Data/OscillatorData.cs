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
    public class OscillatorDataProvider {
        const int k = 2;
        double alpha = 1.75;
        double beta = 5.0;
        double phi = 130.0;
        int count = 1000;
        double direction = 1.0;

        List<NumericData> CreateOscillatorData() {
            List<NumericData> data = new List<NumericData>();
            double left = 0, right = 360;
            double augment = (right - left) / count;
            double phiRad = ToRadians(phi);
            for (double t = left; t <= right + augment; t += augment) {
                double tRad = ToRadians(t);
                double x = Math.Sin(alpha * tRad + phiRad);
                double y = Math.Sin(beta * tRad);
                data.Add(new NumericData(x, y));
            }
            return data;
        }
        void UpdateOscillatorState() {
            alpha += k * direction * beta / 720.0;
            phi += k * direction * 0.5;
            if (phi > 360)
                direction = -1.0;
            else if (phi < 0.0)
                direction = 1.0;
        }
        double ToRadians(double angle) {
            return Math.PI * angle / 180.0;
        }

        public List<NumericData> GenerateNextData() {
            UpdateOscillatorState();
            return CreateOscillatorData();
        }
    }
}
