﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Address_Book_WPFApp.Helpers
{
    internal abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
    }
}
