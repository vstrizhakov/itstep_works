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
using AutoLot.ViewModels;
using Hospital.Models;

namespace Hospital.Views
{
	/// <summary>
	/// Логика взаимодействия для Patients.xaml
	/// </summary>
	public partial class Patients : UserControl
	{
		public Patients(UserModel UM)
		{
			InitializeComponent();
			this.DataContext = new PatientsViewModel(UM);
		}
	}
}
