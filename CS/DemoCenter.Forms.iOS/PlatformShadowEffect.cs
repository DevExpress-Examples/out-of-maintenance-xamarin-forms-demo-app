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
using System;
using System.Linq;
using CoreGraphics;
using DemoCenter.Forms.Effects;
using DemoCenter.Forms.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;

[assembly: ResolutionGroupName("DemoCenter")]
[assembly: ExportEffect(typeof(PlatformShadowEffect), "PlatformShadowEffect")]
namespace DemoCenter.Forms.iOS {
    [Preserve(AllMembers = true)]
    public class PlatformShadowEffect : PlatformEffect {
        protected override void OnAttached() {
            try {
                UIView control = Control as UIView;
                if(control == null)
                    control = Container as UIView;
                ShadowEffect effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null && control != null) {
                    control.Layer.ShadowRadius = effect.Radius;
                    control.Layer.ShadowColor = effect.Color.ToCGColor();
                    control.Layer.ShadowOffset = new CGSize(effect.DistanceX, effect.DistanceY);
                    control.Layer.ShadowOpacity = effect.Opacity;
                }
            } catch (Exception ex) {
                Console.WriteLine("Cannot set property on attached control. Error: " + ex.Message);
            }
        }

        protected override void OnDetached() {
        }
    }
}
