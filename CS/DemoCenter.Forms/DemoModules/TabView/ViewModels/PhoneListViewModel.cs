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
using System.Collections.Generic;
using DemoCenter.Forms.Data;
using DevExpress.XamarinForms.Core.Themes;
using Xamarin.Forms;

namespace DemoCenter.Forms.ViewModels {
    public class PhoneListViewModel : NavigationViewModelBase {
        GroupedPhoneList selectedItem;
        readonly PhoneList phoneList;
        PhoneListData alphabeticalyPhoneListData;
        PhoneListData categoryPhoneListData;
        GroupParameterName currentGroupParameter;

        public PhoneListData PhoneListData => currentGroupParameter == GroupParameterName.Alphabeticaly? alphabeticalyPhoneListData: categoryPhoneListData;
        public GroupParameterName GroupParameter => currentGroupParameter;
        public bool IsLightTheme { get { return ThemeManager.ThemeName == Theme.Light; } }
        public PhoneListViewModel() {
            phoneList = XmlDataDeserializer.GetData<PhoneList>("Resources.PhoneListData.xml");
            alphabeticalyPhoneListData = GroupByParameter(GroupParameterName.Alphabeticaly);
            categoryPhoneListData = GroupByParameter(GroupParameterName.Category);
            currentGroupParameter = GroupParameterName.Alphabeticaly;
        }
        public void SetGroupByParameter(GroupParameterName parameter) {
            ResetSelectedItem(null);
            currentGroupParameter = parameter;
        }
        PhoneListData GroupByParameter(GroupParameterName parameter) {
            Dictionary<string, PhoneList> result = new Dictionary<string, PhoneList>();
            result.Add("All", phoneList);
            foreach(Contact contact in phoneList) {
                string groupedValue = GetGroupedValue(contact, parameter);
                if (!result.ContainsKey(groupedValue)) {
                    result.Add(groupedValue, new PhoneList());
                }
                result[groupedValue].Add(contact);
            }
            PhoneListData phoneListData = new PhoneListData(result.Count);
            foreach(string group in result.Keys) {
                GroupedPhoneList groupedList = new GroupedPhoneList() { Contacts = result[group], GroupName = group };
                if(GetShowGroupIcon(parameter)) {
                    groupedList.ShowGroupIcon = true;
                    groupedList.GroupIconSource = GetGroupIconSource(group);
                }
                phoneListData.Add(groupedList);
            }
            return phoneListData;
        }
        string GetGroupedValue(Contact contact, GroupParameterName parameter) {
            if (parameter == GroupParameterName.Alphabeticaly)
                return contact.LastName[0].ToString();
            else
                return contact.ContactCategory.ToString();
        }
        public GroupedPhoneList SelectedItem {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value, onChanged: (oldValue, newValue) => {
                ResetSelectedItem(oldValue);
                if(newValue != null) newValue.IsSelected = true;
            });
        }
        void ResetSelectedItem(GroupedPhoneList oldValue) {
            if (oldValue != null) {
                oldValue.IsSelected = false;
            } else {
                foreach(GroupedPhoneList curentItem in PhoneListData) {
                    if(curentItem.IsSelected) {
                        curentItem.IsSelected = false;
                        return;
                    }
                }
            }
        }
        ImageSource GetGroupIconSource(string groupName) {
            switch(groupName) {
                case "Star": return ImageSource.FromFile("demotabview_star");
                case "Work": return ImageSource.FromFile("demotabview_work");
                case "Family": return ImageSource.FromFile("demotabview_family");
                case "All": return ImageSource.FromFile("demotabview_all");
                default:
                    return string.Empty;
            }
        }
        bool GetShowGroupIcon(GroupParameterName parameter) {
            return parameter == GroupParameterName.Category;
        }
    }
}
