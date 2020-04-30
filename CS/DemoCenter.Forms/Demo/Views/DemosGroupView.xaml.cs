/*
               Copyright (c) 2015-2020 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2020 Developer Express Inc.              }
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
using System.Windows.Input;
using DemoCenter.Forms.Data;
using DemoCenter.Forms.Models;
using DevExpress.XamarinForms.Core.Internal;
using Xamarin.Forms;

namespace DemoCenter.Forms.Views {
    public partial class DemosGroupView : AbsoluteLayout {
        const int horizontal_label_margin = 10;
        public static BindableProperty SourceModuleProperty;
        public static readonly BindableProperty ItemSelectedCommandProperty;

        static DemosGroupView() {
            SourceModuleProperty = BindingUtils.Instance.CreateBindableProperty<DemosGroupView, Type>(
                o => o.SourceModule,
                defaultValue: null,
                propertyChanged: OnSourceModulePropertyChanged);
            ItemSelectedCommandProperty = BindingUtils.Instance.CreateBindableProperty<DemosGroupView, ICommand>(
                o => o.ItemSelectedCommand,
                defaultValue: null);
        }

        static void OnSourceModulePropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((DemosGroupView) bindable).RefreshLayout();

        public Type SourceModule {
            get => (Type) GetValue(SourceModuleProperty);
            set => SetValue(SourceModuleProperty, value);
        }

        public ICommand ItemSelectedCommand {
            get => (ICommand) GetValue(ItemSelectedCommandProperty);
            set => SetValue(ItemSelectedCommandProperty, value);
        }

        const int demoGroupItemWidth = LabelEx.label_size + horizontal_label_margin;
        List<DemoItem> demoItems = null;
        Dictionary<Type, List<GroupItemView>> demoViews = null;

        public DemosGroupView() : base() {
            InitializeComponent();
            demoViews = new Dictionary<Type, List<GroupItemView>>();
        }

        Type currentLayoutedType;
        
        public void RefreshLayout() {
            if (SourceModule != null && currentLayoutedType != SourceModule) {
                currentLayoutedType = SourceModule;
                demoItems = ((IDemoData) Activator.CreateInstance(SourceModule)).DemoItems;
                bool fillDemoviews = !demoViews.ContainsKey(SourceModule);
                if (fillDemoviews)
                    demoViews.Add(SourceModule, new List<GroupItemView>(demoItems.Count));
                for (int i = 0; i < demoItems.Count; i++) {
                    GroupItemView demoView;
                    if (fillDemoviews) {
                        demoView = CreateDemoShortcut(demoItems[i]);
                        demoViews[SourceModule].Add(demoView);
                    }
                    else {
                        demoView = demoViews[SourceModule][i];
                    }

                    int t = i;
                    if (this.Children.Count <= i) {
                        this.Children.Add(demoView,  new Rectangle(t * demoGroupItemWidth, 0, demoGroupItemWidth, LabelEx.label_size), AbsoluteLayoutFlags.None);
                    }
                    else {
                        if (demoView == Children[i]) {
                            this.Children[t].IsVisible = true;
                            continue;
                        }

                        demoView.BatchBegin();
                        AbsoluteLayout.SetLayoutBounds (demoView, new Rectangle(t * demoGroupItemWidth, 0, demoGroupItemWidth, LabelEx.label_size));
                        demoView.BatchCommit();
                        this.Children[t] = demoView;
                    }
                }

                if (this.Children.Count > demoItems.Count) {
                    for (int i = demoItems.Count; i < this.Children.Count; i++) {
                        int t = i;
                        this.Children[t].IsVisible = false;
                    }
                }
                this.BatchCommit();
                base.InvalidateLayout();
                base.InvalidateMeasure();
            }
        }

        protected override bool ShouldInvalidateOnChildAdded(View child) {
            return false;
        }
        
        protected override void OnChildMeasureInvalidated() {
        }

        protected override void InvalidateLayout() {
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint) {
            return new SizeRequest(){ Request = new Size(demoItems.Count * demoGroupItemWidth, LabelEx.label_size), Minimum = new Size(1, 1)};
        }

        protected override void LayoutChildren(double x, double y, double width, double height) {
            base.LayoutChildren(0, 0, demoItems.Count * demoGroupItemWidth, LabelEx.label_size);
        }

        GroupItemView CreateDemoShortcut(DemoItem item) {
            GroupItemView result = new GroupItemView();
            result.BindingContext = item;
            result.TappedControlShortcut += DemoItem_TappedControlShortcut;
            return result;
        }

        void DemoItem_TappedControlShortcut(object sender, System.EventArgs e) {
            var groupItemView = (GroupItemView) sender;
            if (ItemSelectedCommand != null) {
                ItemSelectedCommand.Execute(groupItemView.BindingContext);
            }
        }
    }

    public class LabelEx : Label {
        public const int label_size = 100;
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint) {
            return new SizeRequest() { Request = new Size(label_size, label_size), Minimum = new Size(0, 0) };
        }
    }
}