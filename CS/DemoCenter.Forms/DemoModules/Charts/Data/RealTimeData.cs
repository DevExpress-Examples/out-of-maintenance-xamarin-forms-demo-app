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
using System.ComponentModel;
using System.Timers;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace DemoCenter.Forms.Data {
    public interface ISensor {
        void Start();
        void Stop();
        double GetXValue();
        double GetYValue();
        double GetZValue();
        bool IsData { get; }
    }

    public class RealTimeDataProvider {
        static readonly int Delay = 10;
        static readonly int MaxDataCount = 300;

        readonly ISensor sensor;
        readonly Timer timer;
        readonly ChartView chart;
        bool isRunning = false;

        public BindingList<DateTimeData> XAxisSeriesData { get; } = new BindingList<DateTimeData>();
        public BindingList<DateTimeData> YAxisSeriesData { get; } = new BindingList<DateTimeData>();
        public BindingList<DateTimeData> ZAxisSeriesData { get; } = new BindingList<DateTimeData>();

        public RealTimeDataProvider(ChartView chart) {
            this.chart = chart;
            timer = new Timer(Delay);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = false;
            sensor = DependencyService.Get<ISensor>();
            timer.Enabled = true;
        }

        void RemoveExcessData(BindingList<DateTimeData> data) {
            if (data.Count > MaxDataCount)
                data.RemoveAt(0);
        }
        void OnTimerElapsed(object sender, ElapsedEventArgs e) {
            Device.BeginInvokeOnMainThread(() => {
                if (isRunning) {
                    if (sensor != null && sensor.IsData) {
                        chart.SuspendRender();
                        XAxisSeriesData.Add(new DateTimeData(DateTime.Now, sensor.GetXValue()));
                        RemoveExcessData(XAxisSeriesData);
                        YAxisSeriesData.Add(new DateTimeData(DateTime.Now, sensor.GetYValue()));
                        RemoveExcessData(YAxisSeriesData);
                        ZAxisSeriesData.Add(new DateTimeData(DateTime.Now, sensor.GetZValue()));
                        RemoveExcessData(ZAxisSeriesData);
                        chart.ResumeRender();
                    }
                    timer.Start();
                }
            });
        }

        public void Stop() {
            isRunning = false;
            timer.Stop();
            sensor?.Stop();
        }
        public void Start() {
            isRunning = true;
            timer.Start();
            sensor?.Start();
        }
    }
}
