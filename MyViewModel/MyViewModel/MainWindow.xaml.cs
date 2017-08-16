
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Windows;

using System.Windows.Controls;

using System.Windows.Data;

using System.Windows.Documents;

using System.Windows.Input;

using System.Windows.Media;

using System.Windows.Media.Imaging;

using System.Windows.Navigation;

using System.Windows.Shapes;

using System.ComponentModel;



namespace MyViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Numbers nos = new Numbers();

        public MainWindow()
        {
            InitializeComponent();



            DataContext = new MyViewModel();
        }


        public class MyViewModel : INotifyPropertyChanged

        {

            private Numbers _numbers;

            public event PropertyChangedEventHandler PropertyChanged;



            public MyViewModel()

            {

                _numbers = new Numbers();

                CalculateGCDCommand = new MyCommand(CalculateGCD);

                CalculateLCMCommand = new MyCommand(CalculateLCM);

            }



            public Numbers Numbers

            {

                get

                {

                    return _numbers;

                }

                set

                {

                    _numbers = value;

                    RaisePropertyChanged("Numbers");

                }

            }



            private void RaisePropertyChanged(string propertyName)

            {

                PropertyChangedEventHandler handler = this.PropertyChanged;



                if (handler != null)

                {

                    handler(this, new PropertyChangedEventArgs(propertyName));

                }

            }



            public ICommand CalculateGCDCommand

            { get; set; }



            public ICommand CalculateLCMCommand

            { get; set; }



            private int CalculateGCD()

            {

                int x = Numbers.FirstNo;

                int y = Numbers.SecondNo;



                Numbers.Result = CalculateGCDInternal(x, y);

                Numbers.ResultLabel = "GCD";



                return Numbers.Result;

            }



            private int CalculateGCDInternal(int x, int y)

            {

                if (x == 0)

                    return 0;



                while (y != 0)

                {

                    if (x > y)

                        x = x - y;

                    else

                        y = y - x;

                }



                return x;

            }



            private int CalculateLCM()

            {

                int x = Numbers.FirstNo;

                int y = Numbers.SecondNo;



                int lcm = x * y / CalculateGCDInternal(x, y);



                Numbers.Result = lcm;

                Numbers.ResultLabel = "LCM";

                return lcm;

            }




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



        public class Numbers : DependencyObject

        {

            public static readonly DependencyProperty FirstNoProperty =

                DependencyProperty.Register("FirstNo", typeof(int), typeof(Numbers));



            public static readonly DependencyProperty SecondNoProperty =

                DependencyProperty.Register("SecondNo", typeof(int), typeof(Numbers));



            public static readonly DependencyProperty ResultProperty =

                DependencyProperty.Register("Result", typeof(int), typeof(Numbers));



            public static readonly DependencyProperty ResultLabelProperty =

                DependencyProperty.Register("ResultLabel", typeof(String), typeof(Numbers));



            public int FirstNo

            {

                get
                {
                    return (int)GetValue(FirstNoProperty);
                }

                set
                {
                    SetValue(FirstNoProperty, value);
                }

            }



            public int SecondNo

            {

                get { return (int)GetValue(SecondNoProperty); }

                set { SetValue(SecondNoProperty, value); }

            }



            public String ResultLabel

            {

                get { return (String)GetValue(ResultLabelProperty); }

                set { SetValue(ResultLabelProperty, value); }

            }



            public int Result

            {

                get { return (int)GetValue(ResultProperty); }

                set { SetValue(ResultProperty, value); }

            }

        }

    }
}
