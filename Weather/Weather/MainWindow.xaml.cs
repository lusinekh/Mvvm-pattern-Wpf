using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;

namespace Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class EmailData
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Location { set; get; }
    }
    public partial class MainWindow : Window
    {
        CountriesModels result;
        current result1;
        public MainWindow()
        {
            InitializeComponent();

            var data = File.ReadAllText(@"C:\Users\khachatryan.lusine\Desktop\countriesToCities.json.txt");

            result = JsonConvert.DeserializeObject<CountriesModels>(data);
          
            var Countreas = result.GetType().GetProperties().ToList().Select(p => p.Name);

            ComboBox1.ItemsSource = Countreas;
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCountry = ComboBox1.SelectedValue.ToString();
            var CetysPropList = result.GetType().GetProperty(selectedCountry);
            var srlectedCetysValusList = (List<string>)CetysPropList.GetValue(result);
            ComboBox2.ItemsSource = srlectedCetysValusList;
        }


        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Lable1.Content = "Name";
                Lable2.Content = "Country";
                Lable3.Content = "Id";
                Lable4.Content = "Sun";
                Lable5.Content = "MinField";
                Lable6.Content = "MaxField";


                var selectedSity = ComboBox2.SelectedValue.ToString();
               
                var posturi = new Posturi();
                var value = posturi.GetData(selectedSity);

                ConverterXmlToObjectl converter = new ConverterXmlToObjectl();
                var result = converter.Converter(value);
               
                Lable1.Content += "   " + result.city.name;
                Lable2.Content += "   " + result.city.country;
                Lable3.Content += "   " + result.city.id;
                Lable4.Content += "   " + result.city.sun;
                Lable5.Content += "   " + result.temperature.min;
                Lable6.Content += "   " + result.temperature.max;
                
            }

            catch(Exception)
            {
                MessageBox.Show("Country dont contain");

            }

        }
    }
}
