using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using GameServer;
using System.Threading;

namespace Client
{
	class Program
	{
		static GameServer.Game client;
		static String login;
		static void Main(string[] args)
		{
			ChannelFactory<GameServer.Game> channelFactory = new ChannelFactory<GameServer.Game>("MyConfig");
			Program.client = channelFactory.CreateChannel();
			GameState GS;
			while (true)
			{
				try
				{
					Console.Write("Введите логин: ");
					login = Console.ReadLine();
					GS = client.Login(login);
					break;
				}
				catch (Exception)
				{
					Console.WriteLine("Сервер недоступен.");
				}
			}
			if (GS == null)
			{
				Console.WriteLine("Ошибка при подключении");
				return;
			}
			Thread T = new Thread(Program.GetGameStateMethod);
			T.IsBackground = true;
			T.Start();

			while (true)
			{
				String symbol = Console.ReadLine();
				if (symbol == "")
					// Выход из игры
					break;
				Program.client.MakeAction(login, symbol[0]);
			}

			Program.client.LogOff(Program.login);
		}

		static void GetGameStateMethod()
		{
			while (true)
			{
				GameState GS = Program.client.GetGameState(Program.login);
				Console.Clear();
				Console.WriteLine("Слово: {0}", GS.CurrentWord);

				switch (GS.State)
				{
					case 0:
						Console.WriteLine("Ожидание подключения второго игрока");
						break;
					case 1:
						if (GS.Users[0] == Program.login)
							Console.WriteLine("Ваш ход");
						else
							Console.WriteLine("Ходит {0}", GS.Users[0]);
						break;
					case 2:
						if (GS.Users[1] == Program.login)
							Console.WriteLine("Ваш ход");
						else
							Console.WriteLine("Ходит {0}", GS.Users[1]);
						break;
					case 3:
					case 4:
						if (GS.Winner == login)
							Console.WriteLine("Вы выиграли");
						else
							Console.WriteLine("Выиграл {0}", GS.Winner);
						Console.WriteLine("Конец игры");
						break;
				}
				Thread.Sleep(2000);
			}
		}
	}
}

namespace GameServer
{

	[DataContract]
	class GameState
	{
		[DataMember]
		public int State { get; set; }
		/*
		 0 - ожидание подключения второго игрока
		 1 - ход первого игрока
		 2 - ход второго игрока
		 3 - конец игры, определение победителя
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
	interface Game
	{
		[OperationContract]
		GameState Login(String username);

		[OperationContract]
		GameState GetGameState(String username);

		[OperationContract]
		void MakeAction(String username, char symbol);

		[OperationContract]
		void LogOff(String login);

	}
}
