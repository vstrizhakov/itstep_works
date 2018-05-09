using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Server;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ChannelFactory<WordCollector> channelFactory = new ChannelFactory<WordCollector>("MyConfig");
			WordCollector client = channelFactory.CreateChannel();
			while (true)
			{
				String word = Console.ReadLine();
				if (word == "")
					break;
				client.AddWord(word);
				String[] AllWords = client.GetAllWords();
				foreach (String str in AllWords)
					Console.WriteLine(str);
			}
		}
	}
}

namespace Server
{
	[ServiceContract]
	interface WordCollector
	{
		[OperationContract]
		void AddWord(String word);

		[OperationContract]
		String[] GetAllWords();
	}
}