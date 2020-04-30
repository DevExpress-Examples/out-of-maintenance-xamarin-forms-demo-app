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
using Android.Content;
using Android.Hardware;
using Android.Runtime;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SensorImplementation))]
namespace DemoCenter.Forms.Droid {
    public class SensorImplementation : Java.Lang.Object, ISensor, ISensorEventListener {
        SensorManager sensorManager;
        Sensor accelerometerSensor;
        double xValue = 0;
        double yValue = 0;
        double zValue = 0;
        bool isData = false;

        public SensorImplementation() {
            sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
            accelerometerSensor = sensorManager.GetDefaultSensor(SensorType.Accelerometer);
        }

        public void Start() {
            sensorManager.RegisterListener(this, accelerometerSensor, SensorDelay.Game);
            isData = false;
        }
        public void Stop() {
            sensorManager.UnregisterListener(this);
            isData = false;
        }

        public double GetXValue() => xValue;
        public double GetYValue() => yValue;
        public double GetZValue() => zValue;
        public bool IsData => isData;

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy) { }
        public void OnSensorChanged(SensorEvent e) {
            if (e.Sensor.Type == SensorType.Accelerometer) {
                xValue = e.Values[0];
                yValue = e.Values[1];
                zValue = e.Values[2];
                isData = true;
            }
        }
    }
}
