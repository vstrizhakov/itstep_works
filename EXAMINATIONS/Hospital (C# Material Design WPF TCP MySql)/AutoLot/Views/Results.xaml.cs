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
using Hospital.Models;
using Hospital.ViewModels;

namespace Hospital.Views
{
	/// <summary>
	/// Логика взаимодействия для Results.xaml
	/// </summary>
	public partial class Results : UserControl
	{
		public Results(UserModel UM)
		{
			InitializeComponent();
			this.DataContext = new ResultsViewModel(UM);
		}
	}
}
