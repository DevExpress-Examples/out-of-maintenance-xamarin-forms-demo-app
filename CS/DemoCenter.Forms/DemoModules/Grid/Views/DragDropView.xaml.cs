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
using System.Linq;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.DataGrid;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class DragDropView : BaseGridContentPage {
        bool isAnimated;

        public DragDropView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return new EmployeeTasksRepository();
        }

        void Grid_DragRow(object sender, DragRowEventArgs e) {
            if (this.isAnimated) {
                e.Allow = false;
                return;
            }
            e.Allow = IsItemDraggable(e.DragItem);
            this.isAnimated = e.Allow;
        }

        void Grid_DragRowOver(object sender, DropRowEventArgs e) {
            e.Allow = IsItemDraggable(e.DropItem);
        }

        void Grid_CompleteRowDragDrop(object sender, CompleteRowDragDropEventArgs e) {
            this.isAnimated = false;
        }

        bool IsItemDraggable(object item) {
            return !((EmployeeTask)item).Completed;
        }

        private void Grid_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Element != DataGridElement.Row || e.FieldName != "Completed" || this.isAnimated)
                return;
            IList<EmployeeTask> source = (IList<EmployeeTask>)this.grid.ItemsSource;
            EmployeeTask task = (EmployeeTask)e.Item;
            task.Status = task.Completed ? 0 : 100;
            int newRowHandle = task.Completed ? source.Count() - 1 : 0;
            if (e.RowHandle == newRowHandle)
                return;
            this.isAnimated = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(200), () => {
                Device.BeginInvokeOnMainThread(() =>
                    this.grid.MoveItem(e.RowHandle, newRowHandle, () => this.isAnimated = false)
                );
                return false;
            });
        }

        void Grid_CustomCellStyle(object sender, CustomCellStyleEventArgs e) {
            if (e.FieldName == nameof(EmployeeTask.Name) || e.FieldName == nameof(EmployeeTask.DueDate)) {
                if (((EmployeeTask)e.Item).Completed) {
                    e.TextDecorations = TextDecorations.Strikethrough;
                    e.FontColor = new Color(e.FontColor.R, e.FontColor.G, e.FontColor.B, 0.5);
                }
            }
        }
    }
}
