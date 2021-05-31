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
using System.Threading.Tasks;
using DevExpress.XamarinForms.Core.Themes;
using Xamarin.Forms;

namespace DemoCenter.Forms.Themes {

    public interface IEnvironment {
        Task<bool> IsLightOperatingSystemTheme();
    }

    internal class ThemeLoader : IThemeChangingHandler {
        static ThemeLoader instance = null;
        IThemeLoader platformLoader = null;
        public static ThemeLoader Instance {
            get {
                if(instance == null)
                    instance = new ThemeLoader();

                return instance;
            }
        }

        private ThemeLoader() {
            platformLoader = DependencyService.Get<IThemeLoader>();
            ThemeManager.AddThemeChangedHandler(this);
        }

        public void LoadTheme() {
            bool isLightTheme = ThemeManager.ThemeName == Theme.Light;
            ResourceDictionary theme = null;
            if(isLightTheme) {
                theme = new LightTheme();
            } else {
                theme = new DarkTheme();
            }
            if(theme != null) {
                Application.Current.Resources.MergedDictionaries.Add(theme);
                platformLoader?.LoadTheme(theme, isLightTheme);
            }
        }

        void IThemeChangingHandler.OnThemeChanged() {
            LoadTheme();
        }
    }
    public interface IThemeLoader {
        void LoadTheme(ResourceDictionary theme, bool isLightTheme);
    }
}
