using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Hospital.ViewModels
{
	class GraphicsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(String prop = "")
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private ObservableCollection<ComboBoxGraphicItem> results;

		public ObservableCollection<ComboBoxGraphicItem> Results
		{
			get { return this.results; }
			set
			{
				this.results = value;
				this.SelectedResultItem = this.results[0];
				this.OnPropertyChanged("Results");
			}
		}

		public ItemsControl IC { get; set; }

		private ComboBoxGraphicItem selectedResultItem;

		public ComboBoxGraphicItem SelectedResultItem
		{
			get { return this.selectedResultItem; }
			set
			{
				this.selectedResultItem = value;
				this.OnPropertyChanged("SelectedResultItem");
				GraphicItemsCollection GIs = new GraphicItemsCollection();
				foreach (Dictionary<String, String> list in this.ResultsList)
				{
					GraphicItem GI = new GraphicItem(list["Дата измерения"], list[value.NameForProgramm]);
					GIs.Add(GI);
				}
				this.GraphicItems = GIs.Get(this.IC.ActualHeight - 70);
			}
		}

		private RelayCommand goToResults;

		public RelayCommand GoToResults
		{
			get { return this.goToResults ?? (this.goToResults = new RelayCommand((obj) =>
			{
				StaticManager.MWVL.SelectedMenuItem = StaticManager.MWVL.SelectedMenuItem;
			})); }
		}

		private ObservableCollection<GraphicItem> graphicItems;

		public ObservableCollection<GraphicItem> GraphicItems
		{
			get { return this.graphicItems; }
			set
			{
				this.graphicItems = value;
				this.OnPropertyChanged("GraphicItems");
			}
		}

		private List<Dictionary<String, String>> ResultsList;

		public GraphicsViewModel(UserModel User, ItemsControl IC)
		{
			this.IC = IC;
			String[] ss = StaticManager.SendRequest("getdates|{0}", User.Id.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String status = ss[0];
			switch (status)
			{
				case "OK":
					{
						List<Dictionary<String, String>> results = new List<Dictionary<String, String>>();
						ComboBoxItemModel[] CBIMs = (ComboBoxItemModel[])StaticManager.Deserialize(ss[1], typeof(ComboBoxItemModel[]));
						foreach (ComboBoxItemModel CBIM in CBIMs)
							results.Add(ResultsViewModel.GetResult(User, CBIM.Id));
						this.ResultsList = results;

						ObservableCollection<ComboBoxGraphicItem> tmp = new ObservableCollection<ComboBoxGraphicItem>();
						tmp.Add(new ComboBoxGraphicItem("Пульс", "Пульс"));
						tmp.Add(new ComboBoxGraphicItem("САД", "Систолическое АД"));
						tmp.Add(new ComboBoxGraphicItem("ДАД", "Диастолическое АД"));
						tmp.Add(new ComboBoxGraphicItem("Hb", "Hb"));
						tmp.Add(new ComboBoxGraphicItem("SaO2", "SaO2ET"));
						tmp.Add(new ComboBoxGraphicItem("ПТ", "ПТ"));
						tmp.Add(new ComboBoxGraphicItem("ИМТ", "ИМТ"));
						tmp.Add(new ComboBoxGraphicItem("Стрессоустойчивость", "Стрессоустойчивость"));
						tmp.Add(new ComboBoxGraphicItem("САД", "САД"));
						tmp.Add(new ComboBoxGraphicItem("ПО2", "ПО2"));
						tmp.Add(new ComboBoxGraphicItem("ОО", "ОО"));
						tmp.Add(new ComboBoxGraphicItem("МОК", "МОК"));
						tmp.Add(new ComboBoxGraphicItem("СИ", "СИ"));
						tmp.Add(new ComboBoxGraphicItem("УОС", "УОС"));
						tmp.Add(new ComboBoxGraphicItem("ЧСС", "Пульс"));
						tmp.Add(new ComboBoxGraphicItem("ККД", "ККД"));
						tmp.Add(new ComboBoxGraphicItem("ИРЛЖ", "ИРЛЖ"));
						tmp.Add(new ComboBoxGraphicItem("ИПСС", "ИПСС"));
						tmp.Add(new ComboBoxGraphicItem("ПТО", "ПТО"));
						tmp.Add(new ComboBoxGraphicItem("Ht", "Ht"));
						tmp.Add(new ComboBoxGraphicItem("ЛШК", "ЛШК"));
						tmp.Add(new ComboBoxGraphicItem("CaO2", "CaO2"));
						tmp.Add(new ComboBoxGraphicItem("av", "av"));
						tmp.Add(new ComboBoxGraphicItem("CvO2", "CvO2"));
						tmp.Add(new ComboBoxGraphicItem("SvO2", "SvO2"));
						tmp.Add(new ComboBoxGraphicItem("ДО2", "ДО2"));
						tmp.Add(new ComboBoxGraphicItem("КПД", "КПД"));
						tmp.Add(new ComboBoxGraphicItem("КПП", "КПП"));
						tmp.Add(new ComboBoxGraphicItem("УК", "УК"));
						tmp.Add(new ComboBoxGraphicItem("БП", "БП"));
						tmp.Add(new ComboBoxGraphicItem("ЭПП", "ЭПП"));
						tmp.Add(new ComboBoxGraphicItem("БК", "БК"));
						tmp.Add(new ComboBoxGraphicItem("ЭДК", "ЭДК"));
						tmp.Add(new ComboBoxGraphicItem("КБЦ", "КБЦ"));
						tmp.Add(new ComboBoxGraphicItem("У", "У"));
						tmp.Add(new ComboBoxGraphicItem("К", "К"));
						tmp.Add(new ComboBoxGraphicItem("КИТС", "КИТС"));
						tmp.Add(new ComboBoxGraphicItem("ОП", "ОП"));
						tmp.Add(new ComboBoxGraphicItem("ДСАД", "ДСАД"));
						tmp.Add(new ComboBoxGraphicItem("ДДАД", "ДДАД"));
						tmp.Add(new ComboBoxGraphicItem("ДСАД (СРЕДНЕЕ)", "ДСАД (среднее)"));
						tmp.Add(new ComboBoxGraphicItem("ДОО", "ДОО"));
						tmp.Add(new ComboBoxGraphicItem("ДУОС", "ДУОС"));
						tmp.Add(new ComboBoxGraphicItem("ДККД", "ДУОС"));
						tmp.Add(new ComboBoxGraphicItem("ДИРЛЖ", "ДИРЛЖ"));
						tmp.Add(new ComboBoxGraphicItem("ДИПСС", "ДИПСС"));
						tmp.Add(new ComboBoxGraphicItem("ДПТО", "ДПТО"));
						tmp.Add(new ComboBoxGraphicItem("ДЛШК", "ДЛШК"));
						tmp.Add(new ComboBoxGraphicItem("ДПО2", "ДПО2"));
						tmp.Add(new ComboBoxGraphicItem("ДСИ", "ДСИ"));
						tmp.Add(new ComboBoxGraphicItem("ДМОК", "ДМОК"));
						tmp.Add(new ComboBoxGraphicItem("ДЧСС", "ДЧСС"));
						tmp.Add(new ComboBoxGraphicItem("ДCaO2", "ДCaO2"));
						tmp.Add(new ComboBoxGraphicItem("Дav", "Дav"));
						tmp.Add(new ComboBoxGraphicItem("ДCvO2", "ДCvO2"));
						tmp.Add(new ComboBoxGraphicItem("ДSvO2", "ДSvO2"));
						tmp.Add(new ComboBoxGraphicItem("ДДО2", "ДДО2"));
						tmp.Add(new ComboBoxGraphicItem("ДКПД", "ДКПД"));
						this.Results = tmp;
						break;
					}
				case "EMPTY":
				case "ERROR":
					{
						if (ss.Length > 1)
							StaticManager.ErrorMessage = ss[1];
						StaticManager.MWVL.CurrentContent = StaticManager.MWVL.SelectedMenuItem.Content;
						return;
					}
			}

		}
	}

	class ComboBoxGraphicItem
	{
		public String NameForUser { get; set; }
		public String NameForProgramm { get; set; }

		public ComboBoxGraphicItem(String nfu, String nfp)
		{
			this.NameForUser = nfu;
			this.NameForProgramm = nfp;
		}
	}

	class GraphicItem
	{
		public String Date { get; set; }
		public int Height { get; set; }
		public String Value { get; set; }

		public GraphicItem(String date, String value)
		{
			DateTime DT = DateTime.Parse(date);
			this.Date = DT.ToShortDateString() + " " + DT.ToLongTimeString();
			this.Value = value;
		}
	}

	class GraphicItemsCollection
	{
		private ObservableCollection<GraphicItem> Items = new ObservableCollection<GraphicItem>();
		private double MaxValue = 0;
		private double MinValue = 0;

		public ObservableCollection<GraphicItem> Get(double ActualHeight)
		{
			bool operation;
			if (this.MinValue >= 0)
			{
				this.MaxValue -= this.MinValue;
				operation = false;
			}
			else
			{
				this.MaxValue += this.MinValue * -1;
				operation = true;
			}
			foreach (GraphicItem GI in this.Items)
			{
				double tmp = Double.Parse(GI.Value);
				double percent;
				if (operation)
					percent = ((tmp + this.MinValue * -1) * 100 / this.MaxValue);
				else
					percent = (int)((tmp - this.MinValue) * 100 / this.MaxValue);
				GI.Height = (int)(percent * ActualHeight / 100) + 1;
			}
			return this.Items;
		}

		public void Add(GraphicItem GI)
		{
			this.Items.Add(GI);
			double val = Double.Parse(GI.Value);
			if (val > this.MaxValue)
				this.MaxValue = val;
			if (val < this.MinValue)
				this.MinValue = val;
		}
	}
}
