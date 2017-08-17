using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyViewModel
{
    public class MyCommand : ICommand

    {

        public Func<int> Function

        { get; set; }
        
        public MyCommand()

        {

        }
        
        public MyCommand(Func<int> function)

        {

            Function = function;

        }
        
        public bool CanExecute(object parameter)

        {

            if (Function != null)

            {

                return true;

            }
            
            return false;

        }
        
        public void Execute(object parameter)

        {

            if (Function != null)

            {

                Function();

            }

        }
        
        public event EventHandler CanExecuteChanged

        {

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

    }

}
