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
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DemoCenter.Forms.DemoModules.Grid.Data {
    public class EmployeeTasksRepository {
        public IList<EmployeeTask> EmployeeTasks { get; private set; }

        public EmployeeTasksRepository() {
            IList<EmployeeTask> tasks = LoadTasks();
            UpdateSource(tasks);
            EmployeeTasks = tasks;
        }

        IList<EmployeeTask> LoadTasks() {
            System.Reflection.Assembly assembly = GetType().Assembly;
            Stream stream = assembly.GetManifestResourceStream("EmployeeTasks.json");
            JObject jObject = JObject.Parse(new StreamReader(stream).ReadToEnd());
            List<EmployeeTask> list = jObject["EmployeeTasks"].ToObject<List<EmployeeTask>>().Take(30).ToList();
            return new BindingList<EmployeeTask>(list);
        }

        void UpdateSource(IList<EmployeeTask> tasks) {
            Random random = new Random();
            for (int i = 0; i < tasks.Count; i++) {
                EmployeeTask task = tasks[i];
                task.StartDate = DateTime.Now.AddDays(random.Next(7) + 1);
                task.DueDate = task.StartDate.AddDays(random.Next(3) + 1);
                task.Status = i < tasks.Count * 2 / 3 ? 0 : 100;
            }
        }
    }
}
