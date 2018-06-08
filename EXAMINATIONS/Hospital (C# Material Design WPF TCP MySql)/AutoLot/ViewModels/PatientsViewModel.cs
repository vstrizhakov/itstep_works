using Hospital;
using Hospital.Models;
using Hospital.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoLot.ViewModels
{
	class PatientsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(String prop = "")
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private ObservableCollection<ComboBoxItemModel> patients;

		public ObservableCollection<ComboBoxItemModel> Patients
		{
			get { return this.patients; }
			set
			{
				this.patients = value;
				this.OnPropertyChanged("Patients");
			}
		}

		private UserModel User;

		public PatientsViewModel(UserModel UM)
		{
			this.User = UM;
			this.Renew();
		}

		private Visibility dlVisibility;

		public Visibility DLVisibility
		{
			get { return this.dlVisibility; }
			set
			{
				this.dlVisibility = value;
				this.OnPropertyChanged("DLVisibility");
			}
		}

		private Visibility textVisibility;

		public Visibility TextVisibility
		{
			get { return this.textVisibility; }
			set
			{
				this.textVisibility = value;
				this.OnPropertyChanged("TextVisibility");
			}
		}

		public void Renew()
		{
			String[] ss = StaticManager.SendRequest("getpatients|{0}", this.User.Id.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String status = ss[0];
			switch (status)
			{
				case "OK":
					{
						ObservableCollection<ComboBoxItemModel> patients = new ObservableCollection<ComboBoxItemModel>();
						ComboBoxItemModel[] CBIMs = (ComboBoxItemModel[])StaticManager.Deserialize(ss[1], typeof(ComboBoxItemModel[]));
						foreach (ComboBoxItemModel CBIM in CBIMs)
						{
							CBIM.GoToPatient = this.GoToPatient;
							patients.Add(CBIM);
						}
						this.Patients = patients;
						this.TextVisibility = Visibility.Collapsed;
						this.DLVisibility = Visibility.Visible;
						break;
					}
				case "EMPTY":
					{
						this.TextVisibility = Visibility.Visible;
						this.DLVisibility = Visibility.Collapsed;
						break;
					}
				case "ERROR":
					{
						StaticManager.ErrorMessage = ss[1];
						break;
					}
			}
		}

		private RelayCommand goToPatient;
		
		public RelayCommand GoToPatient
		{
			get
			{
				return this.goToPatient ?? (this.goToPatient = new RelayCommand((obj) =>
				{
					double id = (double)obj;
					String[] ss = StaticManager.SendRequest("getpatient|{0}", id.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
					String status = ss[0];
					switch (status)
					{
						case "OK":
							{
								UserModel UM = (UserModel)StaticManager.Deserialize(ss[1], typeof(UserModel));
								StaticManager.MWVL.SelectedMenuItem = new MenuItemModel("", new Results(UM));
								break;
							}
						case "ERROR":
							{
								StaticManager.ErrorMessage = ss[1];
								break;
							}
					}
				}));
			}
		}

		private RelayCommand createPatient;

		public RelayCommand CreatePatient
		{
			get
			{
				return this.createPatient ?? (this.createPatient = new RelayCommand((obj) =>
				{
					StaticManager.MWVL.CurrentContent = new Register();
				}));
			}
		}
	}
}
