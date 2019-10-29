using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			error.Text = "";
			result.Text = "";
		}

		protected void difBtn_Click(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				if (CheckInput(out double firstNumber, out double secondNumber))
				{
					result.Text = (firstNumber - secondNumber).ToString();
				}
			}
		}

		protected void divideBtn_Click(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				if (CheckInput(out double firstNumber, out double secondNumber))
				{
					if (secondNumber == 0)
					{
						error.Text = "На ноль делить нельзя!";
						return;
					}
					result.Text = (firstNumber / secondNumber).ToString();
				}
			}
		}

		protected void plusBtn_Click(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				if (CheckInput(out double firstNumber, out double secondNumber))
				{
					result.Text = (firstNumber + secondNumber).ToString();
				}
			}
		}

		protected void multipleBtn_Click(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				if (CheckInput(out double firstNumber, out double secondNumber))
				{
					result.Text = (firstNumber * secondNumber).ToString();
				}
			}
		}

		private bool CheckInput(out double firstNumber, out double secondNumber)
		{
			bool result = true;
			result &= Double.TryParse(firstNum.Text, out firstNumber);
			result &= Double.TryParse(secondBtn.Text, out secondNumber);
			error.Text = (result) ? "" : "Пожалуйста, введите правильные числа";
			return result;
		}
	}
}