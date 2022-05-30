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
using System.Globalization;
using DevExpress.XamarinForms.Editors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoCenter.Forms.DemoModules.Editors.Converters {
    class BoxModeToImageSourceConverterExtension : IMarkupExtension<BoxModeToImageSourceConverter> {
        public ImageSource Filled { get; set; }
        public ImageSource Outlined { get; set; }

        public BoxModeToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) => new BoxModeToImageSourceConverter {
            Filled = Filled,
            Outlined = Outlined
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class BoxModeToImageSourceConverter : IValueConverter {
        public ImageSource Filled { get; set; }
        public ImageSource Outlined { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is BoxMode boxMode) || targetType != typeof(ImageSource)) return null;
            switch (boxMode) {
                case BoxMode.Filled:
                    return Filled;
                case BoxMode.Outlined:
                    return Outlined;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class CharacterCasingToImageSourceConverterExtension : IMarkupExtension<CharacterCasingToImageSourceConverter> {
        public ImageSource Normal { get; set; }
        public ImageSource Uppercase { get; set; }
        public ImageSource Lowercase { get; set; }

        public CharacterCasingToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) => new CharacterCasingToImageSourceConverter {
            Normal = Normal,
            Uppercase = Uppercase,
            Lowercase = Lowercase
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class CharacterCasingToImageSourceConverter : IValueConverter {
        public ImageSource Normal { get; set; }
        public ImageSource Uppercase { get; set; }
        public ImageSource Lowercase { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CharacterCasing casing) || targetType != typeof(ImageSource))
                return null;
            switch (casing) {
                case CharacterCasing.Normal:
                    return Normal;
                case CharacterCasing.Upper:
                    return Uppercase;
                case CharacterCasing.Lower:
                    return Lowercase;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class CornerModeToImageSourceConverterExtension : IMarkupExtension<CornerModeToImageSourceConverter> {
        public ImageSource Cut { get; set; }
        public ImageSource Round { get; set; }

        public CornerModeToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) => new CornerModeToImageSourceConverter {
            Cut = Cut,
            Round = Round
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class CornerModeToImageSourceConverter : IValueConverter {
        public ImageSource Cut { get; set; }
        public ImageSource Round { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CornerMode cornerMode) || targetType != typeof(ImageSource)) return null;
            switch (cornerMode) {
                case CornerMode.Cut:
                    return Cut;
                case CornerMode.Round:
                    return Round;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class BoxModeToImageNameConverterExtension : IMarkupExtension<BoxModeToImageNameConverter> {
        public string Filled { get; set; }
        public string Outlined { get; set; }

        public BoxModeToImageNameConverter ProvideValue(IServiceProvider serviceProvider) => new BoxModeToImageNameConverter {
            Filled = Filled,
            Outlined = Outlined
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class BoxModeToImageNameConverter : IValueConverter {
        public string Filled { get; set; }
        public string Outlined { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is BoxMode boxMode) || targetType != typeof(string)) return null;
            switch (boxMode) {
                case BoxMode.Filled:
                    return Filled;
                case BoxMode.Outlined:
                    return Outlined;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class CornerModeToImageNameConverterExtension : IMarkupExtension<CornerModeToImageNameConverter> {
        public string Cut { get; set; }
        public string Round { get; set; }

        public CornerModeToImageNameConverter ProvideValue(IServiceProvider serviceProvider) => new CornerModeToImageNameConverter {
            Cut = Cut,
            Round = Round
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class CornerModeToImageNameConverter : IValueConverter {
        public string Cut { get; set; }
        public string Round { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CornerMode cornerMode) || targetType != typeof(string)) return null;
            switch (cornerMode) {
                case CornerMode.Cut:
                    return Cut;
                case CornerMode.Round:
                    return Round;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}
