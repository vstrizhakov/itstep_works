using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace FormTowns
{
	public partial class Form1 : Form
	{
		private String[] countries = new String[] { "Украина", "Россия", "Польша", "Германия" };
		private String[] Ukraine = new String[] { "Киев", "Харьков", "Одесса", "Днепр", "Донецк", "Запорожье", "Львов" };
		private String[] Germany = new String[] { "Берлин", "Мюнхен", "Гамбург", "Кёльн", "Дрезден", "Штутгарт", "Нюрнберг" };
		private String[] Russia = new String[] { "Москва", "Санкт-Петербург", "Казань", "Омск", "Сочи", "Ростов-на-Дону", "Новосибирск" };
		private String[] Poland = new String[] { "Варшава", "Познань", "Вроцлав", "Гдынь", "Краков", "Люблин", "Торунь" };
		public Form1()
		{
			InitializeComponent();
			foreach (String country in this.countries)
				this.comboBox1.Items.Add(country);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			String[] country = new String[0];
			if (this.countries[this.comboBox1.SelectedIndex] == "Украина")
				country = this.Ukraine;
			else if (this.countries[this.comboBox1.SelectedIndex] == "Германия")
				country = this.Germany;
			else if (this.countries[this.comboBox1.SelectedIndex] == "Польша")
				country = this.Poland;
			else if (this.countries[this.comboBox1.SelectedIndex] == "Россия")
				country = this.Russia;
			this.comboBox2.Items.Clear();
			foreach (String town in country)
				this.comboBox2.Items.Add(town);
			this.comboBox2.SelectedIndex = 0;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.label2.Text = String.Format("Страна: {0}\nГород: {1}", this.comboBox1.Text, this.comboBox2.Text);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}