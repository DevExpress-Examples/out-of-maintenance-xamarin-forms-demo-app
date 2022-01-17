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
using System.Collections.Generic;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Editors.ViewModels {
    public class SuperHeroTShirtViewModel : NotificationObject {
        string selectedSize;
        ImageSource tShirt;
        ImageSource selectedSuperhero;

        public IList<string> Sizes { get; }
        public IList<ImageSource> Superheroes { get; }
        public int SelectedColorIndex { get; set; }

        public string SelectedSize { get => this.selectedSize; set => SetProperty(ref this.selectedSize, value); }
        public ImageSource TShirt { get => this.tShirt; set => SetProperty(ref this.tShirt, value); }
        public ImageSource SelectedSuperhero { get => this.selectedSuperhero; set => SetProperty(ref this.selectedSuperhero, value); }

        public SuperHeroTShirtViewModel() {
            Sizes = new List<string>() { "S","M","L","XL","XXL","XXXL" };
            TShirt = ImageSource.FromResource("tshirt.png");
            Superheroes = new List<ImageSource>() {
                ImageSource.FromFile("superhero_red"),
                ImageSource.FromFile("superhero_orange"),
                ImageSource.FromFile("superhero_yellow"),
                ImageSource.FromFile("superhero_green"),
                ImageSource.FromFile("superhero_blue"),
                ImageSource.FromFile("superhero_purple")
            };
            SelectedColorIndex = 1;
            SelectedSize = Sizes[2];
            UpdateSuperhero();
        }

        public void UpdateSuperhero() {
            SelectedSuperhero = (SelectedColorIndex == -1) ? null : Superheroes[SelectedColorIndex];
        }
    }
}
