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
using System.Collections.Generic;
using System.IO;
using DevExpress.XamarinForms.Core.Themes;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using SKSvg = SkiaSharp.Extended.Svg.SKSvg;

namespace DemoCenter.Forms.Demo {
    public partial class SVGIconView : SKCanvasView {
        static Dictionary<string, SKPicture> imagesCache = new Dictionary<string, SKPicture>();

        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create("ForegroundColor",
           typeof(Color), typeof(SVGIconView), defaultValue: Color.Default,
           propertyChanged: ForegroundColorPropertyChanged);

        public static readonly BindableProperty SaveRatioOnScaleProperty = BindableProperty.Create("SaveRatioOnScale",
           typeof(bool), typeof(SVGIconView), defaultValue: true);

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource",
           typeof(string), typeof(SVGIconView), propertyChanged: ImageSourcePropertyChanged);

        public static readonly BindableProperty ThemeNameProperty = BindableProperty.Create("ThemeName", typeof(string),
           typeof(SVGIconView), propertyChanged: ThemeNamePropertyChanged, defaultValue: Theme.Light);

        public static SKPicture LoadImage(string imageName, string themeName, bool force = false) {
            System.Reflection.Assembly assembly = typeof(SVGIconView).Assembly;
            string value = GetThemedImageSourceName(themeName, imageName);
            if (!imagesCache.ContainsKey(value)) {
                if (assembly.GetManifestResourceInfo(value) == null) {
                    value = imageName;
                }

            }
            return LoadIconFromResource(value, assembly);
        }

        static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
           ((SVGIconView)bindable).OnImageSourceChanged((string)newValue);

        static void ForegroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
           ((SVGIconView)bindable).InvalidateSurface();

        static void ThemeNamePropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
           ((SVGIconView)bindable).OnThemeNameChanged((string)newValue);

        static string GetThemedImageSourceName(string themeName, string imageName) {
            return String.Format("{0}.{1}", themeName, imageName);
        }

        static SKPicture LoadIconFromResource(string resourceName, System.Reflection.Assembly assembly, bool force = false) {
            SKPicture img;
            if (!imagesCache.TryGetValue(resourceName, out img) || force) {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                    if (stream == null)
                        return null;
                    img = LoadSvgFromStream(stream);
                    imagesCache[resourceName] = img;
                }
            }
            return img;
        }

        static SKPicture LoadSvgFromStream(Stream stream) {
            return new SKSvg().Load(stream);
        }

        private SKPicture svg;
        private SKMatrix matrix;
        private bool matrixBuilt;
        private double width;
        private double height;

        public SVGIconView() {
            InitializeComponent();
        }

        public Color ForegroundColor {
            get => (Color)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }

        public string ImageSource {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public string ThemeName {
            get => (string)GetValue(ThemeNameProperty);
            set => SetValue(ThemeNameProperty, value);
        }

        public bool SaveRatioOnScale {
            get => (bool)GetValue(SaveRatioOnScaleProperty);
            set => SetValue(SaveRatioOnScaleProperty, value);
        }

        void OnThemeNameChanged(string newValue) {
            if (String.IsNullOrEmpty(ImageSource) || imagesCache.ContainsKey(ImageSource)) {
                return;
            }
            OnImageSourceChanged(ImageSource);
        }

        void OnImageSourceChanged(string newValue, bool updateCache = false) {
            if (!string.IsNullOrWhiteSpace(newValue)) {
                svg = LoadImage(newValue, ThemeName, updateCache);
            } else {
                svg = null;
            }
            this.InvalidateSurface();
        }

        void Handle_PaintSurface(object sender, SKPaintSurfaceEventArgs e) {
            if (svg != null) {
                if (!matrixBuilt) {
                    SKSize info = e.Info.Size;
                    float scaleX = info.Width / svg.CullRect.Width;
                    float scaleY = info.Height / svg.CullRect.Height;
                    if (SaveRatioOnScale) {
                        float scale = Math.Min(scaleX, scaleY);
                        matrix = SKMatrix.CreateScale(scale, scale);
                    } else
                        matrix = SKMatrix.CreateScale(scaleX, scaleY);
                    matrixBuilt = true;
                }

                SKPaint paint = null;
                var canvas = e.Surface.Canvas;

                canvas.Clear();
                if (ForegroundColor != Color.Default) {
                    paint = new SKPaint();
                    paint.ColorFilter =
                        SKColorFilter.CreateBlendMode(ForegroundColor.ToSKColor(), SKBlendMode.SrcIn);
                }

                if (svg != null) {
                    canvas?.DrawPicture(svg, ref matrix, paint);
                    paint?.Dispose();
                }
                canvas.Flush();
            }
        }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            if (Math.Abs(this.width - width) > Double.Epsilon || Math.Abs(this.height - height) > Double.Epsilon) {
                matrixBuilt = false;
                this.width = width;
                this.height = height;
            }
        }
    }
}
