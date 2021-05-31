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
using DemoCenter.Forms.DemoModules.Grid.Data;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.CollectionView;
using Xamarin.Forms;

namespace DemoCenter.Forms {
    class ItemTemplateSelector : DataTemplateSelector {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (!(item is EmployeeTask task))
                return null;

            return task.Completed ? CompletedDataTemplate : UncompletedDataTemplate; 
        }

        public DataTemplate CompletedDataTemplate { get; set; }
        public DataTemplate UncompletedDataTemplate { get; set; }
    }
}

namespace DemoCenter.Forms.DemoModules.CollectionView.Views {
    public partial class CollectionViewDragDropView : ContentPage {
        public CollectionViewDragDropView() {
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            InitializeComponent();
            ViewModel = new DragDropModel(new EmployeeTasksRepository());
            BindingContext = ViewModel;
        }

        DragDropModel ViewModel { get; }

        void DragItem(object sender, DragItemEventArgs e) {
            e.Allow = IsItemDraggable(e.DragItem);
        }

        void DragItemOver(object sender, DropItemEventArgs e) {
            e.Allow = IsItemDraggable(e.DropItem);
        }

        bool IsItemDraggable(object item) {
            return !((EmployeeTask)item).Completed;
        }
    }
}
