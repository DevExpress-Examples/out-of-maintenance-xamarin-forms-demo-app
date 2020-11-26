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
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.Models;
using DemoCenter.Forms.ViewModels.Services;

namespace DemoCenter.Forms.ViewModels {
    public class ErroViewModel : BaseViewModel {
        public string LogifyUrl => "https://logify.devexpress.com";
        public string CustomerExperienceUrl => "http://go.devexpress.com/DevExpress_Installer_CustomerExperience.aspx";
        public Exception CurrentException;

        public ICommand OpenWebCommand { get; }
        public ICommand SendExceptionCommand { get; }

        public ErroViewModel(Exception ex, IOpenUriService openService) {
            CurrentException = ex;

            OpenWebCommand = new DelegateCommand<String>((p) => openService.Open(p));
            SendExceptionCommand = new DelegateCommand(async () => await SendException(ex));
        }

        async Task SendException(Exception e) {
            ExceptionSender sender = new ExceptionSender();
            await Task.Run(() => {
                sender.SendException(e);
            });
        }

    }
}
