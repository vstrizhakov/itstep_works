using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Hospital.Views;
using MaterialDesignThemes.Wpf;
using System.Data.Common;
using System.Security.Cryptography;
using System.Windows.Controls;
using Hospital.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Hospital.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
		private String username = "";

		public String Username
		{
			get { return this.username; }
			set
			{
				this.username = value;
				this.OnPropertyChanged("Username");
			}
		}

		/*
		 Срабатывает при нажатии кнопки "Sign In" если все поля заполнены
		 Проверяет введенные данные и если все правильно, перенаправляет пользователя в главное окно
		 Иначе выводит ошибку
			 */
		private RelayCommand login;
        public RelayCommand Login
        {
            get { return this.login ?? (this.login = new RelayCommand(this.DoLogin)); }
        }

		private void DoLogin(object obj)
		{
			PasswordBox PB = (PasswordBox)obj;
			String password = PB.Password.Trim();

			String[] ss = StaticManager.SendRequest(String.Format("login|{0}&{1}", this.Username, password)).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String result = ss[0];
			String parameters = ss[1];
			if (result != "ERROR")
			{
				StaticManager.User = (UserModel)StaticManager.Deserialize(parameters, typeof(UserModel));
				StaticManager.ChangeInterfaceToLoged();
			}
			else
				StaticManager.ErrorMessage = parameters;
		}

		private RelayCommand register;
		public RelayCommand ToRegister
		{
			get { return this.register ?? (this.register = new RelayCommand(this.GoToRegister)); }
		}

		private void GoToRegister(object obj)
		{
			StaticManager.MWVL.SelectedMenuItem = StaticManager.MWVL.MenuItems[1];
		}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(String prop = "")
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
