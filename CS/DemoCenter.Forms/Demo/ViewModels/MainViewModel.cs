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
using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.ViewModels.Services;

namespace DemoCenter.Forms.ViewModels {
    public class MainViewModel : BaseViewModel {
        public string Version => "0.0.0.0";
        public string TitleText => "DevExpress Mobile UI";
        public string SubTitle => "for Xamarin.Forms";
        public List<DemoItem> Items {
            get => DemoGroupsData.DemoItems;
        }
        public ICommand NavigationControlCommand { get; }
        public ICommand NavigationDemoCommand { get; }



        public MainViewModel(INavigationService navigationService) {
            NavigationControlCommand = new DelegateCommand<Type>((p) => {
                ControlViewModel vm = new ControlViewModel(navigationService, (IDemoData)Activator.CreateInstance(p));
                navigationService.Push(vm);
            });
            NavigationDemoCommand = new DelegateCommand<DemoItem>((p) => {
                navigationService.PushPage(p);
            });

        }
    }
}
