using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Server
{
	[DataContract]
	class ComboBoxItemModel
	{
		[DataMember(Name = "date")]
		public String Date { set; get; }
		[DataMember(Name = "id")]
		public double Id { get; set; }

		static public ComboBoxItemModel[] GetDates(MySqlDataReader DR)
		{
			List<ComboBoxItemModel> tmp = new List<ComboBoxItemModel>();
			while (DR.Read())
			{
				ComboBoxItemModel CBIM = new ComboBoxItemModel();
				CBIM.Date = DR.GetString(0);
				CBIM.Id = DR.GetDouble(1);
				tmp.Add(CBIM);
			}
			DR.Close();
			ComboBoxItemModel[] CBIMs = tmp.ToArray();
			return CBIMs;
		}
	}
}
