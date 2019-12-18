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
    public partial class RadioButton : ContentView {
        public static readonly BindableProperty ThemeNameProperty = BindableProperty.Create(
            nameof(RadioButton.ThemeName), typeof(string), typeof(RadioButton),
            propertyChanged: ThemeNamePropertyChanged);

        static void ThemeNamePropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((RadioButton) bindable).OnThemeNameChanged((string) newValue);

        public string ThemeName {
            get => (string) GetValue(ThemeNameProperty);
            set => SetValue(ThemeNameProperty, value);
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(RadioButton.IsSelected), typeof(bool), typeof(RadioButton),
                propertyChanged: SelectedPropertyChanged, defaultBindingMode: BindingMode.TwoWay);

        static void SelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((RadioButton) bindable).OnSelectedChanged((bool) newValue);

        public bool IsSelected {
            get => (bool) GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }


        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(RadioButton.LabelText), typeof(string), typeof(RadioButton));

        public string LabelText {
            get => (string) GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public static readonly BindableProperty BackgroundImageProperty =
            BindableProperty.Create(nameof(RadioButton.BackgroundImage), typeof(string), typeof(RadioButton));

        public string BackgroundImage {
            get => (string) GetValue(BackgroundImageProperty);
            private set => SetValue(BackgroundImageProperty, value);
        }


        public RadioButton() {
            OnSelectedChanged(this.IsSelected);
            this.BindingContext = this;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                if (!this.IsSelected)
                    this.IsSelected = true;
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
            InitializeComponent();                 
        }

        private void OnThemeNameChanged(string newValue) {
        }

        private void OnSelectedChanged(bool newValue) {
            this.BackgroundImage = IsSelected ? "Radio.Checked.Background.svg" : "Radio.Background.svg";
        }
    }
}
