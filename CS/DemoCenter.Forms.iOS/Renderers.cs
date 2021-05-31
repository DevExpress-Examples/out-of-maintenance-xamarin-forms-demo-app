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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphics;
using DemoCenter.Forms.Demo;
using DemoCenter.Forms.iOS;
using DemoCenter.Forms.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ExtNavigationRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(ExtViewCellRenderer))]
[assembly: ExportRenderer(typeof(ListView), typeof(ExtListViewRenderer))]
[assembly: ExportRenderer(typeof(NonSelectableListView), typeof(NonSelectableListViewRenderer))]
[assembly: ExportRenderer(typeof(NonSelectableViewCell), typeof(NonSelectableViewCellRenderer))]
[assembly: ExportRenderer(typeof(BouncelessCollectionView), typeof(BouncelessCollectionViewRenderer))]
[assembly: ExportRenderer(typeof(IconView), typeof(IconViewRenderer))]
[assembly: ExportRenderer(typeof(AboutView), typeof(AboutViewRenderer))]
namespace DemoCenter.Forms.iOS {
    public class ExtNavigationRenderer : NavigationRenderer {
        bool pushedPage = false;
        bool layoutSubviewsCalling = false;
        UIDeviceOrientation currentOrientation = UIDeviceOrientation.Unknown;
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            this.currentOrientation = UIDevice.CurrentDevice.Orientation;
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
            DrawShadow();
            InteractivePopGestureRecognizer.Delegate = new PopDelegate(Element);
        }
        public override void ViewWillAppear(bool animated) {
            base.ViewWillAppear(animated);
        }
        protected override Task<bool> OnPopViewAsync(Page page, bool animated) {
            CheckShadow(page);
            this.currentOrientation = UIDevice.CurrentDevice.Orientation;
            return base.OnPopViewAsync(page, animated);
        }
        protected override Task<bool> OnPushAsync(Page page, bool animated) {
            CheckShadow(page, true);
            this.currentOrientation = UIDevice.CurrentDevice.Orientation;
            this.pushedPage = true;
            return base.OnPushAsync(page, animated);
        }
        void DrawShadow() {
            NavigationBar.Layer.ShadowColor = UIColor.Black.CGColor;
            NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
        }
        void CheckShadow(Page page, bool pushed = false) {
            IReadOnlyList<Page> stack = Element?.Navigation?.NavigationStack;
            if (pushed) {
                bool showShadow = stack?.Count > 1 ||
                                  TitleViewExtensions.GetIsShadowVisible(page);
                NavigationBar.Layer.ShadowOpacity = showShadow ? 0.5f : 0;
            } else {
                UpdateShadowOpacityOnPop(stack, page);
            }
        }

        void UpdateShadowOpacityOnPop(IReadOnlyList<Page> stack, Page page = null) {
            if (stack != null && stack.Count <= 2) {
                bool shadowPropertyValue = false;
                if (stack.Count > 1) {
                    Page newPage = stack[stack.Count - 2];
                    shadowPropertyValue = TitleViewExtensions.GetIsShadowVisible(newPage);
                }

                bool hideShadow =
                    (page != null && stack?.Last<Page>() == page)
                    && !shadowPropertyValue;
                NavigationBar.Layer.ShadowOpacity = hideShadow ? 0 : 0.5f;
            }
        }

        public override void ViewWillLayoutSubviews() {
            base.ViewWillLayoutSubviews();
            if (this.currentOrientation != UIDevice.CurrentDevice.Orientation)
                return;
            if (!this.pushedPage && Element?.Navigation?.NavigationStack?.Count == 2) {
                UpdateShadowOpacityOnPop(Element?.Navigation?.NavigationStack);
            } else {
                if (!this.currentOrientation.IsLandscape() || this.layoutSubviewsCalling) {
                    this.pushedPage = false;
                    this.layoutSubviewsCalling = false;
                } else if (this.currentOrientation.IsLandscape()) {
                    this.layoutSubviewsCalling = true;
                }
            }
        }
    }

    class PopDelegate: UIGestureRecognizerDelegate {
        readonly Element navElement;
        public PopDelegate(Element element) : base() {
            this.navElement = element;
        }
        public override bool ShouldBegin(UIGestureRecognizer recognizer) {
            Element page = this.navElement.LogicalChildren.Last();
            return !PlatformConfiguration.iOSSpecific.Page.GetDisablePopInteractive(page);
        }
    }

    [Preserve(AllMembers = true)]
    public class ExtViewCellRenderer: ViewCellRenderer {
        readonly UIView selectedView = new UIView() { BackgroundColor = UIColor.FromRGBA(0, 0, 0, 48) };
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
            UITableViewCell cell = base.GetCell(item, reusableCell, tv);
            if (cell != null)
                cell.SelectedBackgroundView = this.selectedView;
            return cell;
        }
    }

    [Preserve(AllMembers = true)]
    public class NonSelectableViewCellRenderer: ViewCellRenderer {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
            UITableViewCell cell = base.GetCell(item, reusableCell, tv);
            if (cell != null)
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            return cell;
        }
    }

    public class ExtListViewRenderer: ListViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
            base.OnElementChanged(e);
            if (Element != null) {
                Control.AlwaysBounceVertical = Element.IsPullToRefreshEnabled;
                Control.Bounces = Element.IsPullToRefreshEnabled;
            }
        }
    }

    public class NonSelectableListViewRenderer: ExtListViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
            base.OnElementChanged(e);
            if (Element != null) {
                Control.AllowsSelection = false;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == nameof(NonSelectableListView.ScrollsToTop) && Element is NonSelectableListView listView) {
                Control.ScrollsToTop = listView.ScrollsToTop;
            }
        }
    }

    public class BouncelessCollectionViewRenderer : CollectionViewRenderer {
        UICollectionView CollectionView => (UICollectionView)Control.Subviews[0];
        BouncelessCollectionView CollectionElement => (BouncelessCollectionView)Element;

        protected override void OnElementChanged(ElementChangedEventArgs<GroupableItemsView> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                CollectionView.AlwaysBounceVertical = false;
                CollectionView.Bounces = false;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(BouncelessCollectionView.ScrollsToTop)) {
                CollectionView.ScrollsToTop = CollectionElement.ScrollsToTop;
            }
        }
    }

    public class IconViewRenderer: ImageRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
            base.OnElementChanged(e);
            if (Element is IconView iconView && Control != null) {
                SetOverrideUserInterfaceStyle(iconView.ThemeName);
                SetImageColor(iconView.ForegroundColor);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(IconView.ThemeName)) {
                if (sender is IconView iconView && Control != null)
                    SetOverrideUserInterfaceStyle(iconView.ThemeName);
            }
            if (e.PropertyName == nameof(IconView.Source)) {
                IconView iconView = sender as IconView;
                SetImageColor(iconView.ForegroundColor);
            }
            if (e.PropertyName == nameof(IconView.ForegroundColor)) {
                IconView iconView = sender as IconView;
                SetImageColor(iconView.ForegroundColor);
            }
        }
        void SetOverrideUserInterfaceStyle(string themeName) {
            if (Control == null || !UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
                return;
            UIUserInterfaceStyle userInterfaceStyle = themeName == "Light" ? UIUserInterfaceStyle.Light : UIUserInterfaceStyle.Dark;
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0)) {
                Control.OverrideUserInterfaceStyle = userInterfaceStyle;
            }
        }
        private void SetImageColor(Color iconColor) {
            if (Element.Source != null && Control.Image != null) {
                UIImageRenderingMode renderingMode = iconColor == null || iconColor == Color.Default || iconColor == Color.Transparent ? UIImageRenderingMode.Automatic : UIImageRenderingMode.AlwaysTemplate;
                Control.Image = Control.Image.ImageWithRenderingMode(renderingMode);
                Control.TintColor = iconColor.ToUIColor();
            }
        }
    }
    public class AboutViewRenderer: ScrollViewRenderer {
        public AboutViewRenderer() {
        }
        protected override void OnElementChanged(VisualElementChangedEventArgs e) {
            base.OnElementChanged(e);
            Element.PropertyChanged += Element_PropertyChanged;
            SetScrollsToTop(false);
        }
        private void Element_PropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == nameof(AboutView.OpenedByParent)) {
                if (sender is AboutView aboutView) {
                    SetScrollsToTop(aboutView.OpenedByParent);
                }
            }
        }
        void SetScrollsToTop(bool scrollsTotop) {
            UIScrollView scrollView = (UIScrollView)NativeView;
            if (scrollView != null) {
                scrollView.ScrollsToTop = scrollsTotop;
            }
        }
    }
}
