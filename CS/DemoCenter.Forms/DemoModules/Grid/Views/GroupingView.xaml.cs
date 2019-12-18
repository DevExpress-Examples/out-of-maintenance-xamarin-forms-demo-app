/*                                                         
               Copyright (c) 2019 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile UI for Xamarin.Forms               }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2019 Developer Express Inc.                   }   
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
using DemoCenter.Forms.DemoModules.Grid.Data;
using DevExpress.XamarinForms.DataGrid.Localization;

namespace DemoCenter.Forms.Views {
    public partial class GroupingView : BaseGridContentPage {
        string TotalSummaryDisplayFormat { get; set; }
        public GroupingView() {
            InitializeComponent();
            SaveGroupSummaryDisplayFormat();
        }

        protected override object LoadData() {
            return new InvoicesRepository();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            SaveGroupSummaryDisplayFormat();
        }

        protected override void OnDisappearing() {
            RestoreGroupSummaryDisplayFormat();
            base.OnDisappearing();
        }

        void SaveGroupSummaryDisplayFormat() {
            TotalSummaryDisplayFormat = GridLocalizer.GetString(GridStringId.GroupSummaryDisplayFormat);
            GridLocalizer.Active.AddString(GridStringId.GroupSummaryDisplayFormat, "{0}={2}");
        }

        void RestoreGroupSummaryDisplayFormat() {
            GridLocalizer.Active.AddString(GridStringId.GroupSummaryDisplayFormat, TotalSummaryDisplayFormat);
        }
    }
}
