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
﻿using System.Collections.Generic;

namespace DemoCenter.Forms.DemoModules.DataForm.ViewModels {

    public partial class EmployeeFormViewModel {
        public class EmloyeeLayoutTemplate {
            Dictionary<string, int> template;

            public EmloyeeLayoutTemplate(Dictionary<string, int> template) {
                this.template = template;
            }

            public int GetFieldOrder(string fieldName) {
                if (this.template.ContainsKey(fieldName)) {
                    return this.template[fieldName];
                }
                else {
                    return -1;
                }
            }

            public static implicit operator EmloyeeLayoutTemplate(Dictionary<string, int> dictionary) {
                return new EmloyeeLayoutTemplate(dictionary);
            }

            public static EmloyeeLayoutTemplate TabletHorizontal { get; } = new Dictionary<string, int> {
                { nameof(EmployeeInfo.Photo), 0 },    { nameof(EmployeeInfo.FirstName),         0 },
                                                      { nameof(EmployeeInfo.LastName),          1 },
                                                      { nameof(EmployeeInfo.BirthDate),         2 },
                { nameof(EmployeeInfo.Position), 4 }, { nameof(EmployeeInfo.HireDate),          4 },
                { nameof(EmployeeInfo.Notes),    5 },
                { nameof(EmployeeInfo.Address),  6 }, { nameof(EmployeeInfo.HomePhoneNumber),   6 },
                { nameof(EmployeeInfo.City),     7 }, { nameof(EmployeeInfo.MobilePhoneNumber), 7 },
                { nameof(EmployeeInfo.State),    8 }, { nameof(EmployeeInfo.Email),             8 },
                { nameof(EmployeeInfo.Zip),      9 }, { nameof(EmployeeInfo.Skype),             9 }
            };

            public static EmloyeeLayoutTemplate TabletVertical { get; } = new Dictionary<string, int> {
                { nameof(EmployeeInfo.Photo),              0 }, { nameof(EmployeeInfo.FirstName),         0 },
                                                                { nameof(EmployeeInfo.LastName),          1 },
                                                                { nameof(EmployeeInfo.BirthDate),         2 },
                { nameof(EmployeeInfo.Position),           4 },
                { nameof(EmployeeInfo.Notes),              5 },
                { nameof(EmployeeInfo.Address),            6 },
                { nameof(EmployeeInfo.City),               7 },
                { nameof(EmployeeInfo.State),              8 },
                { nameof(EmployeeInfo.Zip),                9 },
                { nameof(EmployeeInfo.HireDate),          10 },
                { nameof(EmployeeInfo.HomePhoneNumber),   11 },
                { nameof(EmployeeInfo.MobilePhoneNumber), 12 },
                { nameof(EmployeeInfo.Email),             13 },
                { nameof(EmployeeInfo.Skype),             14 }
            };

            public static EmloyeeLayoutTemplate PhoneVertical { get; } = new Dictionary<string, int> {
                { nameof(EmployeeInfo.Photo),              0 },
                { nameof(EmployeeInfo.FirstName),          1 },
                { nameof(EmployeeInfo.LastName),           2 },
                { nameof(EmployeeInfo.BirthDate),          3 },
                { nameof(EmployeeInfo.Position),           4 },
                { nameof(EmployeeInfo.Notes),              5 },
                { nameof(EmployeeInfo.Address),            6 },
                { nameof(EmployeeInfo.City),               7 },
                { nameof(EmployeeInfo.State),              8 },
                { nameof(EmployeeInfo.Zip),                9 },
                { nameof(EmployeeInfo.HireDate),          10 },
                { nameof(EmployeeInfo.HomePhoneNumber),   11 },
                { nameof(EmployeeInfo.MobilePhoneNumber), 12 },
                { nameof(EmployeeInfo.Email),             13 },
                { nameof(EmployeeInfo.Skype),             14 }
            };

            public static EmloyeeLayoutTemplate PhoneHorizontal => TabletVertical;
        }
    }
}
