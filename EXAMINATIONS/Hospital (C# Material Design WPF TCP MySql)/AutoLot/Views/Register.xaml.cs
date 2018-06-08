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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.ViewModels;

namespace Hospital.Views
{
	/// <summary>
	/// Логика взаимодействия для Register.xaml
	/// </summary>
	public partial class Register : UserControl
	{
		public Register()
		{
			InitializeComponent();
			this.DataContext = new RegisterViewModel();
		}

		private void IsDoctor_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{

		}
	}
}
