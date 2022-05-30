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
using System.Windows.Input;

namespace DemoCenter.Forms.ViewModels {
    public class DelegateCommand : ICommand {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute) : this(execute, null) { }

        public DelegateCommand(Action execute, Func<bool> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            if(_canExecute != null)
                return _canExecute();
            return true;
        }

        public void Execute(object parameter) {
            _execute();
        }

        public void RaiseCanExecuteChanged() {
            var tmpHandle = CanExecuteChanged;
            if(tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
    public class DelegateCommand<T> : ICommand {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            if(_canExecute != null)
                return _canExecute((T)parameter);

            return true;
        }

        public void Execute(object parameter) {
            _execute((T)parameter);
        }

        public void RaiseCanExecuteChanged() {
            var tmpHandle = CanExecuteChanged;
            if(tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
