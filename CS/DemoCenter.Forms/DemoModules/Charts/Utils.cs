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
using System.IO;
using System.Xml.Serialization;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace DemoCenter.Forms {
    static class XmlDataDeserializer {
        public static T GetData<T>(string resourceName) {
            T data;
            var assembly = typeof(T).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                var serializer = new XmlSerializer(typeof(T));
                data = (T) serializer.Deserialize(stream);
            }
            return data;
        }
    }

    static class PaletteLoader {
        public static Color[] LoadPalette(params string[] values) {
            Color[] colors = new Color[values.Length];
            for (int i = 0; i < values.Length; i++)
                colors[i] = Color.FromHex(values[i]);
            return colors;
        }
    }

    static class Palettes {
        static readonly Color[] extended = PaletteLoader.LoadPalette("#FF42A5F5", "#FFFF5252", "#FF4CAF50", "#FFFFAB40", "#FFBDBDBD",
                                                                     "#FF536DFE", "#FF009688", "#FFE91E63", "#FFFF6E40", "#FF9C27B0");

        public static Color[] Extended => extended;
    }

    class AxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => (((double) value) / 1000000.0).ToString() + "M";
    }

    class BarChartAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => (((double) value) / 1000000.0).ToString();
    }

    class PopulationPyramidAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => (Math.Abs((double)value) / 1000000.0).ToString() + "M";
    }

    class CryptocurrencyPortfolioAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => ((double)value).ToString() + "%";
    }

    class FrequencyAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => ((double)value).ToString() + " Hz";
    }

    class PercentAxisLabelTextFormatter : IAxisLabelTextFormatter {
        public string Format(object value) => ((double)value).ToString() + " %";
    }
}
