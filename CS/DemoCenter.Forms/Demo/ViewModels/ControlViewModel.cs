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
using System.Windows.Input;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.ViewModels.Services;

namespace DemoCenter.Forms.ViewModels {
    public class ControlViewModel : BaseViewModel {
        IDemoData data;
        DemoItem selectedItem;
        public List<DemoItem> DemoItems {
            get => data.DemoItems;            
        }
        public DemoItem SelectedItem {
            get { return selectedItem; }
            set {
                selectedItem = value;
                if (selectedItem == null)
                    return;
                NavigationDemoCommand.Execute(selectedItem);
            }
        }
        public ICommand NavigationDemoCommand { get; }

        public ControlViewModel(INavigationService navigationService, IDemoData data) {
            this.data = data;
            this.Title = data.Title;
            NavigationDemoCommand = new DelegateCommand<DemoItem>((p) => navigationService.PushPage(p));
        }
        
    }
}
