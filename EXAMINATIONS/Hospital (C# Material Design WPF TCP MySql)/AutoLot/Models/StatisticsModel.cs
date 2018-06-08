using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
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
	}
}
