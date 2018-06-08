using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Models;
using Hospital.Views;
using System.Configuration;
using System.Data.Common;
using MaterialDesignThemes.Wpf;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Hospital.ViewModels
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<MenuItemModel> menuItems;

		public ObservableCollection<MenuItemModel> MenuItems
		{
			get { return this.menuItems; }
			set
			{
				this.menuItems = value;
				this.SelectedMenuItem = this.menuItems[0];
				this.OnPropertyChanged("MenuItems");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string prop = "")
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private MenuItemModel selectedMenuItem;

		public MenuItemModel SelectedMenuItem
		{
			get { return this.selectedMenuItem; }
			set
			{
				this.selectedMenuItem = value;
				this.CurrentContent = value.Content;
				this.OnPropertyChanged("SelectedMenuItem");
			}
		}

		private object currentContent;

		public object CurrentContent
		{
			get { return this.currentContent; }
			set
			{
				this.currentContent = value;
				this.OnPropertyChanged("CurrentContent");
			}
		}

		public MainWindowViewModel()
		{
			StaticManager.MWVL = this;
		}

		public event CommonHandler OnClosing;
		public void Close()
		{
			if (StaticManager.DatabaseConnection != null)
				StaticManager.DatabaseConnection.Close();
			if (this.OnClosing != null)
				this.OnClosing();
		}

		private bool isOpen;
		public bool IsOpen
		{
			get { return this.isOpen; }
			set
			{
				this.isOpen = value;
				this.OnPropertyChanged("IsOpen");
			}
		}

		private String message;
		public String Message
		{
			get { return this.message; }
			set
			{
				this.message = value;
				this.OnPropertyChanged("Message");
			}
		}
	}
}
