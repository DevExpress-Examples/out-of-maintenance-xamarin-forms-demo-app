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
﻿using System;
using DevExpress.XamarinForms.Core.Themes;
using Xamarin.Forms;

namespace DemoCenter.Forms.Demo {
    public partial class IconView: Image {
        public static readonly BindableProperty ThemeNameProperty = BindableProperty.Create("ThemeName", typeof(string),
            typeof(IconView), propertyChanged: ThemeNamePropertyChanged, defaultValue: Theme.Light);

        static void ThemeNamePropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((IconView)bindable).OnThemeNameChanged((string)newValue);

        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create("ForegroundColor",
            typeof(Color), typeof(IconView), defaultValue: Color.Default,
            propertyChanged: ForegroundColorPropertyChanged);

        static void ForegroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) { }

        public IconView() {
            InitializeComponent();
            if (App.Current is DemoCenter.Forms.App demoCenterApp) {
                demoCenterApp.ThemeChagedEvent += DemoCenterApp_ThemeChagedEvent;
            }
        }
        
        private void DemoCenterApp_ThemeChagedEvent(object sender, EventArgs e) {
            if(Source is FileImageSource)
                OnPropertyChanged(nameof(Image.Source));
        }
        
        public string ThemeName {
            get => (string)GetValue(ThemeNameProperty);
            set => SetValue(ThemeNameProperty, value);
        }

        public Color ForegroundColor {
            get => (Color)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        void OnThemeNameChanged(string newValue) {
        }

    }
}
