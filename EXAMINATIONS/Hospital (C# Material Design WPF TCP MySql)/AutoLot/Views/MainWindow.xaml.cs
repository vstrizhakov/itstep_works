using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.ViewModels;
using MaterialDesignThemes.Wpf;

namespace Hospital.Views
{
	/// <summary>
	/// Логика взаимодействия для Main.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<MenuItem> MenuItems = new ObservableCollection<MenuItem>();
		private static Snackbar Snackbar;
		public MainWindow()
		{
			InitializeComponent();
			MainWindowViewModel customer = new MainWindowViewModel();
			this.DataContext = customer;
			customer.OnClosing += () =>
			{
				this.Close();
			};

			StaticManager.Start();
		}
	}
}
