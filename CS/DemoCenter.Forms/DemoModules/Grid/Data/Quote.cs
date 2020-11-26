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
using System.ComponentModel;
using System.IO;
using DemoCenter.Forms.ViewModels;
using Newtonsoft.Json.Linq;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public class Quote : NotificationObject {
        string companyName = String.Empty;
        double price;
        double delta;
        double lowPrice;
        double highPrice;

        public string CompanyName {
            get { return companyName; }
            set {
                if (companyName == value)
                    return;

                this.companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        public double Price {
            get { return price; }
            set {
                if (price == value)
                    return;

                this.price = value;
                OnPropertyChanged("Price");
            }
        }

        public double Delta {
            get { return delta; }
            set {
                if (delta == value)
                    return;

                this.delta = value;
                OnPropertyChanged("Delta");
            }
        }

        public double LowPrice {
            get { return lowPrice; }
            set {
                if (lowPrice == value)
                    return;

                lowPrice = value;
                OnPropertyChanged("LowPrice");
            }
        }

        public double HighPrice {
            get { return highPrice; }
            set {
                if (highPrice == value)
                    return;

                highPrice = value;
                OnPropertyChanged("HighPrice");
            }
        }

        public Quote Clone() {
            Quote result = new Quote();
            result.CompanyName = this.CompanyName;
            result.Price = this.Price;
            result.Delta = this.Delta;
            result.LowPrice = this.LowPrice;
            result.HighPrice = this.HighPrice;
            return result;
        }
    }

    public class MarketSimulator {
        BindingList<Quote> quotes;
        readonly DateTime now;
        readonly Random random;

        public MarketSimulator() {
            this.now = DateTime.Now;
            this.random = new Random((int)now.Ticks);
            this.quotes = new BindingList<Quote>();
            PopulateQuotes();
        }

        public BindingList<Quote> Quotes { get { return quotes; } }

        void PopulateQuotes() {
            var assembly = this.GetType().Assembly;
            Stream stream = assembly.GetManifestResourceStream("StockSource.json");
            JObject jObject = JObject.Parse(new StreamReader(stream).ReadToEnd());
            quotes = jObject["StockItems"].ToObject<BindingList<Quote>>();
        }

        public void SimulateNextStep() {
            foreach (var item in quotes) {
                UpdateQuote(item);
            }
        }

        void UpdateQuote(Quote quote) {
            double value = quote.Price;

            int percentChange = random.Next(0, 201) - 100;
            double newValue = value + value * (5 * percentChange / 10000.0);
            if (newValue < 0)
                newValue = value - value * (5 * percentChange / 10000.0);

            quote.Price = newValue;
            quote.Delta = newValue - value;

            if (quote.LowPrice > quote.Price)
                quote.LowPrice = quote.Price;

            if (quote.HighPrice < quote.Price)
                quote.HighPrice = quote.Price;
        }
    }
}
