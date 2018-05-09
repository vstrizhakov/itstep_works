using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class FinishGame : Form
	{
		public FinishGame()
		{
			InitializeComponent();
			switch (GameController.SecondsLeft)
			{
				case 0:
					this.result.Text = "Время вышла, а никто не угадал слово.";
					break;
				case -2:
					this.result.Text = GameController.Chat[GameController.Chat.Count - 1];
					break;
				case -3:
					this.result.Text = "Игрок, который рисует, вышел из игры.";
					break;
			}
		}
	}
}
