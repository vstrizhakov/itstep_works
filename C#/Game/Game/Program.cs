using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
	class Program
	{
		class Game
		{
			private GameField GF;

			public Game()
			{
				this.GF = new GameField(25, 3);
			}

			public void Run()
			{
				bool isRun = true;
				Random R = new Random();
				String answer;
				while (isRun)
				{
					Console.WriteLine("1 - Новая игра");
					Console.WriteLine("2 - Выход");

					answer = Console.ReadLine();

					switch (answer)
					{
						case "1":
							{
								Console.Clear();
								this.GF.Start();
								this.GF.AddBox(R.Next(5, 15) * 1000);
								this.GF.AddBox(R.Next(5, 15) * 1000);
								this.GF.AddBox(R.Next(5, 15) * 1000);
								while (true)
								{
									Console.Clear();

									Console.WriteLine(this.GF);
									Thread.Sleep(100);
									Box[] boxes = this.GF.GetBoxes();
									foreach (Box b in boxes)
									{
										b.time -= 100;
										if (b.time <= 0)
										{
											this.GF.RemoveBox(b);
											this.GF.AddBox(R.Next(5, 15) * 1000);
										}
									}

									if (Console.KeyAvailable)
									{
										ConsoleKeyInfo CKI = Console.ReadKey(true);
										if (CKI.Key == ConsoleKey.Escape)
										{
											Console.Clear();
											break;
										}

										switch (CKI.Key)
										{
											case ConsoleKey.RightArrow:
												this.GF.MoveGamer(1, 0);
												break;
											case ConsoleKey.LeftArrow:
												this.GF.MoveGamer(-1, 0);
												break;
											case ConsoleKey.UpArrow:
												this.GF.MoveGamer(0, -1);
												break;
											case ConsoleKey.DownArrow:
												this.GF.MoveGamer(0, 1);
												break;
											default:
												break;
										}
									}
								}
								break;
							}
						default:
							isRun = false;
							break;
					}
				}
			}
		}
		class GameField
		{
			static private readonly int width = 15;
			private int[,] field = new int[width, width];
			private List<Box> boxes = new List<Box>();
			private int x;
			private int y;
			public Gamer G = new Gamer();

			public GameField(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			public void MoveGamer(int dX, int dY)
			{
				int newRow = this.G.row + dY;
				int newCol = this.G.col + dX;
				if (newRow < 0 || newCol < 0 || newRow >= width || 
					newCol >= width || this.field[newRow, newCol] == 1)
					return;
				this.field[this.G.row, this.G.col] = 0;
				this.field[newRow, newCol] = 3;
				this.G.col = newCol;
				this.G.row = newRow;
			}

			public override string ToString()
			{
				String tmp = "┌";
				// Top
				for (int i = 0; i < width; i++)
					tmp += "──";
				tmp += "┐\n";
				// Center
				for (int i = 0; i < width; i++)
				{
					tmp += "│";
					for (int j = 0; j < width; j++)
					{
						if (this.field[i, j] == 0)
							tmp += "  ";
						else if (this.field[i, j] == 2)
							tmp += "[]";
						else if (this.field[i,j] == 3)
							tmp += "/\\";
						else
							tmp += "░░";
					}
					tmp += "│\n";
				}
				// Bottom
				tmp += "└";
				for (int i = 0; i < width; i++)
					tmp += "──";
				tmp += "┘\n";

				return tmp;
			}

			public void Start()
			{
				this.Init();

				int row, col;
				Random R = new Random();
				do
				{
					row = R.Next(0, width);
					col = R.Next(0, width);					
				} while (this.field[row, col] != 0);
				this.field[row, col] = 3;
				this.G.row = row;
				this.G.col = col;
			}

			public void AddBox(int time)
			{
				int row, col;
				Random R = new Random();

				do
				{
					row = R.Next(0, width);
					col = R.Next(0, width);
				} while (this.field[row, col] != 0);
				this.field[row, col] = 2;
				this.boxes.Add(new Box(row, col, time));
			}

			public Box[] GetBoxes()
			{
				return this.boxes.ToArray();
			}

			public void RemoveBox(Box b)
			{
				this.boxes.Remove(b);
				this.field[b.row, b.col] = 0;
			}

			private void Init()
			{
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < width; j++)
					{
						this.field[i, j] = 0;
					}
				}

				Random R = new Random();
				int cnt = R.Next(width / 2 * 3, width / 2 * 5);
				for (int i = 0; i < cnt; i++)
				{
					do
					{
						int row = R.Next(0, width);
						int col = R.Next(0, width);
						if (this.field[row, col] == 0)
						{
							this.field[row, col] = 1;
							break;
						}
					} while (true);
				}
			}
		}
		class Box
		{
			public int row { get; }
			public int col { get; }

			public int time;

			public Box(int row, int col, int time)
			{
				this.row = row;
				this.col = col;
				this.time = time;
			}
		}
		class Gamer
		{
			public int row { get; set; }
			public int col { get; set; }
		}

		static void Main(string[] args)
		{
			Game G = new Game();
			G.Run();
		}
	}
}
