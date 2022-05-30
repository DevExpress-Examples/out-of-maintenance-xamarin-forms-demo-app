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
using System;
using System.Collections.Generic;
using DemoCenter.Forms.Data;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class HeadphoneComparisonViewModel : ChartViewModelBase {
        readonly HeadphonesData headphonesData;
        readonly Color[] palette = PaletteLoader.LoadPalette("#317cb9", "#75b8ef", "#f14848", "#fe908f");
        readonly IList<String> names;

        public IList<NumericData> FirstHeadphones90 => headphonesData.FirstHeadphones90;
        public IList<NumericData> FirstHeadphones100 => headphonesData.FirstHeadphones100;
        public IList<NumericData> SecondHeadphones90 => headphonesData.SecondHeadphones90;
        public IList<NumericData> SecondHeadphones100 => headphonesData.SecondHeadphones100;
        public IList<String> Names => names;
        public Color[] Palette => palette;

        public HeadphoneComparisonViewModel() {
            headphonesData = new HeadphonesData();
            names = new List<String>() {
                "Headphones 1 90 dB SPL",
                "Headphones 1 100 dB SPL",
                "Headphones 2 90 dB SPL",
                "Headphones 2 100 dB SPL" };
        }
    }
}
