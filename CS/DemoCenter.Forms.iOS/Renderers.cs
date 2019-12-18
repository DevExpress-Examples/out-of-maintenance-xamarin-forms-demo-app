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

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGraphics;
using DemoCenter.Forms.Demo;
using DemoCenter.Forms.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ExtNavigationRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(ExtViewCellRenderer))]
[assembly: ExportRenderer(typeof(ListView), typeof(ExtListViewRenderer))]
[assembly: ExportRenderer(typeof(NonSelectableListView), typeof(NonSelectableListViewRenderer))]
[assembly: ExportRenderer(typeof(NonSelectableViewCell), typeof(NonSelectableViewCellRenderer))]
namespace DemoCenter.Forms.iOS {
    public class ExtNavigationRenderer : NavigationRenderer {
        bool pushedPage = false;
        bool layoutSubviewsCalling = false;
        UIDeviceOrientation currentOrientation = UIDeviceOrientation.Unknown;
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            currentOrientation = UIDevice.CurrentDevice.Orientation;
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
            DrawShadow();
            this.InteractivePopGestureRecognizer.Delegate = new PopDelegate(this.Element);
        }
        protected override Task<bool> OnPopViewAsync(Page page, bool animated) {
            CheckShadow(page);
            currentOrientation = UIDevice.CurrentDevice.Orientation;
            return base.OnPopViewAsync(page, animated);
        }
        protected override Task<bool> OnPushAsync(Page page, bool animated) {
            CheckShadow(page, true);
            currentOrientation = UIDevice.CurrentDevice.Orientation;
            pushedPage = true;
            return base.OnPushAsync(page, animated);
        }
        void DrawShadow() {
            NavigationBar.Layer.ShadowColor = UIColor.Black.CGColor;
            NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
        }
        void CheckShadow(Page page, bool pushed = false) {
            var stack = this.Element?.Navigation?.NavigationStack;
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
            if (currentOrientation != UIDevice.CurrentDevice.Orientation)
                return;
            if (!pushedPage && this.Element?.Navigation?.NavigationStack?.Count == 2) {
                UpdateShadowOpacityOnPop(this.Element?.Navigation?.NavigationStack);
            } else {
                if (!currentOrientation.IsLandscape() || layoutSubviewsCalling) {
                    pushedPage = false;
                    layoutSubviewsCalling = false;
                }
                else if(currentOrientation.IsLandscape()) {
                    layoutSubviewsCalling = true;
                }
            }
        }
    }

    class PopDelegate : UIGestureRecognizerDelegate {
        Element navElement;
        public PopDelegate(Element element) : base() {
            navElement = element;
        }
        public override bool ShouldBegin(UIGestureRecognizer recognizer) {
            var page = navElement.LogicalChildren.Last();
            return !DemoCenter.PlatformConfiguration.iOSSpecific.Page.GetDisablePopInteractive(page);
        }
    }

    public class ExtViewCellRenderer : ViewCellRenderer {
        readonly UIView selectedView = new UIView() { BackgroundColor = UIColor.FromRGBA(0, 0, 0, 48) };
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
            var cell = base.GetCell(item, reusableCell, tv);
            if(cell != null)
                cell.SelectedBackgroundView = selectedView;
            return cell;
        }
    }
    
    public class NonSelectableViewCellRenderer : ViewCellRenderer {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
            var cell = base.GetCell(item, reusableCell, tv);
            if(cell != null)
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            return cell;
        }
    }
    
    public class ExtListViewRenderer : ListViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
            base.OnElementChanged(e);
            if(Element != null) {
                Control.AlwaysBounceVertical = Element.IsPullToRefreshEnabled;
                Control.Bounces = Element.IsPullToRefreshEnabled;
            }
        }
    }
    public class NonSelectableListViewRenderer : ExtListViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
            base.OnElementChanged(e);
            if(Element != null) {
                Control.AllowsSelection = false;
            }
        }
    }
}
