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
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class SimpleButtonViewModel : NotificationObject {
        double DefaultCornerRadius = 4.0;
        double DefaultBorderSize = 4.0;

        ColorViewModel selectedTextColor;
        ColorViewModel selectedBackgroundColor;
        ColorViewModel selectedIconColor;
        ColorViewModel selectedBorderColor;

        double topLeftCornerRadius;
        double topRightCornerRadius;
        double bottomLeftCornerRadius;
        double bottomRightCornerRadius;
        CornerRadius cornerRadius;
        double borderWidth;

        bool shouldShowIcon;
        bool shouldShowBorder;
        bool shouldShowShadow;

        public IList<ColorViewModel> Colors { get; }
        public ColorViewModel SelectedTextColor { get => selectedTextColor; set => SetProperty(ref selectedTextColor, value); }
        public ColorViewModel SelectedBackgroundColor { get => selectedBackgroundColor; set => SetProperty(ref selectedBackgroundColor, value); }
        public ColorViewModel SelectedIconColor { get => selectedIconColor; set => SetProperty(ref selectedIconColor, value); }
        public ColorViewModel SelectedBorderColor { get => selectedBorderColor; set => SetProperty(ref selectedBorderColor, value); }

        public bool ShouldShowIcon { get => shouldShowIcon; set => SetProperty(ref shouldShowIcon, value); }
        public bool ShouldShowBorder {
            get => shouldShowBorder;
            set => SetProperty(ref shouldShowBorder, value, () => BorderWidth = ShouldShowBorder ? DefaultBorderSize : 0);
        }
        public bool ShouldShowShadow { get => shouldShowShadow; set => SetProperty(ref shouldShowShadow, value); }

        public double TopLeftCornerRadius { get => topLeftCornerRadius; set => SetProperty(ref topLeftCornerRadius, value, UpdateCornerRadius); }
        public double TopRightCornerRadius { get => topRightCornerRadius; set => SetProperty(ref topRightCornerRadius, value, UpdateCornerRadius); }
        public double BottomLeftCornerRadius { get => bottomLeftCornerRadius; set => SetProperty(ref bottomLeftCornerRadius, value, UpdateCornerRadius); }
        public double BottomRightCornerRadius { get => bottomRightCornerRadius; set => SetProperty(ref bottomRightCornerRadius, value, UpdateCornerRadius); }
        public CornerRadius CornerRadius { get => cornerRadius; set => SetProperty(ref cornerRadius, value); }
        public double BorderWidth { get => borderWidth; set => SetProperty(ref borderWidth, value); }

        public SimpleButtonViewModel() {
            Colors = ColorViewModel.CreateDefaultColors();
            SelectedTextColor = Colors[0];
            SelectedBackgroundColor = Colors[5];
            SelectedIconColor = Colors[0];
            SelectedBorderColor = Colors[1];

            TopLeftCornerRadius = DefaultCornerRadius;
            TopRightCornerRadius = DefaultCornerRadius;
            BottomLeftCornerRadius = DefaultCornerRadius;
            BottomRightCornerRadius = DefaultCornerRadius;
        }

        void UpdateCornerRadius() {
            CornerRadius = new CornerRadius(TopLeftCornerRadius, TopRightCornerRadius, BottomLeftCornerRadius, BottomRightCornerRadius);
        }
    }
}
