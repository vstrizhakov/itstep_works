using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Common;
using Hospital.Views;
using MaterialDesignThemes.Wpf;
using System.Security.Cryptography;
using System.Windows.Controls;
using Hospital.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;
using AutoLot.ViewModels;

namespace Hospital.ViewModels
{
	class RegisterViewModel : INotifyPropertyChanged
	{
		public RegisterViewModel()
		{
			String[] ss = StaticManager.SendRequest("getdoctors").Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String answer = ss[0];
			String parameters = ss[1];
			switch (answer)
			{
				case "OK":
					{
						MemoryStream MS = new MemoryStream();
						StreamWriter Sw = new StreamWriter(MS);
						Sw.Write(parameters);
						Sw.Flush();
						MS.Position = 0;

						DataContractJsonSerializer JS = new DataContractJsonSerializer(typeof(UserModel[]));
						UserModel[] doctors = (UserModel[])JS.ReadObject(MS);
						this.Doctors = new ObservableCollection<ComboBoxItemModel>();
						foreach (UserModel doctor in doctors)
							this.Doctors.Add(new ComboBoxItemModel(String.Format("{0} {1} {2}", doctor.Lastname, doctor.Firstname, doctor.Surname), doctor.Id));
						this.SelectedDoctor = this.Doctors[0];
						break;
					}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(String prop = "")
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private String lastname = "";
		public String Lastname
		{
			get { return this.lastname; }
			set
			{
				this.lastname = value;
				this.OnPropertyChanged("Lastname");
			}
		}

		private String firstname = "";
		public String Firstname
		{
			get { return this.firstname; }
			set
			{
				this.firstname = value;
				this.OnPropertyChanged("Firstname");
			}
		}

		private String surname = "";
		public String Surname
		{
			get { return this.surname; }
			set
			{
				this.surname = value;
				this.OnPropertyChanged("Surname");
			}
		}

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

		private String address = "";
		public String Address
		{
			get { return this.address; }
			set
			{
				this.address = value;
				this.OnPropertyChanged("Address");
			}
		}

		private String phone = "";
		public String Phone
		{
			get { return this.phone; }
			set
			{
				this.phone = value;
				this.OnPropertyChanged("Phone");
			}
		}

		private String age = "";
		public String Age
		{
			get { return this.age; }
			set
			{
				this.age = value;
				this.OnPropertyChanged("Age");
			}
		}

		private String height = "";
		public String Height
		{
			get { return this.height; }
			set
			{
				this.height = value;
				this.OnPropertyChanged("Height");
			}
		}

		private bool isDoctor = false;
		public bool IsDoctor
		{
			get { return this.isDoctor; }
			set
			{
				this.isDoctor = value;
				this.PatientVisibility = (value == true) ? Visibility.Collapsed : Visibility.Visible;
				this.OnPropertyChanged("IsDoctor");
			}
		}

		private Visibility patientVisibility = Visibility.Visible;
		public Visibility PatientVisibility
		{
			get { return this.patientVisibility; }
			set
			{
				this.patientVisibility = value;
				this.OnPropertyChanged("PatientVisibility");
			}
		}

		private String weight = "";
		public String Weight
		{
			get { return this.weight; }
			set
			{
				this.weight = value;
				this.OnPropertyChanged("Weight");
			}
		}

		private bool isMale = true;
		public bool IsMale
		{
			get { return this.isMale; }
			set
			{
				this.isMale = value;
				if (value == true)
					this.IsFemale = false;
				this.OnPropertyChanged("IsMale");
			}
		}

		private bool isFemale = false;
		public bool IsFemale
		{
			get { return this.isFemale; }
			set
			{
				this.isFemale = value;
				if (value == true)
					this.IsMale = false;
				this.OnPropertyChanged("IsFemale");
			}
		}

		private ObservableCollection<ComboBoxItemModel> doctors;
		public ObservableCollection<ComboBoxItemModel> Doctors
		{
			get { return this.doctors; }
			set
			{
				this.doctors = value;
				this.OnPropertyChanged("Doctors");
			}
		}

		private ComboBoxItemModel selectedDoctor;
		public ComboBoxItemModel SelectedDoctor
		{
			get { return this.selectedDoctor; }
			set
			{
				this.selectedDoctor = value;
				this.OnPropertyChanged("SelectedDoctor");
			}
		}

		private RelayCommand register;
		public RelayCommand Register
		{
			get { return this.register ?? (this.register = new RelayCommand(this.DoRegister)); }
		}

		private void DoRegister(object obj)
		{
			PasswordBox PB = (PasswordBox)obj;
			this.Lastname = this.Lastname.Trim();
			this.Firstname = this.Firstname.Trim();
			this.Surname = this.Surname.Trim();
			int sex = (this.IsMale) ? 0 : 1;
			this.Address = this.Address.Trim();
			this.Phone = this.Phone.Trim();
			double doctor_id = (!this.IsDoctor) ? StaticManager.User.Id : this.SelectedDoctor.Id;
			this.Age = this.Age.Trim();
			this.Height = this.Height.Trim();
			this.Weight = this.Weight.Trim();
			this.Username = this.Username.Trim();
			String password = PB.Password.Trim();

			String[] ss = StaticManager.SendRequest(String.Format("register|{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}&{9}&{10}&{11}&{12}",
				this.Lastname, this.Firstname, this.Surname, sex, this.Address, this.Phone, doctor_id,
				this.Age, this.Height, this.Weight, this.Username, password, (this.IsDoctor) ? 1 : 0)).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String result = ss[0];
			String parameters = ss[1];
			if (result != "ERROR")
			{
				if (StaticManager.User == null)
				{
					StaticManager.User = (UserModel)StaticManager.Deserialize(parameters, typeof(UserModel));
					StaticManager.ChangeInterfaceToLoged();
				}
				else
				{
					StaticManager.MWVL.SelectedMenuItem = StaticManager.MWVL.SelectedMenuItem;
					if (((UserControl)StaticManager.MWVL.SelectedMenuItem.Content).DataContext is PatientsViewModel)
					{
						PatientsViewModel PVM = (PatientsViewModel)((UserControl)StaticManager.MWVL.SelectedMenuItem.Content).DataContext;
						PVM.Renew();
					}
				}
			}
			else
				StaticManager.ErrorMessage = parameters;
		}
	}
}
