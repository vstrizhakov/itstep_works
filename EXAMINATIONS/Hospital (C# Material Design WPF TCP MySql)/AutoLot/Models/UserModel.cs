using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Runtime.Serialization;

namespace Hospital.Models
{
	[DataContract]
	public class UserModel
	{
		[DataMember(Name = "id")]
		public double Id { get; set; }
		[DataMember(Name = "last_name")]
		public String Lastname { get; set; }
		[DataMember(Name = "first_name")]
		public String Firstname { get; set; }
		[DataMember(Name = "surname")]
		public String Surname { get; set; }
		[DataMember(Name = "username")]
		public String Username { get; set; }
		[DataMember(Name = "password")]
		public String Password { get; set; }
		[DataMember(Name = "sex")]
		public int Sex { get; set; }
		[DataMember(Name = "is_doctor")]
		public int IsDoctor { get; set; }
		[DataMember(Name = "phone_number")]
		public String Phone { get; set; }
		[DataMember(Name = "address")]
		public String Address { get; set; }
		[DataMember(Name = "age")]
		public int Age { get; set; }
		[DataMember(Name = "weight")]
		public double Weight { get; set; }
		[DataMember(Name = "height")]
		public double Height { get; set; }
		[DataMember(Name = "doctor_id")]
		public double DoctorId { get; set; }
	}
}
