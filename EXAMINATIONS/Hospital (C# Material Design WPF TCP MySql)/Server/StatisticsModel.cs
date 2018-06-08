using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	[DataContract]
	class StatisticsModel
	{
		[DataMember(Name = "id")]
		public double Id { get; set; }
		[DataMember(Name = "pulse")]
		public double Pulse { get; set; }
		[DataMember(Name = "sap")]
		public double Sap { get; set; }
		[DataMember(Name = "dap")]
		public double Dap { get; set; }
		[DataMember(Name = "hb")]
		public double Hb { get; set; }
		[DataMember(Name = "sao")]
		public double Sao { get; set; }
		[DataMember(Name = "date")]
		public String Date { get; set; }
		public double UserId { get; set; }

		static public StatisticsModel GetStatistic(MySqlDataReader DR)
		{
			DR.Read();
			StatisticsModel SM = new StatisticsModel();
			SM.Id = DR.GetDouble(0);
			SM.Pulse = DR.GetDouble(1);
			SM.Sap = DR.GetDouble(2);
			SM.Dap = DR.GetDouble(3);
			SM.Hb = DR.GetDouble(4);
			SM.Sao = DR.GetDouble(5);
			SM.Date = DR.GetString(6);
			DR.Close();
			return SM;
		}
	}
}
