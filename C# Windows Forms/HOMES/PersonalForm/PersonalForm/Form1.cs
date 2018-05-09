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
using System.IO;

namespace PersonalForm
{
	public partial class Form1 : Form
	{
		private String[] days = new String[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
		private FileStream FS = new FileStream("info.dat", FileMode.OpenOrCreate);
		private Info I = new Info();
		public Form1()
		{
			InitializeComponent();

			this.FormClosing += Form1_FormClosing;

			for (int i = 0; i < 30; i++)
				this.day.Items.Add(i + 1);
			for (int i = 0; i < 12; i++)
				this.month.Items.Add(this.days[i]);
			for (int i = 1940; i < 2018; i++)
				this.year.Items.Add(i);
			if (File.Exists("info.dat"))
			{
				BinaryFormatter BF = new BinaryFormatter();
				this.I = (Info)BF.Deserialize(this.FS);
				FS.Position = 0;
			}
			this.day.SelectedIndex = this.I.Birthday[0];
			this.month.SelectedIndex = this.I.Birthday[1];
			this.year.SelectedIndex = this.I.Birthday[2];
			this.lastName.Text = this.I.LastName;
			this.firstName.Text = this.I.FirstName;
			if (this.I.Sex == 0)
				this.male.Checked = true;
			else
				this.female.Checked = true;
			this.cs.Checked = this.I.Interests[0];
			this.cpp.Checked = this.I.Interests[1];
			this.php.Checked = this.I.Interests[2];
			this.java.Checked = this.I.Interests[3];


			this.month_SelectedIndexChanged(this, null);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			BinaryFormatter BF = new BinaryFormatter();
			BF.Serialize(this.FS, this.I);
			FS.Close();
		}

		private void month_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.I.Birthday[1] = this.month.SelectedIndex;
			if (this.month.SelectedIndex == 1)
			{
				int fdays = ((int)(this.year.Items[this.year.SelectedIndex]) % 4 == 0) ? 29 : 28;
				if (this.day.Items.Count > fdays)
					for (int i = this.day.Items.Count; i > fdays; i--)
						this.day.Items.RemoveAt(i - 1);
				if (this.day.Items.Count < fdays)
					for (int i = this.day.Items.Count; i < fdays; i++)
						this.day.Items.Add(i + 1);
			}
			else if (this.month.SelectedIndex % 2 == 0)
			{
				if (this.day.Items.Count < 31)
					for (int i = this.day.Items.Count; i < 31; i++)
						this.day.Items.Add(i + 1);
			}
			else
			{
				if (this.day.Items.Count > 30)
					for (int i = this.day.Items.Count; i > 30; i--)
						this.day.Items.RemoveAt(i - 1);
			}
		}

		private void year_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.I.Birthday[2] = this.year.SelectedIndex;
			this.month_SelectedIndexChanged(sender, e);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void lastName_TextChanged(object sender, EventArgs e)
		{
			this.I.LastName = this.lastName.Text;
		}

		private void firstName_TextChanged(object sender, EventArgs e)
		{
			this.I.FirstName = this.firstName.Text;
		}

		private void day_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.I.Birthday[0] = this.day.SelectedIndex;
		}

		private void InterestChanged(object sender, EventArgs e)
		{
			if (sender is CheckBox)
			{
				CheckBox tmp = (CheckBox)sender;
				this.I.Interests[Int32.Parse((String)tmp.Tag)] = tmp.Checked;
			}
		}

		private void SexChanged(object sender, EventArgs e)
		{
			if (sender is RadioButton)
			{
				RadioButton tmp = (RadioButton)sender;
				this.I.Sex = Int32.Parse((String)tmp.Tag); 
			}
		}
	}

	[Serializable]
	class Info
	{
		public String LastName;
		public String FirstName;
		public int[] Birthday;
		public bool[] Interests;
		public int Sex;

		public Info()
		{
			this.LastName = "";
			this.FirstName = "";
			this.Birthday = new int[3] { 0, 0, 0 };
			this.Interests = new bool[4] { false, false, false, false };
		}
	}
}
