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
using System.Collections.Generic;
using DemoCenter.Forms.Demo;
using DemoCenter.Forms.DemoModules.Drawer.ViewModels;
using Xamarin.Forms;
using MenuItem = DemoCenter.Forms.DemoModules.Drawer.ViewModels.MenuItem;
using RadioButton = DemoCenter.Forms.Demo.RadioButton;

namespace DemoCenter.Forms.Views {
    public partial class DrawerSettingsView : ContentPage {
        public DrawerSettingsView() {
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            InitializeComponent();
            BindingContext = new DrawerSettingsViewModel();
            PrepareRadioLists();
            FillMenu();
        }

        void FillMenu() {
            DrawerSettingsViewModel model = (DrawerSettingsViewModel) BindingContext;
            foreach (MenuItem menuItem in model.MenuItems) {
                DataTemplate template = this.menuTemplate;
                View templateContent = (View)template.CreateContent();
                templateContent.BindingContext = menuItem;
                this.menu.Children.Add(templateContent);
            }
        }

        private void PrepareRadioLists() {
            DrawerSettingsViewModel model = (DrawerSettingsViewModel) BindingContext;
            SetupRadioGroup(model.BehaviorVariants, this.behaviorSelector, nameof(DrawerSettingsViewModel.SelectedBehavior));
            SetupRadioGroup(model.PositionVariants, this.positionSelector, nameof(DrawerSettingsViewModel.SelectedPosition));
        }

        void SetupRadioGroup(IList<string> values, FlexLayout parent, string selectedPropertyName) {
            for(int i = 0; i < values.Count; i++) {
                string name = values[i];
                RadioButton button = new RadioButton();
                button.LabelText = name;
                button.SetBinding(RadioButton.IsSelectedProperty,
                    new Binding(
                        selectedPropertyName,
                        source: BindingContext,
                        converter: new DrawerEnumToStringConverter(),
                        converterParameter: name,
                        mode: BindingMode.TwoWay
                    )
                );
                parent.Children.Add(button);
            }
        }
        
        void OnMenuClicked(object sender, EventArgs args) => drawerView.IsDrawerOpened = true;
    }
}
