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
using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class ChipDataObject {
        public ImageSource Image { get; }
        public string Text { get; }

        public ChipDataObject(string text) {
            Text = text;
            Image = ImageSource.FromFile("smile");
        }
    }

    public class ChipViewModel : NotificationObject {
        CornerRadius DefaultCornerRadius = new CornerRadius(-1);
        double DefaultBorderSize = 2.0;

        ColorViewModel selectedTextColor;
        ColorViewModel selectedBackgroundColor;
        ColorViewModel selectedIconColor;
        ColorViewModel selectedBorderColor;

        double customCornerRadius;
        CornerRadius cornerRadius;
        double borderWidth;

        bool shouldShowIcon;
        bool shouldShowBorder;
        bool useCustomCornerRadius;
        bool removeIconVisible;

        public IList<ColorViewModel> Colors { get; }
        public IList<ChipDataObject> Items { get; }
        public ColorViewModel SelectedTextColor { get => selectedTextColor; set => SetProperty(ref selectedTextColor, value); }
        public ColorViewModel SelectedBackgroundColor { get => selectedBackgroundColor; set => SetProperty(ref selectedBackgroundColor, value); }
        public ColorViewModel SelectedIconColor { get => selectedIconColor; set => SetProperty(ref selectedIconColor, value); }
        public ColorViewModel SelectedBorderColor { get => selectedBorderColor; set => SetProperty(ref selectedBorderColor, value); }

        public bool ShouldShowIcon { get => shouldShowIcon; set => SetProperty(ref shouldShowIcon, value); }
        public bool ShouldShowBorder {
            get => shouldShowBorder;
            set => SetProperty(ref shouldShowBorder, value, () => BorderWidth = ShouldShowBorder ? DefaultBorderSize : 0);
        }

        public bool UseCustomCornerRadius {
            get => useCustomCornerRadius;
            set => SetProperty(ref useCustomCornerRadius, value, () => {
                UpdateCornerRadius();
                CustomCornerRadius = 0;
            });
        }

        public double CustomCornerRadius {
            get => customCornerRadius;
            set => SetProperty(ref customCornerRadius, value, () => UpdateCornerRadius());
        }

        public CornerRadius CornerRadius { get => cornerRadius; set => SetProperty(ref cornerRadius, value); }
        public double BorderWidth { get => borderWidth; set => SetProperty(ref borderWidth, value); }
        public bool RemoveIconVisible { get => removeIconVisible; set => SetProperty(ref removeIconVisible, value); }

        public ChipViewModel() {
            cornerRadius = DefaultCornerRadius;
            Colors = ColorViewModel.CreateDefaultColors();
            Items = new List<ChipDataObject>() {
                new ChipDataObject("Chip 1"),
                new ChipDataObject("Chip 2"),
                new ChipDataObject("Chip 3"),
                new ChipDataObject("Chip 4"),
                new ChipDataObject("Chip 5"),
                new ChipDataObject("Chip 6")
            };
            SelectedTextColor = Colors[0];
            SelectedBackgroundColor = Colors[5];
            SelectedIconColor = Colors[0];
            SelectedBorderColor = Colors[1];
        }

        void UpdateCornerRadius() {
            CornerRadius = UseCustomCornerRadius? new CornerRadius(CustomCornerRadius) : DefaultCornerRadius;
        }
    }
}
