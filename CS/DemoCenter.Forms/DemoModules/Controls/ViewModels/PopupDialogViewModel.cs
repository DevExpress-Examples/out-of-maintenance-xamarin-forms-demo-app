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
﻿using System;
using System.Collections.Generic;
using DemoCenter.Forms.DemoModules.CollectionView.Data;

namespace DemoCenter.Forms.ViewModels {

    public class PopupDialogViewModel: NotificationObject {
        readonly EmployeeTasksRepository repository;

        public int ItemHandle { get; private set; }
        public EmployeeTask ActiveItem { get; private set; }

        string popupTitle;
        public string PopupTitle {
            get => this.popupTitle;
            set => SetProperty(ref this.popupTitle, value);
        }

        bool buttonPinVisible = false;
        public bool ButtonPinVisible {
            get => this.buttonPinVisible;
            set => SetProperty(ref this.buttonPinVisible, value);
        }

        bool buttonDoneVisible = false;
        public bool ButtonDoneVisible {
            get => this.buttonDoneVisible;
            set => SetProperty(ref this.buttonDoneVisible, value);
        }

        bool buttonToDoVisible = false;
        public bool ButtonToDoVisible {
            get => this.buttonToDoVisible;
            set => SetProperty(ref this.buttonToDoVisible, value);
        }

        bool isOpenPopup;
        public bool IsOpenPopup {
            get => this.isOpenPopup;
            set => SetProperty(ref this.isOpenPopup, value);
        }

        public IList<EmployeeTask> ItemSource => this.repository.EmployeeTasks;

        public PopupDialogViewModel(EmployeeTasksRepository repository) {
            this.repository = repository;
        }

        public void PreparePopupAndOpen(EmployeeTask item, int handle) {
            ActiveItem = item;
            ItemHandle = handle;

            PopupTitle = item.Name;
            ButtonPinVisible = item.Status == TaskStatus.Uncompleted;
            ButtonDoneVisible = item.Status == TaskStatus.Urgent || item.Status == TaskStatus.Uncompleted;
            ButtonToDoVisible = item.Status == TaskStatus.Completed;

            IsOpenPopup = true;
        }

    }
}
