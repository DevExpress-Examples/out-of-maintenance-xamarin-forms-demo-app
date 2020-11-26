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
﻿using System.Collections.Generic;
using System.Linq;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.DataForm;
using DevExpress.XamarinForms.Editors;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class CheckEditViewModel : NotificationObject {
        TextAlignment labelVerticalAlignment = TextAlignment.Center;
        TextAlignment labelHorizontalAlignment = TextAlignment.Start;

        TextAlignment checkBoxAlignment = TextAlignment.Center;
        CheckBoxPosition checkBoxPosition = CheckBoxPosition.Start;

        CheckEditGlyphSet selectedGlyph;
        Color selectedColor;
        bool allowIndeterminateInput;

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public bool AllowIndeterminateInput {
            get => this.allowIndeterminateInput;
            set => SetProperty(ref this.allowIndeterminateInput, value);
        }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public IList<CheckEditGlyphSet> AvailableGlyphs { get; }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public IList<ColorViewModel> AvailableCheckedColors { get; }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public CheckEditGlyphSet SelectedGlyph {
            get => this.selectedGlyph;
            set => SetProperty(ref this.selectedGlyph, value);
        }

        [DataFormDisplayOptions(SkipAutoGenerating = true)]
        public Color SelectedCheckedColor {
            get => this.selectedColor;
            set => SetProperty(ref this.selectedColor, value);
        }

        [DataFormDisplayOptions(LabelText = "Label Vertical Alignment", GroupName = "Layout Options")]
        public TextAlignment LabelVerticalAlignment {
            get => this.labelVerticalAlignment;
            set => SetProperty(ref this.labelVerticalAlignment, value);
        }

        [DataFormDisplayOptions(LabelText = "Label Horizontal Alignment", GroupName = "Layout Options")]
        public TextAlignment LabelHorizontalAlignment {
            get => this.labelHorizontalAlignment;
            set => SetProperty(ref this.labelHorizontalAlignment, value);
        }

        [DataFormDisplayOptions(LabelText = "Checkbox Alignment", GroupName = "Layout Options")]
        public TextAlignment CheckBoxAlignment {
            get => this.checkBoxAlignment;
            set => SetProperty(ref this.checkBoxAlignment, value);
        }

        [DataFormDisplayOptions(LabelText = "Checkbox Position", GroupName = "Layout Options")]
        public CheckBoxPosition CheckBoxPosition {
            get => this.checkBoxPosition;
            set => SetProperty(ref this.checkBoxPosition, value);
        }

        public CheckEditViewModel() {
            AvailableGlyphs = new List<CheckEditGlyphSet> {
                new CheckEditGlyphSet() {
                    CheckedGlyph = null,
                    IndeterminateGlyph = null,
                    UncheckedGlyph = null,
                    LabelText = "Default Checkboxes"
                },
                new CheckEditGlyphSet() {
                    CheckedGlyph = ImageSource.FromFile("editors_ic_round_checkbox_checked"),
                    IndeterminateGlyph = ImageSource.FromFile("editors_ic_round_checkbox_indeterminate"),
                    UncheckedGlyph = ImageSource.FromFile("editors_ic_round_checkbox_unchecked"),
                    LabelText = "Round Checkboxes"
                }
            };
            AvailableCheckedColors = ColorViewModel.CreateDefaultColors();

            this.selectedGlyph = AvailableGlyphs[0];
            this.selectedColor = AvailableCheckedColors.Single(it => it.Name == "Blue").Color;
        }
    }

    public class CheckEditGlyphSet {
        public string LabelText { get; set; }

        public ImageSource CheckedGlyph { get; set; }
        public ImageSource UncheckedGlyph { get; set; }
        public ImageSource IndeterminateGlyph { get; set; }
    }
}
