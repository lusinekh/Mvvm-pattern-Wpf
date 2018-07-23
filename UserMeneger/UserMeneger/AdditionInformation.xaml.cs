using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserMeneger
{
	/// <summary>
	/// Interaction logic for AdditionInformation.xaml
	/// </summary>
	public partial class AdditionInformation : Window
	{
		public AdditionInformation()
		{
			InitializeComponent();
		}


		public string GetUser()
		{
			this.ShowDialog();


			return $"\"Key\":\"{ Key.Text}\", \"Value\":\"{ Value.Text}\" ";
		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult=true;
			this.Close();
		}
	}
}
