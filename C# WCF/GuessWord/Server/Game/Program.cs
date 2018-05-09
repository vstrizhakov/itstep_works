using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading;

namespace GameServer
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(Game));
			serviceHost.Open();
			Console.ReadKey(true);
			serviceHost.Close();
		}
	}

	[DataContract]
	class GameState
	{
		[DataMember]
		public int State { get; set; }
		/*
		 0 - ожидание подключения второго игрока
		 1 - ход первого игрока
		 2 - ход второго игрока
		 3 - победил игрок 1
		 4 - победил игрок 2
		 4 - оба игрока покинули игру
			 */
		[DataMember]
		// Слово с отгаданными буквами
		public String CurrentWord { get; set; }
		[DataMember]
		// Загаданное слово
		public String Word { get; set; }
		[DataMember]
		// Список игроков, участвующих в игре
		public List<String> Users { get; set; } = new List<String>();
		// Имя победителя
		[DataMember]
		public String Winner { get; set; }
	}

	[ServiceContract]
	class Game
	{
		private static GameState GameState = null;
		private static Random R = new Random();
		private static String[] Words = new String[] { "summer", "winter", "dog", "sergey" };

		[OperationContract]
		// Подключение игрока к серверу
		public GameState Login(String username)
		{
			if (Game.GameState == null || Game.GameState.State == 5)
			{
				Console.WriteLine("Создание новой игры");
				// Создаем игру заново
				Game.GameState = new GameState();
				Game.GameState.Users.Add(username);
				int rand = Game.R.Next(0, Game.Words.Length);
				Game.GameState.CurrentWord = "";
				for (int i = 0; i < Game.Words[rand].Length; i++)
					Game.GameState.CurrentWord += "*";
				Game.GameState.Word = Game.Words[rand];
				return Game.GameState;
			}
			if (Game.GameState.State == 0)
			{
				Game.GameState.Users.Add(username);
				Game.GameState.State = 1;
				return Game.GameState;
			}
			return null;
		}

		[OperationContract]
		// Получение состояния игры
		public GameState GetGameState(String username)
		{
			if (Game.GameState != null && (username == Game.GameState.Users[0] || username == Game.GameState.Users[1]))
				return Game.GameState;
			return null;
		}

		[OperationContract]
		public void MakeAction(String username, char symbol)
		{
			// Игра не создана
			if (Game.GameState == null)
				return;
			if ((Game.GameState.State == 1 && Game.GameState.Users[0] == username)
				|| (Game.GameState.State == 2 && Game.GameState.Users[1] == username))
			{
				// Осуществляется ход
				if (Game.GameState.Word.ToLower().Contains(symbol.ToString().ToLower()))
				{
					// Игрок угадал букву - откроем ее

					char[] ss = new char[Game.GameState.CurrentWord.Length];
					for (int i = 0; i < Game.GameState.CurrentWord.Length; i++)
					{
						if (Game.GameState.Word.ToLower()[i] == symbol)
							ss[i] = symbol;
						else
							ss[i] = Game.GameState.CurrentWord[i];
					}
					Game.GameState.CurrentWord = new String(ss);

					if (Game.GameState.CurrentWord.ToLower() == Game.GameState.Word.ToLower())
					{
						// Конец игры, объявление победителя
						Game.GameState.State += (Game.GameState.State == 1) ? 3 : 4;
						Game.GameState.Winner = username;
					}
				}
				else
				{
					// Игрок не угадал букву
					Game.GameState.State = (Game.GameState.State == 1) ? 2 : 1;
				}
			}
		}

		[OperationContract]
		public void LogOff(String login)
		{
			if (Game.GameState == null)
				return;
			if (Game.GameState.Users.Contains(login) == false)
				return;

			switch (Game.GameState.State)
			{
				case 0: // Ожидание второго игрока
					GameState = null;
					Console.WriteLine("0");
					break;
				case 1: // Ход первого игрока
					Console.WriteLine("1");
					if (login == Game.GameState.Users[0])
						Game.GameState.State = 3;
					else
						Game.GameState.State = 4;
					goto case 3;
				case 2: // Ход второго игрока
					Console.WriteLine("2");
					if (login == Game.GameState.Users[0])
						Game.GameState.State = 3;
					else
						Game.GameState.State = 4;
					goto case 3;
				case 3: // Первый игрок победил
					Console.WriteLine("3");
					Game.GameState.Users.Remove(login);
					if (Game.GameState.Users.Count == 0)
						Game.GameState.State = 5;
					break;
				case 4: // Второй игрок победил
					Console.WriteLine("4");
					Game.GameState.Users.Remove(login);
					if (Game.GameState.Users.Count == 0)
						Game.GameState.State = 5;
					break;
			}
		}
	}
}
