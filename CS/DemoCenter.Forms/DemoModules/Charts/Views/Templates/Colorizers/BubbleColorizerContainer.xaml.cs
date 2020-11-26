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
﻿using DemoCenter.Forms.Data;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace DemoCenter.Forms.Charts.Views {
    public partial class BubbleColorizerContainer : ContentView {
        public BubbleColorizerContainer() {
            DevExpress.XamarinForms.Charts.Initializer.Init();
            InitializeComponent();
        }

        void OnBubbleColorizerChanged(object sender, DevExpress.XamarinForms.Charts.SelectionChangedEventArgs e) {
            if (e.SelectedObjects.Count > 0 && e.SelectedObjects[0] is DataSourceKey dataSourceKey) {
                if (dataSourceKey.DataObject is CountryStatistic countryStatistic) {
                    series.HintOptions = new SeriesHintOptions();
                    series.HintOptions.PointTextPattern = string.Format("{0}\nGDP per capita: {1:0}$\nPopulation: {2:0.00}M\nHPI: {3:0.00}",
                                                                                countryStatistic.Country,
                                                                                countryStatistic.Gdp,
                                                                                countryStatistic.Population / 1000000,
                                                                                countryStatistic.Hpi);
                    chart.ShowHint(0, dataSourceKey.Index);
                }
            }
        }
    }
}
