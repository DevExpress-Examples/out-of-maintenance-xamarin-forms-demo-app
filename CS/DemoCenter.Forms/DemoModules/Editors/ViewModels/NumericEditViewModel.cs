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
﻿using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Editors;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class NumericEditViewModel : NotificationObject {
        const string DefaultHelpText = "Help Text";
        const string DefaultErrorText = "Error Message";

        decimal minValue;
        decimal maxValue;
        decimal value;
        decimal stepValue;
        bool allowLooping;
        bool selectValueOnFocus;
        DataItem displayFormat;
        UpDownAlignment upDownIconAlignment;
        bool isUpDownIconsVisible;

        string actualErrorText;
        bool actualHasError;
        string actualHelpText;

        public decimal MinValue { get => minValue; set => SetProperty(ref minValue, value); }
        public decimal MaxValue { get => maxValue; set => SetProperty(ref maxValue, value); }
        public decimal Value { get => value; set => SetProperty(ref this.value, value); }
        public decimal StepValue { get => stepValue; set => SetProperty(ref stepValue, value); }
        public bool AllowLooping { get => allowLooping; set => SetProperty(ref allowLooping, value); }
        public bool SelectValueOnFocus { get => selectValueOnFocus; set => SetProperty(ref selectValueOnFocus, value); }
        public DataItem DisplayFormat { get => displayFormat; set => SetProperty(ref displayFormat, value); }
        public UpDownAlignment UpDownIconsAlignment { get => upDownIconAlignment; set => SetProperty(ref upDownIconAlignment, value); }
        public bool IsUpDownIconsVisible { get => isUpDownIconsVisible; set => SetProperty(ref isUpDownIconsVisible, value); }
        public List<DataItem> DisplayFormats { get; set; } = new List<DataItem>() {
            new DataItem() { Name = "None", Value = string.Empty },
            new DataItem() { Name = "Currency", Value = "c" },
            new DataItem() { Name = "Percentage", Value = "p" },
            new DataItem() { Name = "Number", Value = "n" }
        };
        public List<UpDownAlignment> Alignments { get; set; } = new List<UpDownAlignment> {
            new UpDownAlignment { Name="Start", Value=UpDownIconAlignment.Start, TextAlignment=TextAlignment.End },
            new UpDownAlignment { Name="End", Value=UpDownIconAlignment.End, TextAlignment=TextAlignment.Start },
            new UpDownAlignment { Name="Both", Value=UpDownIconAlignment.Both, TextAlignment=TextAlignment.Center }
        };
        public string ActualErrorText { get => actualErrorText; private set => SetProperty(ref actualErrorText, value); }
        public bool ActualHasError { get => actualHasError; private set => SetProperty(ref actualHasError, value); }
        public string ActualHelpText { get => actualHelpText; private set => SetProperty(ref actualHelpText, value); }
        public ICommand ResetToDefaultCommand { get; }
        public ICommand ToggleErrorCommand { get; }

        public NumericEditViewModel() {
            ResetToDefaultCommand = new DelegateCommand(ResetToDefault);
            ToggleErrorCommand = new DelegateCommand(ToggleError);

            ResetToDefault();
        }

        public void ResetToDefault() {
            MinValue = -100;
            MaxValue = 1000;
            StepValue = (decimal)0.5;
            AllowLooping = false;
            SelectValueOnFocus = false;
            DisplayFormat = DisplayFormats[1];
            UpDownIconsAlignment = Alignments[0];
            IsUpDownIconsVisible = true;
            Value = (decimal)50.5;
            ActualHelpText = DefaultHelpText;
            SetError(false);
        }

        public void ToggleError() => SetError(!ActualHasError);

        public void SetError(bool hasError) {
            ActualErrorText = hasError ? DefaultErrorText : null;
            ActualHasError = hasError;
        }
    }
    public class DataItem {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class UpDownAlignment {
        public string Name { get; set; }
        public UpDownIconAlignment Value { get; set; }
        public TextAlignment TextAlignment { get; set; }
    }
    public class CultureSource {
        public string Name { get; set; }
        public CultureInfo Info { get; set; }
    }
}
