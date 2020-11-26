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
using System.Collections.Generic;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using DemoCenter.Forms.Demo;
using DemoCenter.Forms.Droid;
using DemoCenter.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(ContentPage), typeof(ExtContentPageRenderer))]
[assembly: ExportRenderer(typeof(NonSelectableListView), typeof(NonSelectableListViewRenderer))]
[assembly: ExportRenderer(typeof(DXDCLabel), typeof(DXDCLabelRenderer))]
[assembly: ExportRenderer(typeof(IconView), typeof(IconViewRenderer))]

namespace DemoCenter.Forms.Droid {
    class DXDCLabelRenderer : LabelRenderer {
        public DXDCLabelRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e) {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;
            Control.SetTextSize(Android.Util.ComplexUnitType.Dip, (float)e.NewElement.FontSize);
            Control.ScrollBarSize = 0;
        }
    }
    public class ExtContentPageRenderer: PageRenderer {
        static readonly Dictionary<object, bool> elevations = new Dictionary<object, bool>();
        static IReadOnlyList<Page> Stack;
        const int MAINPAGE_INDEX = 1;

        public ExtContentPageRenderer(Context context) : base(context) { }

        protected override void OnAttachedToWindow() {
            base.OnAttachedToWindow();
            SetToolBarShadow(Element);
        }
        protected override void OnDetachedFromWindow() {
            base.OnDetachedFromWindow();
            SetToolBarShadow();
        }

        void SetToolBarShadow(object element = null) {
            IEnumerable<Toolbar> toolBars = GetToolbars();
            if(element is MainPage page) {
                Stack = page.Navigation.NavigationStack;
            }
            if (Stack == null)
                return;
            bool showShadow = Stack.Count > MAINPAGE_INDEX;
            if (element != null) {
                if (!elevations.ContainsKey(element)) {
                    elevations.Add(element, showShadow);
                }
                foreach(Toolbar toolBar in toolBars)
                    toolBar.Elevation = elevations[element] ? 20 : 0;
            } else {
                foreach (Toolbar toolBar in toolBars)
                    toolBar.Elevation = showShadow ? 20 : 0;
            }
        }

        IList<Toolbar> FindParentRootIfExist(Toolbar toolBar) {
            IList<Toolbar> result = new List<Toolbar>();
            IViewParent currentParent = toolBar;
            while (currentParent != null) {
                currentParent = currentParent.Parent;
                if (currentParent is Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer navRenderer) {
                    for (int i = navRenderer.ChildCount - 1; i >= 0; i--)
                        if (navRenderer.GetChildAt(i) is Toolbar toolbar)
                            result.Add(toolbar);
                }
            }
            return result;
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh) {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (oldw > 0 && oldh > 0 && Element.Navigation?.NavigationStack?.Count != 0) {
                SetToolBarShadow(Element);
            }
        }
        IEnumerable<Toolbar> GetToolbars() {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop) {
                Activity context = (Activity)Context;
                return FindParentRootIfExist(context?.FindViewById<Toolbar>(Resource.Id.toolbar));
            }
            return System.Linq.Enumerable.Empty<Toolbar>();
        }
    }
    public class NonSelectableListViewRenderer : ListViewRenderer {
        public NonSelectableListViewRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.OverScrollMode = Android.Views.OverScrollMode.Never;
            }
            if(e.NewElement != null) {
                Control.Clickable = false;
            }
        }
    }

    public class IconViewRenderer:ImageRenderer {
        public IconViewRenderer(Context context):base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
            base.OnElementChanged(e);
            UpdateBitmapColor((Element as IconView).ForegroundColor);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            IconView iconView = sender as IconView;
            if (e.PropertyName == nameof(IconView.Source)) {
                UpdateBitmapColor(iconView.ForegroundColor);
            } else if (e.PropertyName == nameof(IconView.ForegroundColor)) {
                UpdateBitmapColor(iconView.ForegroundColor);
            }
        }

        private void UpdateBitmapColor(Color iconColor) {
            if (Control == null || Control.Drawable == null)
                return;

            if (iconColor == Color.Default && IsEmptyColorFilter())
                return;

            ColorFilter colorFilter = iconColor == Color.Default ? null : new PorterDuffColorFilter(iconColor.ToAndroid(), PorterDuff.Mode.SrcAtop);

            Drawable drawable = Control.Drawable.Mutate();

            drawable.SetColorFilter(colorFilter);

            Control.SetImageDrawable(drawable);
        }

        private bool IsEmptyColorFilter() {
            if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                return Control.Drawable.ColorFilter == null;
            }
            return true;
        }
    }
}
