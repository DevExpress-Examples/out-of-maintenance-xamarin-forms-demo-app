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
using DemoCenter.Forms.ViewModels;

namespace DemoCenter.Forms.Charts.ViewModels {
    public abstract class ChartsViewModelBase : NotificationObject {
        ChartItemInfoContainerBase selectedItem;
        bool isVertical;
        public ChartItemInfoContainerBase SelectedItem {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value, onChanged: (oldValue, newValue) => {
                ResetSelectedItem(oldValue);
                if(newValue != null) newValue.IsSelected = true;
            });
        }
        public bool IsVertical {
            get => isVertical;
            set => SetVerticalState(value);
        }
        public void SetVerticalState(bool vertical) {
            isVertical = vertical;
            foreach(ChartItemInfoContainerBase curentItem in Content) {
                curentItem.IsVertical = vertical;
            }
        }
        public abstract List<ChartItemInfoContainerBase> Content { get; }
        void ResetSelectedItem(ChartItemInfoContainerBase oldSelectedItem) {
            if(oldSelectedItem != null) {
                oldSelectedItem.IsSelected = false;
            } else {
                foreach(ChartItemInfoContainerBase curentItem in Content) {
                    if(curentItem.IsSelected) {
                        curentItem.IsSelected = false;
                        return;
                    }
                }
            }
        }
    }

}
