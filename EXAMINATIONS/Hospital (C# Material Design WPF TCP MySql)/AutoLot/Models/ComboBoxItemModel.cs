using System;
using System.Runtime.Serialization;

namespace Hospital.Models
{
	[DataContract]
	class ComboBoxItemModel
	{
		[DataMember(Name = "date")]
		public String Date { set; get; }
		[DataMember(Name = "id")]
		public double Id { get; set; }

		private RelayCommand goToPatient;

		public RelayCommand GoToPatient
		{
			set
			{
				this.goToPatient = value;
			}
			get
			{
				return this.goToPatient;
			}
		}

		public ComboBoxItemModel(String name, double id)
		{
			this.Date = name;
			this.Id = id;
		}
	}
}
