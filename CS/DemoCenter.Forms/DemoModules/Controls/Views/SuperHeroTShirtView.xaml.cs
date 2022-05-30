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
using System;
using System.Threading.Tasks;
using DemoCenter.Forms.DemoModules.Editors.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class SuperHeroTShirtView : ContentPage {
        const int animationDuration = 600;

        SuperHeroTShirtViewModel VM { get; }

        public SuperHeroTShirtView() {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();
            BindingContext = VM = new SuperHeroTShirtViewModel();
            colorChoiceChipGroup.SelectionChanged += OnColorChanged;
        }

        async void OnColorChanged(object sender, EventArgs e) {
            superhero.TranslationX = 0;
            superhero.CancelAnimations();
            double translationX = superhero.Width;
            await Task.WhenAll(
                superhero.FadeTo(0, animationDuration, Easing.Linear),
                superhero.TranslateTo(translationX, superhero.Y, animationDuration, Easing.CubicInOut)
                );

            VM.UpdateSuperhero();
            superhero.TranslationX = -translationX;

            await Task.WhenAll(
                superhero.FadeTo(1, animationDuration, Easing.Linear),
                superhero.TranslateTo(0, superhero.Y, animationDuration, Easing.CubicInOut)
                );
        }
    }
}
