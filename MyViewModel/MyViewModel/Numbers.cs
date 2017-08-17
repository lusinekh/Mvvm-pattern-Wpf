using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyViewModel
{
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

