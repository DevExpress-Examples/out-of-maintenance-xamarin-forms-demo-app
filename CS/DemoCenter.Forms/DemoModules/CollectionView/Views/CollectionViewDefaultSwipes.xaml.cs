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
using DevExpress.XamarinForms.CollectionView;
using Xamarin.Forms;

namespace DemoCenter.Forms {
    class ItemDataTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is EmployeeTask task))
                return null;

            switch (task.Status) {
                case TaskStatus.Urgent:
                    return UrgentDataTemplate;
                case TaskStatus.Completed:
                    return CompletedDataTemplate;
                case TaskStatus.Uncompleted:
                default:
                    return UncompletedDataTemplate;
            }
        }

        public DataTemplate UrgentDataTemplate { get; set; }
        public DataTemplate CompletedDataTemplate { get; set; }
        public DataTemplate UncompletedDataTemplate { get; set; }
    }
}

namespace DemoCenter.Forms.DemoModules.CollectionView.Views {
    public partial class CollectionViewDefaultSwipes : ContentPage {
        bool isAnimated;

        public CollectionViewDefaultSwipes() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();
            ViewModel = new DefaultSwipeViewModel(new EmployeeTasksRepository());
            BindingContext = ViewModel;
        }

        DefaultSwipeViewModel ViewModel { get; }

        void OnDeleteTask(object sender, SwipeItemTapEventArgs e) {
            this.collectionView.DeleteItem(e.ItemHandle);
        }

        void OnStatusChanged(object sender, SwipeItemTapEventArgs e) {
            if (this.isAnimated)
                return;

            IList<EmployeeTask> source = ViewModel.ItemSource;

            EmployeeTask task = e.Item as EmployeeTask;
            int newItemHandle = 0;

            switch (task.Status) {
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

                    
            int itemHandle = e.ItemHandle;
            if (itemHandle == newItemHandle)
                return;

            this.isAnimated = true;
                Device.BeginInvokeOnMainThread(() =>
                    this.collectionView.MoveItem(itemHandle, newItemHandle, () => this.isAnimated = false)
                );
        }
    }
}
