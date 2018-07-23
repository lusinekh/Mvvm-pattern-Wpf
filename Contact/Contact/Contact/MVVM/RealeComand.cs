﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Contact.MVVM
{
	public class RelayCommand : ICommand
	{
		#region Members
		readonly Func<Boolean> _canExecute;
		readonly Action _execute;
		#endregion

		#region Constructors
		public RelayCommand(Action execute)
			: this(execute, null)
		{
		}
		public RelayCommand(Action execute, Func<Boolean> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion

		#region ICommand Members
		public event EventHandler CanExecuteChanged
		{
			add
			{

				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}
			remove
			{

				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}
        
		public Boolean CanExecute(Object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		public void Execute(Object parameter)
		{
			_execute();
		}
		#endregion
	}
}