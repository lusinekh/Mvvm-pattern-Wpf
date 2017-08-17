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

            CalculateDivCommand = new MyCommand(CalculateDiv);

            CalculateMullCommand = new MyCommand(CalculateMull);


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



        public ICommand CalculateMullCommand
        {
            get;set;
        }



        public ICommand CalculateDivCommand
        {
            get;set;
        }


        private int CalculateMull()
        {
            int x = Numbers.FirstNo;
            int y = Numbers.SecondNo;
            Numbers.Result = CalculateMulInternal(x, y);
            Numbers.ResultLabel = "Mull";
            return Numbers.Result;
            
        }


        private int CalculateDiv()
        {
            int x = Numbers.FirstNo;
            int y = Numbers.SecondNo;
            Numbers.Result = CalculateDivInternal(x, y);
            Numbers.ResultLabel = "Div";
            return Numbers.Result;

        }

        private int CalculateGCD()

        {

            int x = Numbers.FirstNo;

            int y = Numbers.SecondNo;
            
            Numbers.Result = CalculateGCDInternal(x, y);

            Numbers.ResultLabel = "GCD";
            
            return Numbers.Result;

        }
        private int  CalculateMulInternal(int x,int y)
        {
            return x * y;

        }
        private int CalculateDivInternal(int x,int y)

        {
            if (y == 0)
                return 0;

            return x / y;


        }
        
        private int CalculateGCDInternal(int x, int y)

        {
            int a;
            if (x == 0)

            {
                a= y;
            }
            else
            if (y == 0)
            {
                a= x;
            }
            else
            if (x > y)
            {
                a=x - y;
            }

            else
               a=y - x;

            return a;
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
