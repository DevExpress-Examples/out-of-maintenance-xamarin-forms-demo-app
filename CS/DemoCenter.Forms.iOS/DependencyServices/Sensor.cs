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
using CoreMotion;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.iOS;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(SensorImplementation))]
namespace DemoCenter.Forms.iOS {
    public class SensorImplementation : NSObject, ISensor {
        const double UpdateInterval = 1.0 / 100.0;

        CMMotionManager motionManager = new CMMotionManager();
        double xValue = 0;
        double yValue = 0;
        double zValue = 0;
        bool isRunning = false;
        bool isData = false;

        public bool IsData => isData;

        public SensorImplementation() {
            motionManager.DeviceMotionUpdateInterval = UpdateInterval;
        }

        public void Start() {
            motionManager.StartDeviceMotionUpdates();
            isRunning = true;
            isData = false;
            PerformSelector(new ObjCRuntime.Selector("Update"), null, UpdateInterval);
        }
        public void Stop() {
            isRunning = false;
            isData = false;
            motionManager.StopAccelerometerUpdates();
        }
        public double GetXValue() => xValue;
        public double GetYValue() => yValue;
        public double GetZValue() => zValue;

        [Export("Update")]
        void Update() {
            if(motionManager.DeviceMotionActive) {
                CMDeviceMotion deviceMotion = motionManager.DeviceMotion;
                if(deviceMotion != null) {
                    CMAcceleration acceleration = deviceMotion.Gravity;
                    xValue = acceleration.X;
                    yValue = acceleration.Y;
                    zValue = acceleration.Z;
                    isData = true;
                }
            }

            if(isRunning)
                PerformSelector(new ObjCRuntime.Selector("Update"), null, UpdateInterval);
        }
    }
}
