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
﻿using System;
using System.Collections.Generic;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace DemoCenter.Forms.Data {
    public class CountryStatistic {
        public string Country { get; private set; }
        public double Gdp { get; private set; }
        public double Population { get; private set; }
        public double Hpi { get; private set; }
        public string Region { get; private set; }
        public Color Color { get; private set; }

        public CountryStatistic(string country, double gdp, double population, double hpi, string region, Color color) {
            Country = country;
            Gdp = gdp;
            Population = population;
            Hpi = hpi;
            Region = region;
            Color = color;
        }
    }

    public class CountryGdpStatistics {
        public string Country { get; private set; }
        public double Gdp { get; private set; }
        public string Region { get; private set; }
        public DateTime Year { get; private set; }

        public CountryGdpStatistics(string country, double gdp, string region, DateTime year) {
            Country = country;
            Gdp = gdp;
            Region = region;
            Year = year;
        }
    }

    public class CountriesStatisticData {
        public List<CountryStatistic> SeriesData { get; } = new List<CountryStatistic> {
            new CountryStatistic("Argentina", 16011.6728032264, 40412000, 54.055, "America", Color.FromHex("ed7d31")),
            new CountryStatistic("Australia", 38159.6336533223, 40412000, 41.980, "Australia", Color.FromHex("ffc000")),
            new CountryStatistic("Brazil", 11210.3908053823, 194946000, 52.9, "America", Color.FromHex("ed7d31")),
            new CountryStatistic("Canada", 39050.1673163719, 34126000, 43.56, "America", Color.FromHex("ed7d31")),
            new CountryStatistic("China", 7599, 1338300000, 44.66, "Asia", Color.FromHex("a5a5a5")),
            new CountryStatistic("France", 34123.1966249035, 64895000, 46.523, "Europe", Color.FromHex("4472c4")),
            new CountryStatistic("Germany", 37402.2677660974, 81777000, 47.2, "Europe", Color.FromHex("4472c4")),
            new CountryStatistic("India", 3425.4489267524, 1224615000, 50.865, "Asia", Color.FromHex("a5a5a5")),
            new CountryStatistic("Indonesia", 4325.2533282173, 239870000, 55.481, "Asia", Color.FromHex("a5a5a5")),
            new CountryStatistic("Italy", 31954.1751781228, 60483000, 46.352, "Europe", Color.FromHex("4472c4")),
            new CountryStatistic("Japan", 33732.8682226596, 127451000, 47.508, "Asia", Color.FromHex("a5a5a5")),
            new CountryStatistic("Mexico", 14563.884253986, 113423000, 52.894, "America", Color.FromHex("ed7d31")),
            new CountryStatistic("Russia", 19891.3528339013, 141750000, 34.518, "Europe", Color.FromHex("4472c4")),
            new CountryStatistic("Saudi Arabia", 22713.4852913284, 27448000, 45.965, "Asia", Color.FromHex("a5a5a5")),
            new CountryStatistic("South Africa", 10565.1840563081, 49991000, 28.190, "Africa", Color.FromHex("5b9bd5")),
            new CountryStatistic("South Korea", 29101.0711400706, 48875000, 43.781, "Asia", Color.FromHex("a5a5a5")),
            new CountryStatistic("Turkey", 15686.860167575, 72752000, 47.623, "Africa", Color.FromHex("5b9bd5")),
            new CountryStatistic("United Kingdom", 35686.1997705521, 62232000, 47.925, "Europe", Color.FromHex("4472c4")),
            new CountryStatistic("Spain", 32230.3585974199, 46071000, 44.063, "Europe", Color.FromHex("4472c4")),
            new CountryStatistic("USA", 47153.0094273427, 309349000, 37.340, "America", Color.FromHex("ed7d31")),
        };
    }

    public class CountryYearlyStatisticsData {
        public List<CountryGdpStatistics> SeriesData { get; } = new List<CountryGdpStatistics> {
            new CountryGdpStatistics("UK", 45903.9, "Europe", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("UK", 48651.6, "Europe", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("UK", 49912.4, "Europe", new DateTime(2019, 1, 1)),

            new CountryGdpStatistics("USA", 60091.6, "America", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("USA", 63043.0, "America", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("USA", 65240.4, "America", new DateTime(2019, 1, 1)),
            new CountryGdpStatistics("Canada", 48479.8, "America", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("Canada", 51106.9, "America", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("Canada", 51822.2, "America", new DateTime(2019, 1, 1)),

            new CountryGdpStatistics("Japan", 41119.4, "Asia", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("Japan", 42840.2, "Asia", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("Japan", 43642.7, "Asia", new DateTime(2019, 1, 1)),

            new CountryGdpStatistics("France", 44622.8, "Europe", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("France", 47922.2, "Europe", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("France", 50693.5, "Europe", new DateTime(2019, 1, 1)),
            new CountryGdpStatistics("Germany", 53122.0, "Europe", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("Germany", 56689.0, "Europe", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("Germany", 57557.9, "Europe", new DateTime(2019, 1, 1)),
            new CountryGdpStatistics("Italy", 41713.9, "Europe", new DateTime(2017, 1, 1)),
            new CountryGdpStatistics("Italy", 44444.7, "Europe", new DateTime(2018, 1, 1)),
            new CountryGdpStatistics("Italy", 45691.0, "Europe", new DateTime(2019, 1, 1)),
        };
    }

    public class HpiIndexCustomColorizerAdapter : ICustomColorizerNumericValueProvider {
        readonly CountriesStatisticData data = new CountriesStatisticData();

        public List<CountryStatistic> SeriesData => this.data.SeriesData;

        public double GetValueForColorizer(int index) {
            return this.data.SeriesData[index].Hpi;
        }
    }
}
