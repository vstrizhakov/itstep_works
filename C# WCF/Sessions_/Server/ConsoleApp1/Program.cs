using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(WordCollector));
			serviceHost.Open();
			Console.ReadKey(true);
			serviceHost.Close();
		}
	}

	[ServiceContract(SessionMode = SessionMode.Required)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class WordCollector
	{
		private List<String> words = new List<String>();

		[OperationContract]
		public void AddWord(String word)
		{
			this.words.Add(word);
		}

		[OperationContract]
		public String[] GetAllWords()
		{
			return this.words.ToArray();
		}
	}
}
