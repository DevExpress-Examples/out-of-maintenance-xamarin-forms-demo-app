/*                                                         
               Copyright (c) 2019 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile UI for Xamarin.Forms               }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2019 Developer Express Inc.                   }   
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
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Editors;
using Xamarin.Forms;

namespace DemoCenter.Forms.Demo.Data {
    public class ColorPickerModel: NotificationObject {
        static IList<LabelModel> CreateLabelModels() {
            List<LabelModel> result = new List<LabelModel>();
            result.Add(new LabelModel() { Color = Color.White, TextColor = Color.Black, Id = 0 });
            result.Add(new LabelModel() { Color = Color.Red, Id = 1 });
            result.Add(new LabelModel() { Color = Color.Orange, Id = 2 });
            result.Add(new LabelModel() { Color = Color.Yellow, Id = 3 });
            result.Add(new LabelModel() { Color = Color.Green, Id = 4 });
            result.Add(new LabelModel() { Color = Color.LightBlue, Id = 5 });
            result.Add(new LabelModel() { Color = Color.Blue, Id = 6 });
            result.Add(new LabelModel() { Color = Color.Magenta, Id = 7 });
            return result;
        }

        Color color = Color.Default;
        LabelModel selectedItem;
        String title = "Select color";

        IList<LabelModel> labelModels = CreateLabelModels();

        public IList<LabelModel> LabelModels {
            get => labelModels;
            set {
                labelModels = value;
                OnPropertyChanged(nameof(LabelModels));
            }
        }


        public Color Color {
            get { return color; }
            set {
                if(Color == value)
                    return;

                this.color = value;
                ApplySelectedColor(value);
                OnPropertyChanged(nameof(Color));
            }
        }
        public LabelModel SelectedItem {
            get => selectedItem;
            set { this.Color = value.Color;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public String Title {
            get { return title; }
            set {
                if(title == value)
                    return;

                this.title = value;
                OnPropertyChanged("Title");
            }
        }

        void ApplySelectedColor(Color selectedColor) {
            foreach(LabelModel colorModel in labelModels) {
                if(colorModel.Color == selectedColor) {
                    selectedItem = colorModel;
                    return;
                }
            }
            selectedItem = new LabelModel() { Color = selectedColor, Id = labelModels.Count };
            labelModels.Add(selectedItem);
        }
    }
}
