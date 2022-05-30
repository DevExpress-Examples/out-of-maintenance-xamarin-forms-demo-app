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
﻿using Xamarin.Forms;
using DevExpress.XamarinForms.Editors;

namespace DemoCenter.Forms.DemoModules.Editors.Views {
    public class CustomChipGroup : ChipGroup {
        public static readonly BindableProperty ChipIsRemoveIconVisibleProperty = BindableProperty.Create(nameof(ChipIsRemoveIconVisibleProperty), typeof(bool), typeof(CustomChipGroup), defaultValue: false, propertyChanged: ChipIsRemoveIconVisiblePropertyChanged);
        private static void ChipIsRemoveIconVisiblePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((CustomChipGroup)bindable).OnChipIsRemoveIconVisibleChanged((bool)newValue);
        }

        public CustomChipGroup() {
            ChipGeneration += OnChipGeneration;
        }

        private void OnChipGeneration(object sender, ChipGenerationEventArgs e) {
            e.Chip.IsCheckIconVisible = true;
        }

        public bool ChipIsRemoveIconVisible {
            get { return (bool)GetValue(ChipIsRemoveIconVisibleProperty); }
            set { SetValue(ChipIsRemoveIconVisibleProperty, value); }
        }

        private void OnChipIsRemoveIconVisibleChanged(bool newValue) {
            foreach (Chip chip in Chips) {
                chip.IsRemoveIconVisible = newValue;
            }
        }
    }
}
