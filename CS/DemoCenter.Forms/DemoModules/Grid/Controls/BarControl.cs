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
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public class BarControl : ContentView {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(double), typeof(BarControl), 0d, propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(double), typeof(BarControl), 0d, propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create("Color", typeof(Color), typeof(BarControl), Color.LightCyan, propertyChanged: OnColorChanged);

        static void OnLayoutChanged(BindableObject bindable, object oldValue, object newValue) {
            ((BarControl)bindable).InvalidateLayout();
        }

        static void OnColorChanged(BindableObject bindable, object oldValue, object newValue) {
            ((BarControl)bindable).UpdateColor();
        }

        public BarControl() {
            Content = new Frame() {
                BackgroundColor = Color,
                HasShadow = false,
                CornerRadius = 0
            };
        }

        public double Value {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double MaxValue {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public Color Color {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        void UpdateColor() {
            ((Frame)Content).BackgroundColor = Color;
        }

        protected override void LayoutChildren(double x, double y, double width, double height) {
            double actualWidth = Math.Min(Value / MaxValue * width, width);
            base.LayoutChildren(0, y, actualWidth, height);
        }
    }
}
