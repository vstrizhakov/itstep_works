using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MySql.Data.MySqlClient;

namespace Server
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

		public UserModel(MySqlDataReader DR, bool affectDR = true)
		{
			if (affectDR)
				DR.Read();
			this.Id = DR.GetDouble(0);
			this.Sex = DR.GetInt32(1);
			this.IsDoctor = DR.GetInt32(2);
			this.Firstname = DR.GetString(3);
			this.Surname = DR.GetString(4);
			this.Lastname = DR.GetString(5);
			this.Username = DR.GetString(6);
			this.Password = DR.GetString(7);
			this.Phone = DR.GetString(8);
			this.Address = DR.GetString(9);
			this.Age = DR.GetInt32(10);
			this.Weight = DR.GetDouble(11);
			this.Height = DR.GetDouble(12);
			this.DoctorId = (DR.IsDBNull(13)) ? -1 : DR.GetDouble(13);
			if (affectDR)
				DR.Close();
		}

		static public UserModel[] GetUsers(MySqlDataReader DR)
		{
			List<UserModel> tmp = new List<UserModel>();
			while (DR.Read())
				tmp.Add(new UserModel(DR, false));
			DR.Close();
			UserModel[] UMs = tmp.ToArray();
			return UMs;
		}
	}
}
