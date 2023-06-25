using CSToolbox.Weak;
using MVVMToolbox.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFToolbox.Command
{
	public class DeferredCommandWPF : DeferredCommand
	{
		public DeferredCommandWPF(WeakAction.CallType execute, WeakDelegate<bool>.CallType? canExecute = null) : this(new WeakAction(execute), canExecute != null ? new WeakDelegate<bool>(canExecute) : null)
		{
		}

		public DeferredCommandWPF(WeakAction execute, WeakDelegate<bool>? canExecute = null) : base(execute, canExecute)
        {
			CommandManager.RequerySuggested += CommandManager_RequerySuggested;
        }

		private void CommandManager_RequerySuggested(object? sender, EventArgs e)
		{
			InvokeCanExecuteChanged();
		}
	}

	public class DeferredCommandWPF<T> : DeferredCommand<T>
	{
		public DeferredCommandWPF(WeakAction<T?>.CallType execute, WeakDelegate<bool, T?>.CallType? canExecute = null) : this(new WeakAction<T?>(execute), canExecute != null ? new WeakDelegate<bool, T?>(canExecute) : null)
		{
		}

		public DeferredCommandWPF(WeakAction<T?> execute, WeakDelegate<bool, T?>? canExecute = null) : base(execute, canExecute)
        {
			CommandManager.RequerySuggested += CommandManager_RequerySuggested;
        }

		private void CommandManager_RequerySuggested(object? sender, EventArgs e)
		{
			InvokeCanExecuteChanged();
		}
	}
}
