using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using MaterialDesignThemes;
using Hospital.Views;

namespace Hospital.ViewModels
{
	class ResultsViewModel : INotifyPropertyChanged
	{
		
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(String prop = "")
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private ObservableCollection<ComboBoxItemModel> dates;

		public ObservableCollection<ComboBoxItemModel> Dates
		{
			get { return this.dates; }
			set
			{
				this.dates = value;
				this.OnPropertyChanged("Dates");
			}
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

		private ComboBoxItemModel selectedDate;

		public ComboBoxItemModel SelectedDate
		{
			get { return this.selectedDate; }
			set
			{
				ComboBoxItemModel tmp = value;
				Dictionary<String, String> results = ResultsViewModel.GetResult(this.User, tmp.Id);
				if (results != null)
				{
					this.selectedDate = value;
					ObservableCollection<ResultItem> rslts = new ObservableCollection<ResultItem>();
					foreach (KeyValuePair<String, String> result in results)
						rslts.Add(new ResultItem(result.Key, result.Value));
					this.Results = rslts;
					this.OnPropertyChanged("SelectedDate");
				}
			}
		}

		private ObservableCollection<ResultItem> results;

		public ObservableCollection<ResultItem> Results
		{
			get { return this.results; }
			set
			{
				this.results = value;
				this.OnPropertyChanged("Results");
			}
		}

		private RelayCommand addResult;

		public RelayCommand AddResult
		{
			get { return this.addResult ?? (this.addResult = new RelayCommand((obj) =>
			{
				StaticManager.MWVL.CurrentContent = new AddResult(this.User.Id);
			})); }
		}

		private RelayCommand buildGraphics;

		public RelayCommand BuildGraphics
		{
			get { return this.buildGraphics ?? (this.buildGraphics = new RelayCommand((obj) =>
			{
				StaticManager.MWVL.CurrentContent = new Graphics(this.User);
			})); }
		}

		private RelayCommand removeResult;

		public RelayCommand RemoveResult
		{
			get
			{
				return this.removeResult ?? (this.removeResult = new RelayCommand((obj) =>
				{
					String[] ss = StaticManager.SendRequest("removeresult|{0}", ((double)obj).ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
					String status = ss[0];
					if (status == "ERROR")
						StaticManager.ErrorMessage = ss[1];
					this.Renew();
				}));
			}
		}

		private UserModel User;

		public ResultsViewModel(UserModel UM)
		{
			this.User = UM;
			this.Renew();
		}

		public void Renew()
		{
			String[] ss = StaticManager.SendRequest("getdates|{0}", this.User.Id.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String status = ss[0];
			switch (status)
			{
				case "OK":
					{
						ObservableCollection<ComboBoxItemModel> dates = new ObservableCollection<ComboBoxItemModel>();
						ComboBoxItemModel[] CBIMs = (ComboBoxItemModel[])StaticManager.Deserialize(ss[1], typeof(ComboBoxItemModel[]));
						foreach (ComboBoxItemModel CBIM in CBIMs)
							dates.Add(CBIM);
						this.Dates = dates;
						this.SelectedDate = this.Dates[0];
						this.DLVisibility = Visibility.Visible;
						this.TextVisibility = Visibility.Collapsed;
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

		static public Dictionary<String, String> GetResult(UserModel User, double id)
		{
			String[] ss = StaticManager.SendRequest("getstatistic|{0}", id.ToString()).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			String status = ss[0];
			if (status == "ERROR")
			{
				StaticManager.ErrorMessage = ss[1];
				return null;
			}

			StatisticsModel SM = (StatisticsModel)StaticManager.Deserialize(ss[1], typeof(StatisticsModel));

			String date = SM.Date;
			double pulse = SM.Pulse;
			double sap = SM.Sap;
			double dap = SM.Dap;
			double hb = SM.Hb;
			double SaO2ET = SM.Sao;

			double height = User.Weight;
			double weight = User.Height;
			int age = User.Age;
			bool sex = User.Sex == 0;

			double mediumap = dap + (sap - dap) / 3;
			double pt = Math.Sqrt(height * weight / 3600);
			double imt = weight / height / 100 * height / 100;
			double pap = Math.Round(sap) - Math.Round(dap);
			double uos = 100 + (pap / 2) - 0.6 * dap - 0.6 * age;
			double mok = uos * pulse / 1000;
			double si = mok / pt;
			double po2 = (si + 0.382) / 0.026;
			double oo = 7.07 * po2;
			double kkd = uos / mediumap;
			double irlg = 0.0144 * mediumap * si;
			double ipss = mediumap * 80 / si;
			double ht = Math.Round(hb) / 300;
			double CaO2 = 1.3 * Math.Round(hb);
			double av = po2 / si;
			double CvO2 = CaO2 - av;
			double SvO2 = 100 * CvO2 / CaO2;
			double lshk = 0.04 / (1 - SvO2 / 100) * 100;
			double do2 = CaO2 * si;
			double kpd = do2 / pulse;
			double kpp = po2 / pulse;
			double uk = 100 * av / CaO2;
			double doo = 1.0;
			double dCaO2 = 1.0;
			double dpto = 1.0;
			if (sex)
			{
				doo = 66.47 + 13.75 * weight + 5 * height / 100 - 6.77 * age;
				dCaO2 = 1.3 * 140;
				dpto = 4.57;
			}
			else
			{
				doo = 655.1 + 2.56 * weight + 1.85 * height / 100 - 4.67 * age;
				dCaO2 = 1.3 * 120;
				dpto = 3.8;
			}
			double bp = oo / doo * 100;
			double dsad = 102 + age * 0.6;
			double ddad = 63 + age * 0.4;
			double dmad = 80 + age * 0.3;
			double duos = (100 + pap / 2) - 0.6 * Math.Round(dap) - 0.6 * age;
			double u = (600 - do2) / 6;
			if (u < 0)
				u = u - u * 2;
			double k = (170 - po2) / 1.7;
			if (k < 0)
				k = k - k * 2;
			double kits = (u + k) / 2;
			double op = 100 - kits;

			double stress = 100 - (k + u);
			double unstress = -(100 - (k + u));
			double pto = k / (1 - ht) - 1;
			double dpo2 = doo / 7.07;
			double dsi = dpo2 * 0.026 - 0.382;
			double dmok = dsi * pt;
			double dchss = doo / 422 / duos;
			double dav = dpo2 / dsi;
			double dCvO2 = dCaO2 - dav;
			double dSvO2 = (100 * (dCaO2 - dav)) / (1.34 * Math.Round(hb));
			double ddo2 = dCaO2 * dsi;
			double dkpd = ddo2 / dchss;
			double dkpp = dpo2 / dchss;
			double duk = 100 * dav / dCaO2;
			double epp = do2 / ddo2 * 100;
			double bk = kpp / weight * (100);
			double edk = kpd / weight * (100);
			double kbc = 60 / (pulse);
			double dkkd = duos / dsad;
			double dirlg = 0.0144 * dsad * dsi;
			double dipss = (dsad * 80) / dsi;
			double dlshk = 0.04 / (1 - dSvO2) * 100;
			double dbk = dkpp / weight * 100;
			double dedk = dkpd / weight * 100;
			double dkbc = 60 / dchss;
			double du = (600 - ddo2) / 6;
			double dk = (170 - dpo2) / 1.7;
			if (dk < 0)
				dk = dk - dk * 2;
			double dkits = du + dk / 2;
			if (dkits < 0)
				dkits = dkits - dkits * 2;
			double dop = 100 - dkits;
			double ppo2 = 1.0;
			double dtk = 1.34 * hb * 0.96 * dsi;
			double dads = ddad / 0.618;
			double mdoo = 66.47f + 13.75f * weight + 5 * height - 0.77 * age;
			double gdoo = 655.1f + 9.56f * weight + 1.85 * height - 4.67 * age;
			double kesr = (220 - age - pulse) / pulse;
			double kesn = (pulse - 220 + age) / pulse;
			double q = ppo2 / po2;
			double ktesr = 100 * (1 - q);
			double ktesn = 100 * (q - 1);
			double Cx = ppo2 / si;
			double mmesr = 100 * (av - Cx) / av;
			double mmesn = 100 * (Cx - av) / Cx;
			double kib = ((ppo2 - 148) / ppo2) * 100;
			double ad = 100 + 100 * (ppo2 - dpo2) / ppo2;
			double d = 100 * (dpo2 - ppo2) / dpo2;
			double st = 100 + 100 * (po2 - ppo2) / po2;
			double nest = 100 * (ppo2 - po2) / ppo2;
			double adek = ad + st;
			double neadek = d + nest;
			double tk = 1.34 * hb * SaO2ET * si;
			double ed = (100 * tk) / dtk;
			double kio = (148 - ppo2) / 1.48;
			double oop = ppo2 * 7.07;
			double dvo2 = ddo2 / 3.2;
			double vo2 = oo / 7.07;
			double pvo2 = 1.0;
			if (vo2 > dvo2)
				pvo2 = 80.7 + 0.52 * vo2;
			else
				pvo2 = 63.4 + 0.60 * vo2;
			double gds = (100 * (dap / ad) / (0.599 - 0.636)) + 100;
			double gdes = 100 * (dap / ad) - 0.636 / (dap / ad);
			double gipd = 100 * (0.599 - (dap / ad)) / (dap / ad);
			double bp0 = 1.0;
			String bp00 = "qwer";
			if (bp <= 84)
			{
				bp0 = 84 - bp;
				bp00 = "БП1: " + bp0 + " (патоэнергобиотия)";
			}
			if (bp >= 84 && bp <= 150)
			{
				bp0 = 150 - bp;
				bp00 = "БП2: " + bp0 + " (гипоэнегробиотия)";
			}
			if (bp >= 151 && bp <= 177)
			{
				bp0 = 177 - bp;
				bp00 = "БП3: " + bp0 + " (эуэнергобиотия)";
			}
			if (bp >= 178)
			{
				bp0 = bp - 178;
				bp00 = "БП4: " + bp0 + " (гиперэнергобиотия)";
			}
			double ptk = tk * q;
			double ed0 = 1.0;
			String ed00 = "qwer";
			if (ed <= 84)
			{
				ed0 = 84 - ed;
				ed00 = "ЭД1: " + ed0 + " (патоэнергобиотия)";
			}
			if (ed >= 84 && ed <= 150)
			{
				ed0 = 150 - ed;
				ed00 = "ЭД2: " + ed0 + " (гипоэнегробиотия)";
			}
			if (ed >= 151 && ed <= 177)
			{
				ed0 = 177 - ed;
				ed00 = "ЭД3: " + ed0 + " (эуэнергобиотия)";
			}
			if (ed >= 178)
			{
				ed0 = ed - 178;
				ed00 = "ЭД4: " + ed0 + " (гиперэнергобиотия)";
			}
			double rosmp = 322 - 0.026 * tk - 0.137 * po2;
			double dosmp = 322 - 0.026 * dtk - 0.137 * dpo2;
			double osmp = 1.0;
			double posmp = 322 - 0.026 * ptk - 0.137 * ppo2;
			double diastdesess = 100 * ((dap / sap) - 0.636) / (dap / sap);
			double Qx = 1.0;
			double avO2 = 1.0;
			double ktnedess = 100 * (Qx - 1);
			double mmnedesa = 100 * (Cx - avO2) / Cx;
			double pdO2 = do2 * Qx;
			double posmp2 = 322 - 0.026 * pdO2 - 0.137 * pvo2;
			double gipoosmdestess = 100 * (posmp2 - osmp) / posmp2;
			double giperosmdestess = 100 * (osmp - posmp2) / osmp;
			double kioesa = ((148 - pvo2) / 148) * 100;
			double posmps = posmp;
			double kos = (posmps - posmp) * 100 / posmps;
			double gd = 100 * (osmp - posmp) / osmp;
			double posm = 1.0;
			double gipod = 100 * (posm - posmp) / posmp;

			Dictionary<String, String> result = new Dictionary<String, String>();
			result.Add("Пациент", String.Format("{0} {1} {2}", User.Lastname, User.Firstname, User.Surname));
			result.Add("Дата измерения", date);
			result.Add("Пульс", pulse.ToString());
			result.Add("Систолическое АД", sap.ToString());
			result.Add("Диастолическое АД", dap.ToString());
			result.Add("Hb", hb.ToString());
			result.Add("SaO2ET", SaO2ET.ToString());
			result.Add("САД", mediumap.ToString());
			result.Add("ПТ", pt.ToString());
			result.Add("ИМТ", imt.ToString());
			result.Add("Пульсовое АД", pap.ToString());
			result.Add("УОС", uos.ToString());
			result.Add("Стрессоустойчивость", stress.ToString());
			result.Add("МОК", mok.ToString());
			result.Add("СИ", si.ToString());
			result.Add("ПО2", po2.ToString());
			result.Add("ОО", oo.ToString());
			result.Add("ККД", kkd.ToString());
			result.Add("ИРЛЖ", irlg.ToString());
			result.Add("ИПСС", ipss.ToString());
			result.Add("Ht", ht.ToString());
			result.Add("CaO2", CaO2.ToString());
			result.Add("av", av.ToString());
			result.Add("CvO2", CvO2.ToString());
			result.Add("SvO2", SvO2.ToString());
			result.Add("ЛШК", lshk.ToString());
			result.Add("ДО2", do2.ToString());
			result.Add("КПД", kpd.ToString());
			result.Add("КПП", kpp.ToString());
			result.Add("УК", uk.ToString());
			result.Add("ДККД", dkkd.ToString());
			result.Add("ДИРЛЖ", dirlg.ToString());
			result.Add("ДИПСС", dipss.ToString());
			result.Add("ДПТО", dpto.ToString());
			result.Add("ДЛШК", dlshk.ToString());
			result.Add("ДОО", doo.ToString());
			result.Add("БП", bp.ToString());
			result.Add("ЭПП", epp.ToString());
			result.Add("БК", bk.ToString());
			result.Add("ЭДК", edk.ToString());
			result.Add("КБЦ", kbc.ToString());
			result.Add("ДСАД", dsad.ToString());
			result.Add("ДДАД", ddad.ToString());
			result.Add("ДСАД (среднее)", dmad.ToString());
			result.Add("ДУОС", duos.ToString());
			result.Add("У", u.ToString());
			result.Add("K", k.ToString());
			result.Add("КИТС", kits.ToString());
			result.Add("ОП", op.ToString());
			result.Add("ПТО", pto.ToString());
			result.Add("ДПО2", dpo2.ToString());
			result.Add("ДСИ", dsi.ToString());
			result.Add("ДМОК", dmok.ToString());
			result.Add("ДЧСС", dchss.ToString());
			result.Add("ДCaO2", dCaO2.ToString());
			result.Add("Дav", dav.ToString());
			result.Add("ДCvO2", dCvO2.ToString());
			result.Add("ДSvO2", dSvO2.ToString());
			result.Add("ДДО2", ddo2.ToString());
			result.Add("ДКПД", dkpd.ToString());
			result.Add("ДКПП", dkpp.ToString());
			result.Add("ДУК", duk.ToString());
			result.Add("ДБК", dbk.ToString());
			result.Add("ДЭДК", dedk.ToString());
			result.Add("ДКБЦ", dkbc.ToString());
			result.Add("ДУ", du.ToString());
			result.Add("ДК", dk.ToString());
			result.Add("ДКИТС", dkits.ToString());
			result.Add("ДОП", dop.ToString());
			result.Add("КИО", kio.ToString());
			result.Add("ООП", oop.ToString());
			result.Add("ДАДС", dads.ToString());
			result.Add("МДОО", mdoo.ToString());
			result.Add("ЖДОО", gdoo.ToString());
			result.Add("КЭСР", kesr.ToString());
			result.Add("КЭСН", kesn.ToString());
			result.Add("КТЭСР", ktesr.ToString());
			result.Add("КТЭСН", ktesn.ToString());
			result.Add("Q", q.ToString());
			result.Add("Cx", Cx.ToString());
			result.Add("ММЭСР", mmesr.ToString());
			result.Add("ММЭСН", mmesn.ToString());
			result.Add("КИБ", kib.ToString());
			result.Add("ад", ad.ToString());
			result.Add("Д", d.ToString());
			result.Add("Стабильность", st.ToString());
			result.Add("Нестабильность", nest.ToString());
			result.Add("Адекватность", adek.ToString());
			result.Add("Неадекватность", neadek.ToString());
			result.Add("ГДС", gds.ToString());
			result.Add("ГДЕС", gdes.ToString());
			result.Add("ГИПД", gipd.ToString());
			ss = bp00.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			result.Add(ss[0], ss[1].Trim());
			result.Add("ПТК", ptk.ToString());
			result.Add("ЭД", ed.ToString());
			result.Add("ТК", tk.ToString());
			result.Add("ДТК", dtk.ToString());
			ss = ed00.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			result.Add(ss[0], ss[1].Trim());
			result.Add("РОСМП", rosmp.ToString());
			result.Add("ДОСМП", dosmp.ToString());
			result.Add("ОСМП", osmp.ToString());
			result.Add("ПОСМП", posmp.ToString());
			result.Add("ДиастДЭС ЭСС", diastdesess.ToString());
			result.Add("дVO2", dvo2.ToString());
			result.Add("VO2", vo2.ToString());
			result.Add("пVO2", pvo2.ToString());
			result.Add("КТНЕД ЭСС", ktnedess.ToString());
			result.Add("ММНЕД ЭСА", mmnedesa.ToString());
			result.Add("пDO2", pdO2.ToString());
			result.Add("пОСМП", posmp2.ToString());
			result.Add("ГипоОсмДест ЭСС", gipoosmdestess.ToString());
			result.Add("ГиперОсмДест ЭСС", giperosmdestess.ToString());
			result.Add("КИО ЭСА", kioesa.ToString());
			result.Add("КОС", kos.ToString());
			result.Add("ГД", gd.ToString());
			result.Add("ГИПОД", gipod.ToString());
			return result;
		}
	}

	class ResultItem
	{
		public String Name { get; set; }
		public String Result { get; set; }

		public ResultItem(String name, String result)
		{
			this.Name = name;
			this.Result = result;
		}
	}
}
