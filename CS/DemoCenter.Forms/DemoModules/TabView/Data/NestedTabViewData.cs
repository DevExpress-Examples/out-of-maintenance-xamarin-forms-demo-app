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
using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Forms.ViewModels;
using Xamarin.Forms;

namespace DemoCenter.Forms.DemoModules.TabView {
    public class Category: NotificationObject {
        bool isSelected;
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public bool IsSelected {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }
    }
    public class Product: BindableObject {
        public static readonly BindableProperty CanAddToCartProperty =
            BindableProperty.Create(nameof(Product.CanAddToCart), typeof(bool), typeof(Product),
                defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty CanAddToWishListProperty =
            BindableProperty.Create(nameof(Product.CanAddToWishList), typeof(bool), typeof(Product),
                defaultBindingMode: BindingMode.TwoWay);


        public bool CanAddToCart {
            get => (bool)GetValue(CanAddToCartProperty);
            set => SetValue(CanAddToCartProperty, value);
        }
        public bool CanAddToWishList {
            get => (bool)GetValue(CanAddToWishListProperty);
            set => SetValue(CanAddToWishListProperty, value);
        }

        string imageName;
        NestedTabViewModel parentModel;
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public ImageSource ImageSource { get; set; }


        public bool ToDelete { get { return !CanAddToCart || !CanAddToWishList; } }
        public string ImageName {
            get { return imageName; }
            set {
                imageName = value;
                ImageSource = ImageSource.FromResource("DemoCenter.Forms.DemoModules.TabView.Resources.NestedTabViewImages." + value + ".png");
            }
        }
        public ICommand ChangeCart { get; }
        public ICommand ChangeWishList { get; }
        public Product(NestedTabViewModel parentModel) {
            this.parentModel = parentModel;
            CanAddToCart = true;
            CanAddToWishList = true;
            ChangeCart = new Command(() => parentModel.ChangeCart.Execute(this));
            ChangeWishList = new Command(() => parentModel.ChangeWishList.Execute(this));
        }
    }
}
