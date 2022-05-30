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
﻿using System;
using System.Collections;
using System.Collections.Generic;
using DemoCenter.Forms.DemoModules.Editors.ViewModels;
using DevExpress.XamarinForms.DataForm;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class CheckEditView : ContentPage {
        static readonly RowDefinitionCollection PortraitRowDefinitions = new RowDefinitionCollection {
            new RowDefinition {
                Height = new GridLength(200)
            },
            new RowDefinition {
                Height = new GridLength(1)
            },
            new RowDefinition {
                Height = GridLength.Star
            }
        };
        static readonly ColumnDefinitionCollection PortraitColumnDefinitions = new ColumnDefinitionCollection {
            new ColumnDefinition {
                Width = GridLength.Star
            }
        };

        static readonly RowDefinitionCollection LandscapeRowDefinitions = new RowDefinitionCollection {
            new RowDefinition {
                Height = GridLength.Star
            }
        };
        static readonly ColumnDefinitionCollection LandscapeColumnDefinitions = new ColumnDefinitionCollection() {
            new ColumnDefinition {
                Width = GridLength.Star
            },
            new ColumnDefinition {
                Width = new GridLength(1)
            },
            new ColumnDefinition {
                Width = GridLength.Star
            }
        };

        
        public CheckEditView() {
            DevExpress.XamarinForms.Editors.Initializer.Init();
            InitializeComponent();
            this.settingsDataForm.PickerSourceProvider = new CheckBoxDemoPickerSourceProvider(BindingContext as CheckEditViewModel);

            if(Device.RuntimePlatform == Device.iOS) {
                this.allowIndeterminateItem.SetDynamicResource(DataFormSwitchItem.OnColorProperty, "AccentColor");
            }

            if(Device.RuntimePlatform == Device.Android) {
                this.allowIndeterminateItem.SetDynamicResource(DataFormSwitchItem.ThumbColorProperty, "AccentColor");
            }
        }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);

            ChangeLayout(width > height);   
        }

        void ChangeLayout(bool isLandscape) {
            if (isLandscape) {
                this.container.RowDefinitions = LandscapeRowDefinitions;
                this.container.ColumnDefinitions = LandscapeColumnDefinitions;

                Grid.SetRow(this.edit, 0);
                Grid.SetColumn(this.edit, 0);

                Grid.SetRow(this.separator, 0);
                Grid.SetColumn(this.separator, 1);

                Grid.SetRow(this.settingsDataForm, 0);
                Grid.SetColumn(this.settingsDataForm, 2);
            } else {
                this.container.RowDefinitions = PortraitRowDefinitions;
                this.container.ColumnDefinitions = PortraitColumnDefinitions;

                Grid.SetRow(this.edit, 0);
                Grid.SetColumn(this.edit, 0);

                Grid.SetRow(this.separator, 1);
                Grid.SetColumn(this.separator, 0);

                Grid.SetRow(this.settingsDataForm, 2);
                Grid.SetColumn(this.settingsDataForm, 0);
            }
        }
    }

    class CheckBoxDemoPickerSourceProvider : DevExpress.XamarinForms.DataForm.IPickerSourceProvider {
        CheckEditViewModel vm;
        public CheckBoxDemoPickerSourceProvider(CheckEditViewModel vm) {
            this.vm = vm;
        }

        public IEnumerable GetSource(string propertyName) {
            switch (propertyName) {
                case "SelectedGlyph":
                    return this.vm.AvailableGlyphs;
                case "SelectedCheckedColor":
                    return this.vm.AvailableCheckedColors;
                default:
                    return null;
            }
        }
    }
}
