using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private double[] numbers = new double[2];
		private int steps = 0;
		private String prevAction;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Calculate()
		{

		}

		private void Expression_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				this.Calculate();
				e.Handled = true;
			}
			else if (e.Key == Key.OemComma || e.Key == Key.OemPeriod)
			{
				if (!this.Expression.Text.Contains(","))
				{
					if (this.Expression.Text.Length != 0)
						this.Expression.Text += ",";
					else
						this.Expression.Text = "0,";
				}
				this.Expression.SelectionStart = this.Expression.Text.Length;
				e.Handled = true;
			}
			else if (e.Key != Key.D1 && e.Key != Key.D2 && e.Key != Key.D3 && e.Key != Key.D4 && e.Key != Key.D5 && e.Key != Key.D6 && e.Key != Key.D7 && e.Key != Key.D8 && e.Key != Key.D9 && e.Key != Key.D0 && e.Key != Key.OemMinus && e.Key != Key.OemPlus)
				e.Handled = true;
			else
				return;
		}

		private void BtnClick(object sender, EventArgs e)
		{
			String symbol = ((Button)sender).Content.ToString();
			if (symbol != "+" && symbol != "-" && symbol != "/" && symbol != "*" && symbol != "=")
			{
				if (this.steps % 2 != 0)
				{
					this.Expression.Clear();
					this.steps--;
				}
				this.Expression.Text += symbol;
			}
			else
			{
				this.numbers[this.steps % 2] = double.Parse(this.Expression.Text);
				double result = 0;
				switch (this.prevAction)
				{
					case "+":
						{
							result = this.numbers[0] + this.numbers[1];
						}
						break;
					case "-":
						{
							result = this.numbers[0] - this.numbers[1];
						}
						break;
					case "*":
						{
							result = this.numbers[0] * this.numbers[1];
						}
						break;
					case "/":
						{
							result = this.numbers[0] / this.numbers[1];
						}
						break;
					default:
						break;
				}
				this.prevAction = symbol;
				if (this.steps++ % 2 != 0)
				{
					this.Expression.Text = result.ToString();
					this.numbers[0] = result;
					this.steps--;
				}
			}
		}

		private void Delete(object sender, EventArgs e)
		{
			if (this.Expression.Text.Length > 0)
				this.Expression.Text = this.Expression.Text.Remove(this.Expression.Text.Length, 1);
		}
	}
}
