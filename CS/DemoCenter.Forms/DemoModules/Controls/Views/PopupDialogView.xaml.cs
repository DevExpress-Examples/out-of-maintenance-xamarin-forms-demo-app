/*
               Copyright (c) 2015-2021 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2021 Developer Express Inc.              }
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
using System.Linq;
using DemoCenter.Forms.DemoModules.CollectionView.Data;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Popup.Views {
    public partial class PopupDialogView : ContentPage {

        PopupDialogViewModel viewModel;
        bool isAnimated;

        public PopupDialogView() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();

            this.viewModel = new PopupDialogViewModel(new EmployeeTasksRepository());

            BindingContext = this.viewModel;
        }

        void OnTap(object sender, DevExpress.XamarinForms.CollectionView.CollectionViewGestureEventArgs e) {
            this.viewModel.PreparePopupAndOpen(e.Item as EmployeeTask, e.ItemHandle);
        }

        void DismissPopup(object sender, EventArgs e) {
            this.viewModel.IsOpenPopup = false;
        }

        void PinClick(object sender, EventArgs e) {
            this.viewModel.ActiveItem.Status = TaskStatus.Urgent;
            OnStatusChanged();
        }

        void DoneClick(object sender, EventArgs e) {
            this.viewModel.ActiveItem.Status = TaskStatus.Completed;
            OnStatusChanged();
        }

        void ToDoClick(object sender, EventArgs e) {
            this.viewModel.ActiveItem.Status = TaskStatus.Uncompleted;
            OnStatusChanged();
        }

        void DeleteClick(object sender, EventArgs e) {
            this.viewModel.IsOpenPopup = false;
            this.collectionView.DeleteItem(this.viewModel.ItemHandle);
        }

        void OnStatusChanged() {
            if (this.isAnimated) return;

            this.viewModel.IsOpenPopup = false;

            IList<EmployeeTask> source = this.viewModel.ItemSource;

            int newItemHandle = 0;

            switch (this.viewModel.ActiveItem.Status) {
                case TaskStatus.Urgent:
                    newItemHandle = 0;
                    break;
                case TaskStatus.Completed:
                    newItemHandle = source.Count() - 1;
                    break;
                case TaskStatus.Uncompleted:
                    newItemHandle = source.Where(t => t.Status == TaskStatus.Urgent).Count();
                    break;
            }

            if (this.viewModel.ItemHandle == newItemHandle)
                return;

            this.isAnimated = true;
            Device.BeginInvokeOnMainThread(() =>
                this.collectionView.MoveItem(this.viewModel.ItemHandle, newItemHandle, () => this.isAnimated = false)
            );
        }
    }
}
