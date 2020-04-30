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
using System.Collections.Generic;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class ColorViewModel {
        public static IList<ColorViewModel> CreateDefaultColors() {
            return new List<ColorViewModel>() {
                new ColorViewModel("Gray", Color.FromHex("#f0f0f0")),
                new ColorViewModel("Red", Color.FromHex("#ea4c4f")),
                new ColorViewModel("Orange", Color.FromHex("#ff6b11")),
                new ColorViewModel("Yellow", Color.FromHex("#fdaf18")),
                new ColorViewModel("Green", Color.FromHex("#13b00c")),
                new ColorViewModel("Blue", Color.FromHex("#2074ff")),
                new ColorViewModel("Purple", Color.FromHex("#8c5aa3"))
            };
        }

        public Color Color { get; }
        public string Name { get; }

        public ColorViewModel() {
        }


        public ColorViewModel(string name, Color color) {
            Name = name;
            Color = color;
        }
    }
}

