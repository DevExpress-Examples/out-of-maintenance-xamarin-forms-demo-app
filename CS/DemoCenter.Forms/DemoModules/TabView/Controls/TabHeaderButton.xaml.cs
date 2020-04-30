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
using Xamarin.Forms;

namespace DemoCenter.Forms.Demo {
    public partial class TabHeaderButton : StackLayout {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(TabHeaderButton), false, propertyChanged: OnIsSelectedPropertyChanged);
        static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateSelection();
        public bool IsSelected { get => (bool)GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }

        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(TabHeaderButton), propertyChanged: OnTextPropertyChanged, defaultValue: string.Empty);
        static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateText();
        public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(TabHeaderButton), propertyChanged: OnTextColorPropertyChanged, defaultValue: Color.Default);
        static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateTextColor();
        public Color TextColor { get => (Color)GetValue(TextColorProperty); set => SetValue(TextColorProperty, value); }

        public static readonly BindableProperty IconColorProperty = BindableProperty.Create("IconColor", typeof(Color), typeof(TabHeaderButton), propertyChanged: OnIconColorPropertyChanged, defaultValue: Color.Default);
        static void OnIconColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateIconColor();
        public Color IconColor { get => (Color)GetValue(IconColorProperty); set => SetValue(IconColorProperty, value); }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(TabHeaderButton), propertyChanged: OnFontFamilyPropertyChanged, defaultValue: string.Empty);
        static void OnFontFamilyPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateFontFamily();
        public string FontFamily { get => (string)GetValue(FontFamilyProperty); set => SetValue(FontFamilyProperty, value); }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(TabHeaderButton), propertyChanged: OnFontSizePropertyChanged);
        static void OnFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateFontSize();
        public double FontSize { get => (double)GetValue(FontSizeProperty); set => SetValue(FontSizeProperty, value); }

        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create("SelectedBackgroundColor", typeof(Color), typeof(TabHeaderButton), propertyChanged: OnSelectedBackgroundColorPropertyChanged, defaultValue: Color.Default);
        static void OnSelectedBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateBackgroundSelection();
        public Color SelectedBackgroundColor { get => (Color)GetValue(SelectedBackgroundColorProperty); set => SetValue(SelectedBackgroundColorProperty, value); }

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(TabHeaderButton), propertyChanged: OnSelectedColorPropertyChanged, defaultValue: Color.Default);
        static void OnSelectedColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateColorSelection();
        public Color SelectedColor { get => (Color)GetValue(SelectedColorProperty); set => SetValue(SelectedColorProperty, value); }

        public static readonly BindableProperty ShowIconProperty = BindableProperty.Create("ShowIcon", typeof(bool), typeof(TabHeaderButton), false, propertyChanged: OnShowIconPropertyChanged);
        static void OnShowIconPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateShowIcon();
        public bool ShowIcon { get => (bool)GetValue(ShowIconProperty); set => SetValue(ShowIconProperty, value); }

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create("IconSource", typeof(string), typeof(TabHeaderButton), propertyChanged: OnIconSourcePropertyChanged, defaultValue: string.Empty);
        static void OnIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabHeaderButton)bindable).UpdateIconSource();
        public string IconSource { get => (string)GetValue(IconSourceProperty); set => SetValue(IconSourceProperty, value); }

        public TabHeaderButton() {
			InitializeComponent();
            UpdateShowIcon();
        }

        void UpdateText() {
            label.Text = Text;
        }
        void UpdateTextColor() {
            label.TextColor = TextColor;
        }
        void UpdateIconColor() {
            icon.ForegroundColor = IconColor;
        }
        void UpdateFontFamily() {
            label.FontFamily = FontFamily;
        }
        void UpdateFontSize() {
            label.FontSize = FontSize;
        }
        void UpdateSelection() {
            UpdateBackgroundSelection();
            UpdateColorSelection();
        }
        void UpdateBackgroundSelection() {
            Color color = Color.Transparent;
            if(IsSelected && SelectedBackgroundColor != Color.Default) {
                color = SelectedBackgroundColor;
            }
            BackgroundColor = color;
            label.BackgroundColor = color;
        }
        void UpdateColorSelection() {
            Color textColor = TextColor;
            Color iconColor = IconColor;
            if(IsSelected && SelectedColor != Color.Default) {
                textColor = SelectedColor;
                iconColor = SelectedColor;
            }
            label.TextColor = textColor;
            icon.ForegroundColor = iconColor;
        }
        void UpdateShowIcon() {
            this.Children.Clear();
            if(ShowIcon) {
                this.Children.Add(icon);
                this.Children.Add(label);
            } else {
                label.VerticalOptions = LayoutOptions.CenterAndExpand;
                label.VerticalTextAlignment = TextAlignment.Center;
                
                this.Children.Add(label);
            }
        }
        void UpdateIconSource() {
            icon.ImageSource = IconSource;
        }
    }
}