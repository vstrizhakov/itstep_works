using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;

namespace Hospital.ViewModels
{
	class AddResultViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(String prop = "")
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private RelayCommand goToResults;

		public RelayCommand GoToResults
		{
			get
			{
				return this.goToResults ?? (this.goToResults = new RelayCommand((obj) =>
				{
					StaticManager.MWVL.SelectedMenuItem = StaticManager.MWVL.SelectedMenuItem;
				}));
			}
		}

		private double Id;

		public AddResultViewModel(double id)
		{
			this.Id = id;
		}

		private String pulse;
		private String sap;
		private String dap;
		private String hb;
		private String sao;

		public String Pulse
		{
			get { return this.pulse; }
			set
			{
				this.pulse = value;
				this.OnPropertyChanged("Pulse");
			}
		}

		public String Sap
		{
			get { return this.sap; }
			set
			{
				this.sap = value;
				this.OnPropertyChanged("Sap");
			}
		}

		public String Dap
		{
			get { return this.dap; }
			set
			{
				this.dap = value;
				this.OnPropertyChanged("Dap");
			}
		}

		public String Hb
		{
			get { return this.hb; }
			set
			{
				this.hb = value;
				this.OnPropertyChanged("Hb");
			}
		}

		public String Sao
		{
			get { return this.sao; }
			set
			{
				this.sao = value;
				this.OnPropertyChanged("Sao");
			}
		}

		private RelayCommand add;

		public RelayCommand Add
		{
			get { return this.add ?? (this.add = new RelayCommand((obj) =>
			{
				String[] ss = StaticManager.SendRequest("addresult|{0}&{1}&{2}&{3}&{4}&{5}", this.Pulse, this.Sap, this.Dap, this.Hb, this.Sao, this.Id.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				String status = ss[0];
				switch (status)
				{
					case "OK":
						{
							StaticManager.MWVL.SelectedMenuItem = StaticManager.MWVL.SelectedMenuItem;
							if (((UserControl)StaticManager.MWVL.SelectedMenuItem.Content).DataContext is ResultsViewModel)
							{
								ResultsViewModel RVM = (ResultsViewModel)((UserControl)StaticManager.MWVL.SelectedMenuItem.Content).DataContext;
								RVM.Renew();
							}
							break;
						}
					case "ERROR":
						{
							String parameters = ss[1];
							StaticManager.ErrorMessage = parameters;
							break;
						}
				}
			})); }
		}
	}
}
