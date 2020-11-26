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
using System.Data;
using System.Globalization;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public class EmployeeSales {
        public DataTable Data { get; private set; }
        public EmployeeSales() {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Full Name"));
            for (int i = 0; i < 5; i++) {
                int year = DateTime.Now.Year - 5 + i;
                for (int j = 1; j < 5; j++) {
                    dataTable.Columns.Add(new DataColumn("Q" + j + ", " + year, typeof(double)));
                }
                dataTable.Columns.Add(new DataColumn("" + year + " Total", typeof(double)));
            }

            Random random = new Random();
            EmployeesRepository employees = new EmployeesRepository();
            foreach (Employee employee in employees.Employees) {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Full Name"] = employee.FullName;

                for (int i = 0; i < 5; i++) {
                    double yearTotal = 0;
                    int year = DateTime.Now.Year - 5 + i;
                    for (int j = 1; j < 5; j++) {
                        double value = random.Next(100000);
                        dataRow["Q" + j + ", " + year] = value;
                        yearTotal += value;
                    }
                    dataRow["" + year + " Total"] = yearTotal;
                }
                dataTable.Rows.Add(dataRow);
            }

            Data = dataTable;
        }
    }
}
