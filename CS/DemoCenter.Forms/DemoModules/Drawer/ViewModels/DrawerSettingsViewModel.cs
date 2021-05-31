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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DevExpress.XamarinForms.Navigation;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.Drawer.ViewModels {
    public class DrawerSettingsViewModel : BindableObject {
        internal static Dictionary<DrawerBehavior, string> BehaviorToDisplayName;
        internal static Dictionary<Position, string> PositionToDisplayName;

        public static readonly BindableProperty SelectedBehaviorProperty;
        public static readonly BindableProperty SelectedPositionProperty;

        public DrawerBehavior SelectedBehavior {
            get => (DrawerBehavior) GetValue(SelectedBehaviorProperty);
            set => SetValue(SelectedBehaviorProperty, value);
        }

        public Position SelectedPosition {
            get => (Position) GetValue(SelectedPositionProperty);
            set => SetValue(SelectedPositionProperty, value);
        }

        static DrawerSettingsViewModel() {
            SelectedBehaviorProperty = BindableProperty.Create("SelectedBehavior", typeof(DrawerBehavior),
                typeof(DrawerSettingsViewModel), DrawerBehavior.SlideOnTop, defaultBindingMode: BindingMode.TwoWay);
            SelectedPositionProperty = BindableProperty.Create("SelectedPosition", typeof(Position),
                typeof(DrawerSettingsViewModel), Position.Left, defaultBindingMode: BindingMode.TwoWay);

            BehaviorToDisplayName = new Dictionary<DrawerBehavior, string>(4);
            BehaviorToDisplayName.Add(DrawerBehavior.SlideOnTop, "Slide On Top");
            BehaviorToDisplayName.Add(DrawerBehavior.Push, "Push");
            BehaviorToDisplayName.Add(DrawerBehavior.Reveal, "Reveal");
            BehaviorToDisplayName.Add(DrawerBehavior.Split, "Split");

            PositionToDisplayName = new Dictionary<Position, string>(4);
            PositionToDisplayName.Add(Position.Left, "Left");
            PositionToDisplayName.Add(Position.Right, "Right");
            PositionToDisplayName.Add(Position.Top, "Top");
            PositionToDisplayName.Add(Position.Bottom, "Bottom");
        }

        List<MenuItem> menuItems;

        public List<MenuItem> MenuItems {
            get { return menuItems; }
            set {
                if (menuItems != value) {
                    menuItems = value;
                    OnPropertyChanged("MenuItems");
                }
            }
        }

        List<string> behaviorVariants;

        public List<string> BehaviorVariants {
            get { return behaviorVariants; }
            set {
                if (behaviorVariants != value) {
                    behaviorVariants = value;
                    OnPropertyChanged("BehaviorVariants");
                }
            }
        }

        List<string> positionVariants;

        public List<string> PositionVariants {
            get { return positionVariants; }
            set {
                if (positionVariants != value) {
                    positionVariants = value;
                    OnPropertyChanged("PositionVariants");
                }
            }
        }

        public DrawerSettingsViewModel() {
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem("Products"));
            MenuItems.Add(new MenuItem("Sales"));
            MenuItems.Add(new MenuItem("Customers"));
            MenuItems.Add(new MenuItem("Employees"));
            MenuItems.Add(new MenuItem("Reports"));

            PositionVariants = PositionToDisplayName.Values.ToList();
            BehaviorVariants = BehaviorToDisplayName.Values.ToList();
        }
    }

    public class MenuItem {
        public MenuItem(string name) {
            Name = name;
        }

        public string Name { get; set; }

        public string Icon => string.Format("demodrawer_{0}",
            this.Name.ToLowerInvariant());
    }
    
    public class DrawerEnumToStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                if (value is DrawerBehavior behavior)
                    return ConvertInner(behavior) == parameter?.ToString();
                else if (value is Position position)
                    return ConvertInner(position) == parameter?.ToString();
            }
            catch {
            }

            return false;
        }

        string ConvertInner(Position value) {
            return DrawerSettingsViewModel.PositionToDisplayName[value];
        }

        string ConvertInner(DrawerBehavior value) {
            return DrawerSettingsViewModel.BehaviorToDisplayName[value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null && (value is bool boolVal) && boolVal) {
                if (targetType == typeof(DrawerBehavior))
                    return DrawerSettingsViewModel.BehaviorToDisplayName
                        .FirstOrDefault(b => b.Value == parameter.ToString()).Key;
                else if (targetType == typeof(Position))
                    return DrawerSettingsViewModel.PositionToDisplayName
                        .FirstOrDefault(b => b.Value == parameter.ToString()).Key;
            }

            return value;
        }
    }
}
