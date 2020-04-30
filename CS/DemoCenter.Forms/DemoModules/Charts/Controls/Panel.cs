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
    public class Panel : Layout<View> {
        public static readonly BindablePropertyKey IsLandscapePropertyKey = BindableProperty.CreateReadOnly("IsLandscape", typeof(bool), typeof(Panel), false);
        public static readonly BindableProperty IsLandscapeProperty = IsLandscapePropertyKey.BindableProperty;
        public bool IsLandscape { get => (bool) GetValue(IsLandscapeProperty); }

        public Panel() {
            SizeChanged += (s, e) => UpdateOrientation(Width, Height);
            UpdateOrientation(Width, Height);
        }

        void UpdateOrientation(double width, double height) {
            SetValue(IsLandscapePropertyKey, width > height);
        }

        protected override void LayoutChildren(double x, double y, double width, double height) {
            UpdateOrientation(Width, Height);
            int visibleChildCount = 0;
            foreach (View child in Children)
                visibleChildCount += child.IsVisible ? 1 : 0;
            if (visibleChildCount > 0) {
                double itemSize = (IsLandscape ? width : height) / visibleChildCount;
                double offset = 0;
                foreach(View child in Children)
                    if (child.IsVisible) {
                        if (IsLandscape)
                            LayoutChildIntoBoundingRegion(child, new Rectangle(x + offset, y, itemSize, height));
                        else
                            LayoutChildIntoBoundingRegion(child, new Rectangle(x, y + offset, width, itemSize));
                        offset += itemSize;
                    }
            }
        }
    }
}
