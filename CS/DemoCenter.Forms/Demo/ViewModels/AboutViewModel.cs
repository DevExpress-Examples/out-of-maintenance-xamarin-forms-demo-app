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
using System.Reflection;
using System.Windows.Input;
using DemoCenter.Forms.ViewModels.Services;

namespace DemoCenter.Forms.ViewModels {
    public class AboutViewModel : BaseViewModel {
        string version;
        public string ProductTitle => "DevExpress.XF.DemoCenter";
        public string Version => version;
        public string ProductUrl => "https://www.devexpress.com/xamarin/";
        public string DocumentationUrl => "https://docs.devexpress.com/MobileControls/400545/xamarin-forms/index";
        public string SourceCodeUrl => "https://github.com/DevExpress-Examples/xamarin-forms-demo-app";
        public ICommand OpenWebCommand { get; }

        public AboutViewModel(IOpenUriService openService) {
            InitVersion();
            OpenWebCommand = new DelegateCommand<String>((p) => openService.Open(p));
        }
        void InitVersion() {
            Version assemblyVersion = Assembly.GetAssembly(this.GetType()).GetName().Version;
            version = $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
        }
    }
}
