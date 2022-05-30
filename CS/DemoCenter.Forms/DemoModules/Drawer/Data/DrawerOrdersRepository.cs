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
using System.Collections.ObjectModel;
using System.Linq;
using DemoCenter.Forms.DemoModules.Grid.Data;
using DemoCenter.Forms.DemoModules.TabView;

namespace DemoCenter.Forms.DemoModules.Drawer.Data {
    public class DrawerOrdersRepository : GridOrdersRepository {
        readonly NestedTabViewModel productsModel = new NestedTabViewModel();

        public IList<string> Companies { get; } = new List<string>() {
            "Electronics Depot",
            "K&S Music",
            "Walters",
            "E-Mart",
            "Video Emporium"
        };

        public ObservableCollection<Invoice> Invoices => GetInvoices(this.Orders);
        public ObservableCollection<CompanyCustomer> CompanyCustomers => GetCustomers(this.Customers);

        ObservableCollection<CompanyCustomer> GetCustomers(ObservableCollection<Customer> customers) {
            IList<CompanyCustomer> result = customers.ToList().ConvertAll((customer) => {
                return new CompanyCustomer(customer) {
                    CompanyName = Companies[random.Next(0, Companies.Count - 1)]
                };
            });
            return new ObservableCollection<CompanyCustomer>(result);
        }

        ObservableCollection<Invoice> GetInvoices(IList<Order> orders) {
            ObservableCollection<Invoice> result = new ObservableCollection<Invoice>();
            foreach (Order order in orders) {
                foreach (OrderEntry orderEntry in order.Entries) {
                    result.Add(new Invoice() {
                        OrderID = random.Next(1024, 1039),
                        CustomerID = order.Customer.Id.ToString(),
                        OrderDate = order.Date,
                        ShippedDate = order.Date.AddHours(random.Next(24, 80)),
                        CustomerName = order.Customer.Name,
                        Discount = order.Discount,
                        Quantity = random.Next(1, 5),
                        ProductName = orderEntry.Commodity.Name,
                        UnitPrice = Convert.ToDouble(productsModel.ProductsData.First(p => p.Name == orderEntry.Commodity.Name).Price.Substring(1))
                    });
                }
            }
            return result;
        }

        protected override void GenerateCommodities() {
            foreach (Product product in productsModel.ProductsData) {
                this.availableCommodities.Add(new Commodity(product.Name));
            }
        }
    }
}
