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
using System.Xml.Serialization;

namespace DemoCenter.Forms.Data {
    [XmlRoot("DataSetsContainer")]
    public class DataSetsContainer<T> {
        [XmlArrayItem]
        public List<DataSetContainer<T>> DataSets { get; set; }
    }

    [XmlRoot("DataSetContainer")]
    public class DataSetContainer<T> {
        [XmlElement]
        public string Name { get; set; }
        [XmlArrayItem]
        public List<T> DataSet { get; set; }
    }

    [XmlRoot("NumericDataSets")]
    public class NumericDataSets : DataSetsContainer<NumericData> { }
    [XmlRoot("DateTimeDataSets")]
    public class DateTimeDataSets : DataSetsContainer<DateTimeData> { }
    [XmlRoot("QualitativeDataSets")]
    public class QualitativeDataSets : DataSetsContainer<QualitativeData> { }

    public class QualitativeData {
        public string Argument { get; set; }
        public double Value { get; set; }
        public QualitativeData() { }
        public QualitativeData(string argument, double value) {
            Argument = argument;
            Value = value;
        }
    }

    public class DateTimeData {
        public DateTime Argument { get; set; }
        public double Value { get; set; }
        public DateTimeData() { }
        public DateTimeData(DateTime argument, double value) {
            Argument = argument;
            Value = value;
        }
    }

    public class NumericData {
        public double Argument { get; private set; }
        public double Value { get; private set; }
        public NumericData(double argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
    
    public class PieData {
        public string Label { get; }
        public double Value { get; }
        
        public PieData(string label, double value) {
            Label = label;
            Value = value;
        }
    }
}
