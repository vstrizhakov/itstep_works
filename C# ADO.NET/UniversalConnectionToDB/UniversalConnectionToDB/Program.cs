using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace UniversalConnectionToDB
{
	class Program
	{
		static void Main(string[] args)
		{
			string dtPrv = ConfigurationManager.AppSettings["provider"];
			string cnStr = ConfigurationManager.AppSettings["connectionStr"];

			DbProviderFactory DF = DbProviderFactories.GetFactory(dtPrv);

			DbConnection cn = DF.CreateConnection();
			Console.WriteLine("Объект соединения: {0}", cn.GetType().FullName);
			cn.ConnectionString = cnStr;
			cn.Open();

			DbCommand cmd = cn.CreateCommand();
			Console.WriteLine("Объект комманды: {0}", cmd.GetType().FullName);
			cmd.Connection = cn;
			cmd.CommandText = "SELECT * FROM Authors";

			DbDataReader DR = cmd.ExecuteReader();

			while (DR.Read())
			{
				Console.WriteLine("{0}: \t {1} {2}", DR["id"], DR["FirstName"], DR["LastName"]);
			}
			DR.Close();
			cn.Close();
		}
	}
}
