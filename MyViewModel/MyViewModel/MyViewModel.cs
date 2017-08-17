using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyViewModel
{
    public class MyViewModel1 : INotifyPropertyChanged

    {

        private Numbers _numbers;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public MyViewModel1()

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
        

    }
}
