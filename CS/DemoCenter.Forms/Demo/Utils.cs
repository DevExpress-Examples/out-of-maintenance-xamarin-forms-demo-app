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
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace DemoCenter.Forms {
    public class InverseBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;
    }

    public class BoolToObjectConverter : IValueConverter {
        public object FalseValue { get; set; }
        public object TrueValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var result = (bool)value ? TrueValue : FalseValue;
            var typeConverter = TypeDescriptor.GetConverter(targetType);
            return typeConverter.ConvertFrom(null, CultureInfo.InvariantCulture, result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class BoolToStackOrientationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(StackOrientation)) {
                if (parameter is string && ((string) parameter) == "inverse")
                    return (bool) value ? StackOrientation.Horizontal : StackOrientation.Vertical;
                else
                    return (bool) value ? StackOrientation.Vertical : StackOrientation.Horizontal;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToScrollOrientationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(ScrollOrientation)) {
                if (parameter is string && ((string) parameter) == "inverse")
                    return (bool) value ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical;
                else
                    return (bool) value ? ScrollOrientation.Vertical : ScrollOrientation.Horizontal;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToHeaderPanelPositionConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(DevExpress.XamarinForms.Navigation.Position)) {
                return (bool) value ? DevExpress.XamarinForms.Navigation.Position.Left : DevExpress.XamarinForms.Navigation.Position.Top;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToFileImageSourceConverter : IValueConverter {
        public FileImageSource FalseSource { get; set; }
        public FileImageSource TrueSource { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is bool)) {
                return null;
            }
            return (bool)value ? TrueSource : FalseSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class BoolToColorConverter : IValueConverter {
        public Color FalseSource { get; set; }
        public Color TrueSource { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is bool)) {
                return null;
            }
            return (bool)value ? TrueSource : FalseSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class TitleViewExtensions {
        public static BindableProperty IsShadowVisibleProperty =
            BindableProperty.CreateAttached("IsShadowVisible", typeof(bool), typeof(Page), false);

        public static bool GetIsShadowVisible(Page view) {
            return (bool) view.GetValue(IsShadowVisibleProperty);
        }

        public static void SetIsShadowVisible(Page view, bool value) {
            view.SetValue(IsShadowVisibleProperty, value);
        }
    }

}

namespace DemoCenter.PlatformConfiguration.iOSSpecific {
    using FormsElement = Xamarin.Forms.NavigationPage;
    public static class Page {
        public static readonly BindableProperty DisablePopInteractiveProperty = BindableProperty.Create(nameof(DisablePopInteractive), typeof(bool), typeof(Page), false);

        public static bool GetDisablePopInteractive(BindableObject element)
        {
            return (bool)element.GetValue(DisablePopInteractiveProperty);
        }

        public static void SetDisablePopInteractive(BindableObject element, bool value)
        {
            element.SetValue(DisablePopInteractiveProperty, value);
        }

        public static IPlatformElementConfiguration<iOS, FormsElement> SetDisablePopInteractive(this IPlatformElementConfiguration<iOS, FormsElement> config, bool value)
        {
            SetDisablePopInteractive(config.Element, value);
            return config;
        }

        public static bool DisablePopInteractive(this IPlatformElementConfiguration<iOS, FormsElement> config)
        {
            return GetDisablePopInteractive(config.Element);
        }
    }

}
