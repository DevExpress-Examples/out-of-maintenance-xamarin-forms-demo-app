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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DemoCenter.Forms.Data {
    public class OutsideVendorCostsData {
        readonly DateTimeDataSets seriesData;

        public DataSetContainer<DateTimeData> DevAVNorth => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> DevAVSouth => seriesData.DataSets[1];

        public OutsideVendorCostsData() {
            seriesData = XmlDataDeserializer.GetData<DateTimeDataSets>("Resources.OutsideVendorCosts.xml");
        }
    }

    public class PopulationStructureData {   
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> MaleSeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> FemaleSeriesData => seriesData.DataSets[1];

        public PopulationStructureData() {
            seriesData = XmlDataDeserializer.GetData<QualitativeDataSets>("Resources.PopulationStructure.xml");
        }
    }

    public class AgeStructureData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> Male0to14and65SeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> Male15to64SeriesData => seriesData.DataSets[1];
        public DataSetContainer<QualitativeData> Female0to14and65SeriesData => seriesData.DataSets[2];
        public DataSetContainer<QualitativeData> Female15to64SeriesData => seriesData.DataSets[3];

        public AgeStructureData() {
            seriesData = XmlDataDeserializer.GetData<QualitativeDataSets>("Resources.AgeStructure.xml");
        }
    }

    public class DevAVSalesMixByRegionData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> ProjectorsSeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> TelevisionsSeriesData => seriesData.DataSets[1];

        public DevAVSalesMixByRegionData() {
            seriesData = XmlDataDeserializer.GetData<QualitativeDataSets>("Resources.DevAVSalesMixByRegion.xml");
        }
    }

    public class PopulationPyramidData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> MaleSeriesData => seriesData.DataSets[0];
        public DataSetContainer<QualitativeData> FemaleSeriesData => seriesData.DataSets[1];

        public PopulationPyramidData() {
            seriesData = XmlDataDeserializer.GetData<QualitativeDataSets>("Resources.PopulationPyramid.xml");
        }
    }

    public class CryptocurrencyPortfolioData {
        readonly QualitativeDataSets seriesData;

        public DataSetContainer<QualitativeData> SymbolsData => seriesData.DataSets[0];
        
        public CryptocurrencyPortfolioData() {
			seriesData = XmlDataDeserializer.GetData<QualitativeDataSets>("Resources.CryptocurrencyPortfolio.xml");
		}
    }


    public class AverageDieselPricesData {
        readonly DateTimeDataSets seriesData;

        public DataSetContainer<DateTimeData> DieselPrices => seriesData.DataSets[0];

        public AverageDieselPricesData() {
            seriesData = XmlDataDeserializer.GetData<DateTimeDataSets>("Resources.AverageDieselPrices.xml");
        }

    }

    public class LondonWeatherData {
        readonly DateTimeDataSets seriesData;

        public DataSetContainer<DateTimeData> NightMin => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> DayMax => seriesData.DataSets[1];
        public double NightMinAverageValue => GetAverageValue(NightMin);
        public double DayMaxAverageValue => GetAverageValue(DayMax);

        public LondonWeatherData() {
            seriesData = XmlDataDeserializer.GetData<DateTimeDataSets>("Resources.LondonWeather.xml");
        }

        double GetAverageValue(DataSetContainer<DateTimeData> data) {
            double result = 0;
            foreach (DateTimeData res in data.DataSet)
                result += res.Value;
            return result / data.DataSet.Count;
        }
    }

    public class TrendPopulationData {
        readonly DateTimeDataSets populationDataSource;

        public DataSetContainer<DateTimeData> Europe => populationDataSource.DataSets[0];
        public DataSetContainer<DateTimeData> Americas => populationDataSource.DataSets[1];
        public DataSetContainer<DateTimeData> Africa => populationDataSource.DataSets[2];

        public TrendPopulationData() {
            this.populationDataSource = XmlDataDeserializer.GetData<DateTimeDataSets>("Resources.TrendPopulation.xml");
        }
    }

    public class SalesByLastYearsData {
        readonly string[] names = { "North America", "Europe", "Australia" };
        readonly double[][] values = {
            new double[] { 2.666, 3.665, 3.555, 3.485, 3.747, 4.182 },
            new double[] { 2.078, 3.888, 3.008, 3.088, 3.357, 3.725 },
            new double[] { 1.09, 2.01, 1.85, 1.78, 1.957, 2.272 }
        };
        readonly DataSetsContainer<DateTimeData> seriesData = new DataSetsContainer<DateTimeData>();

        public DataSetContainer<DateTimeData> NorthAmerica => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> Europe => seriesData.DataSets[1];
        public DataSetContainer<DateTimeData> Australia => seriesData.DataSets[2];

        public SalesByLastYearsData() {
            int year = DateTime.Now.Year;
            seriesData.DataSets = new List<DataSetContainer<DateTimeData>>();
            for (int i = 0; i < names.Length; i++) {
                List<DateTimeData> data = new List<DateTimeData>();
                for (int j = 0; j < values[i].Length; j++)
                    data.Add(new DateTimeData(new DateTime(year - values[i].Length + j, 1, 1), values[i][j]));
                var dataContainer = new DataSetContainer<DateTimeData>() { Name = names[i], DataSet = data };
                seriesData.DataSets.Add(dataContainer);
            }
        }
    }

    public class BranchesSalesData {
        readonly string[] names = { "DevAV East", "DevAV West", "DevAV South", "DevAV Center", "DevAV North" };
        readonly double[][] values = {
            new double[] { 0D, 0D, 0.003, 0.32, 0.51, 1.71 },
            new double[] { 0.95, 1.53, 1.75, 1.31, 1.31, 1.22 },
            new double[] { 1.09, 1.01, 1.11, 1.12, 1.12, 1.111 },
            new double[] { 2.078, 3.888, 3.008, 3.088, 3.357, 3.725 },
            new double[] { 2.666, 3.665, 3.555, 3.485, 3.747, 4.182 }
        };
        readonly DataSetsContainer<DateTimeData> seriesData = new DataSetsContainer<DateTimeData>();

        public DataSetContainer<DateTimeData> DevAVEast => seriesData.DataSets[0];
        public DataSetContainer<DateTimeData> DevAVWest => seriesData.DataSets[1];
        public DataSetContainer<DateTimeData> DevAVSouth => seriesData.DataSets[2];
        public DataSetContainer<DateTimeData> DevAVCenter => seriesData.DataSets[3];
        public DataSetContainer<DateTimeData> DevAVNorth => seriesData.DataSets[4];

        public BranchesSalesData() {
            GenerateData();
        }
        void GenerateData() {
            int year = DateTime.Now.Year;
            seriesData.DataSets = new List<DataSetContainer<DateTimeData>>();
            for (int i = 0; i < names.Length; i++) {
                List<DateTimeData> data = new List<DateTimeData>();
                for (int j = 0; j < values[i].Length; j++)
                    data.Add(new DateTimeData(new DateTime(year - values[i].Length + j, 1, 1), values[i][j]));
                var dataContainer = new DataSetContainer<DateTimeData>() { Name = names[i], DataSet = data };
                seriesData.DataSets.Add(dataContainer);
            }
        }
    }

    public class SalesByYearsData {
        static DateTime StartDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-10);

        readonly IList<string> categories = new List<string> { "Asia", "Australia", "Europe", "N. America", "S. America" };
        readonly IList<IList<double>> values = new List<IList<double>> {
            new List<double> { 1.8532D, 1.9849D, 2.4372D, 2.5147D, 2.7514D, 2.8532D, 3.5849D, 4.2372D, 4.7685D, 5.2890D },
            new List<double> { 0.6988D, 0.8320D, 0.8711D, 0.9210D, 0.9651D, 1.2586D, 1.5744D, 1.7871D, 1.9576D, 2.2727D },
            new List<double> { 1.1210D, 1.1311D, 1.3025D, 1.3214D, 1.4284D, 1.9579D, 2.5664D, 3.0884D, 3.3579D, 3.7257D },
            new List<double> { 1.9855D, 2.1288D, 2.4855D, 2.7477D, 2.8825D, 2.9855D, 3.0788D, 3.4855D, 3.7477D, 4.1825D },
            new List<double> { 0.9127D, 0.9734D, 0.9927D, 1.1237D, 1.3172D, 1.3827D, 1.5734D, 1.6027D, 1.8237D, 2.1172D }
        };

        public IList<List<DateTimeData>> Data { get; private set; } = new List<List<DateTimeData>>();
        public IList<PieData> PieData { get; private set; } = new List<PieData>();

        public SalesByYearsData() {
            for (int j = 0; j < values.Count; j++) {  
                List<DateTimeData> seriesData = new List<DateTimeData>();
                StartDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-10);
                for (int i = 0; i < values[j].Count; i++)
                    seriesData.Add(new DateTimeData(StartDate.AddYears(i), values[j][i]));
                Data.Add(seriesData);
                PieData.Add(new PieData(categories[j], values[j].Sum()));
            }
        }
    }

    public class BondPortfolioDiversification {
        public IList<PieData> SecuritiesByTypes = new List<PieData>();
        public IList<PieData> SecuritiesByRisk = new List<PieData>();

        public BondPortfolioDiversification() {
            SecuritiesByTypes.Add(new PieData("Stock",417360.00));
            SecuritiesByTypes.Add(new PieData("Mutual Fund", 27414.32));
            SecuritiesByTypes.Add(new PieData("Bond", 35682.00));

            SecuritiesByRisk.Add(new PieData("Income", 132826.00));
            SecuritiesByRisk.Add(new PieData("Growth", 208816.0));
            SecuritiesByRisk.Add(new PieData("Speculation", 24700.00));
            SecuritiesByRisk.Add(new PieData("Hedge", 80114.00));
        }
    }

    public class SecuritesByRiskAndTypes {
        public IList<PieData> Rating { get; } = new List<PieData>();
        public IList<PieData> Security { get; } = new List<PieData>();

        public SecuritesByRiskAndTypes() {
            Rating.Add(new PieData("AA", 13));
            Rating.Add(new PieData("MBB+", 7));
            Rating.Add(new PieData("BBB", 45));
            Rating.Add(new PieData("BBB-", 20));
            Rating.Add(new PieData("NR", 15));

            Security.Add(new PieData("FRN", 16.0));
            Security.Add(new PieData("FCB", 41.0));
            Security.Add(new PieData("CIB", 25.0));
            Security.Add(new PieData("IAB", 18.0));
        }
    }

    public class TunedEngineData {
        public IList<NumericData> NEPower = new List<NumericData>();
        public IList<NumericData> NETorque = new List<NumericData>();
        public IList<NumericData> MKRPower = new List<NumericData>();
        public IList<NumericData> MKRTorque = new List<NumericData>();
        public IList<NumericData> NEFuelRate = new List<NumericData>();
        public IList<NumericData> MKRFuelRate = new List<NumericData>();

        public TunedEngineData() {
            NEPower = new List<NumericData>() {
                new NumericData(1000, 100),
                new NumericData(1500, 105),
                new NumericData(2100, 125),
                new NumericData(2500, 145),
                new NumericData(3200, 225),
                new NumericData(3800, 250),
                new NumericData(4500, 220),
                new NumericData(5300, 190),
                new NumericData(6100, 180),
                new NumericData(7000, 175)};

            NETorque = new List<NumericData>() {
                new NumericData(1000, 180),
                new NumericData(1500, 200),
                new NumericData(2100, 240),
                new NumericData(2500, 260),
                new NumericData(3200, 270),
                new NumericData(3800, 290),
                new NumericData(4500, 300),
                new NumericData(5300, 330),
                new NumericData(6100, 360),
                new NumericData(7000, 370)};

            MKRPower = new List<NumericData>() {
                new NumericData(1000, 80),
                new NumericData(1500, 85),
                new NumericData(2100, 100),
                new NumericData(2500, 115),
                new NumericData(3200, 205),
                new NumericData(3800, 230),
                new NumericData(4500, 200),
                new NumericData(5300, 160),
                new NumericData(6100, 155),
                new NumericData(7000, 145)};

            MKRTorque = new List<NumericData>() {
                new NumericData(1000, 160),
                new NumericData(1500, 180),
                new NumericData(2100, 220),
                new NumericData(2500, 245),
                new NumericData(3200, 255),
                new NumericData(3800, 270),
                new NumericData(4500, 280),
                new NumericData(5300, 310),
                new NumericData(6100, 340),
                new NumericData(7000, 350)};

            NEFuelRate = new List<NumericData>() {
                new NumericData(1000, 18.1),
                new NumericData(1500, 19.6),
                new NumericData(2100, 23.5),
                new NumericData(2500, 26.1),
                new NumericData(3200, 29.4),
                new NumericData(3800, 31.4),
                new NumericData(4500, 27.7),
                new NumericData(5300, 19.6),
                new NumericData(6100, 16.8),
                new NumericData(7000, 15.5)};

            MKRFuelRate = new List<NumericData>() {
                new NumericData(1000, 21.4),
                new NumericData(1500, 23.5),
                new NumericData(2100, 29.4),
                new NumericData(2500, 33.6),
                new NumericData(3200, 36.2),
                new NumericData(3800, 39.2),
                new NumericData(4500, 33.6),
                new NumericData(5300, 26.1),
                new NumericData(6100, 21.4),
                new NumericData(7000, 18.1)};
        }
    }

    public class HeadphonesData {
        public IList<NumericData> FirstHeadphones90 = new List<NumericData>();
        public IList<NumericData> FirstHeadphones100 = new List<NumericData>();
        public IList<NumericData> SecondHeadphones90 = new List<NumericData>();
        public IList<NumericData> SecondHeadphones100 = new List<NumericData>();

        public HeadphonesData() {
            using (Stream stream = GetType().Assembly.GetManifestResourceStream("Resources.HeadphoneComparison.dat")) {
                StreamReader reader = new StreamReader(stream);
                string data = reader.ReadToEnd();
                String[] dataItems = data.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < dataItems.Length; i++) {
                    String[] row = dataItems[i].Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]
                        .Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    double frequency = Convert.ToDouble(row[1], CultureInfo.InvariantCulture);
                    double thd90 = Convert.ToDouble(row[2], CultureInfo.InvariantCulture);
                    double thd100 = Convert.ToDouble(row[3], CultureInfo.InvariantCulture);
                    int headphoneNumber = Convert.ToInt32(row[0], CultureInfo.InvariantCulture);
                    if (headphoneNumber == 1) {
                        FirstHeadphones90.Add(new NumericData(frequency, thd90));
                        FirstHeadphones100.Add(new NumericData(frequency, thd100));
                    } else if (headphoneNumber == 2) {
                        SecondHeadphones90.Add(new NumericData(frequency, thd90));
                        SecondHeadphones100.Add(new NumericData(frequency, thd100));
                    }
                }
            }
        }
    }
}
