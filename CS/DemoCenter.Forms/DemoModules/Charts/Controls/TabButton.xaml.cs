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
using Xamarin.Forms;

namespace DemoCenter.Forms.Demo {
    public partial class TabButton : ContentView {
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(string), typeof(TabButton));
        public string ImageSource { get => (string) GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(TabButton), Color.FromHex("#CCCCCC"));
        public Color BorderColor { get => (Color) GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(TabButton), Color.FromHex("#FFFFFF"));
        public Color SelectedColor { get => (Color) GetValue(SelectedColorProperty); set => SetValue(SelectedColorProperty, value); }
        public static readonly BindableProperty ActualBackgroundColorProperty = BindableProperty.Create("ActualBackgroundColor", typeof(Color), typeof(TabButton), Color.Transparent);
        public Color ActualBackgroundColor { get => (Color)GetValue(ActualBackgroundColorProperty); set => SetValue(ActualBackgroundColorProperty, value); }

        public static readonly BindableProperty IsVerticalProperty = BindableProperty.Create("IsVertical", typeof(bool), typeof(TabButton), false, propertyChanged: OnIsVerticalPropertyChanged);
        static void OnIsVerticalPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabButton) bindable).Update();
        public bool IsVertical { get => (bool) GetValue(IsVerticalProperty); set => SetValue(IsVerticalProperty, value); }

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(TabButton), false, propertyChanged: OnIsSelectedPropertyChanged);
        static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabButton) bindable).Update();
        public bool IsSelected { get => (bool) GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }

        public TabButton() {
            InitializeComponent();
            icon.BindingContext = this;            
        }
        void Update() {
            ActualBackgroundColor = IsSelected ? SelectedColor : BackgroundColor;
            this.horizontalBorder.IsVisible = !IsVertical;
            this.verticalBorder.IsVisible = IsVertical;
        }
    }
}