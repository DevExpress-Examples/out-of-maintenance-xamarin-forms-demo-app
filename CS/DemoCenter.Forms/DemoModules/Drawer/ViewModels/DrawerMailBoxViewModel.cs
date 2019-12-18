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
using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Forms.DemoModules.Drawer.Data;
using DemoCenter.Forms.ViewModels;
using DevExpress.XamarinForms.Core.Themes;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DemoCenter.Forms.DemoModules.Drawer.ViewModels {
    public class DrawerMailBoxViewModel : NotificationObject {
        readonly MailMessagesRepository repository;

        MailBoxOwner ownerInfo;

        public MailBoxOwner OwnerInfo {
            get { return ownerInfo; }
            set {
                if (ownerInfo != value) {
                    ownerInfo = value;
                    OnPropertyChanged("OwnerInfo");
                }
            }
        }

        List<MailData> messages;

        public List<MailData> Messages {
            get { return messages; }
            set {
                if (messages != value) {
                    messages = value;
                    OnPropertyChanged("Messages");
                }
            }
        }

        List<MailBoxFolder> folders;

        public List<MailBoxFolder> Folders {
            get { return folders; }
            set {
                if (folders != value) {
                    folders = value;
                    OnPropertyChanged("Folders");
                }
            }
        }

        MailBoxFolder selectedFolder;

        public MailBoxFolder SelectedFolder {
            get { return selectedFolder; }
            set {
                if (selectedFolder != value) {
                    selectedFolder = value;
                    SetFolder(selectedFolder);
                    OnPropertyChanged("SelectedFolder");
                }
            }
        }

        public string BackgroundImage => string.Format("{0}.DrawerBackGround.svg", ThemeManager.ThemeName);

        public DrawerMailBoxViewModel(MailMessagesRepository messagesRepository) {
            this.repository = messagesRepository;

            this.OwnerInfo = new MailBoxOwner() {
                Name = "Jennifer Hobbs",
                Email = "jennyh@dx-email.com",
                Avatar = ImageSource.FromResource("DemoCenter.Forms.DemoModules.Drawer.Images.JenniferHobbs.jpg")
            };

            this.Folders = messagesRepository.Folders;
            this.SelectedFolder = messagesRepository.Folders[0];
        }

        internal void SetFolder(MailBoxFolder folder) {
            Device.BeginInvokeOnMainThread(() => {
                this.Folders.Where(f => f.IsSelected).ForEach(f => f.IsSelected = false);
                folder.IsSelected = true;
                this.Messages =
                    this.repository.MailMessages.FindAll(m => m.Folders != null && m.Folders.Contains(folder.FolderName)).OrderByDescending((f) => f.SentDate).ToList();
            });
            
        }
    }

    public class SelectedToValueConverter : IValueConverter {
        public object NormalValue { get; set; }
        public object SelectedValue { get; set; }
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) {
            if (value is bool) {
                if (targetType.IsEnum)
                    return Enum.Parse(targetType,(Boolean) value ? SelectedValue.ToString() : NormalValue.ToString());
                return (Boolean) value ? this.SelectedValue : this.NormalValue;
            }

            return Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture) {
            return null;
        }
    }
}