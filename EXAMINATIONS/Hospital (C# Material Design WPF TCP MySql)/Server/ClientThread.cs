using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;
using MySql.Data.MySqlClient;

namespace Server
{
	class ClientThread
	{
		private TcpClient Client;
		static public MySqlConnection Connection;
		static public String Salt;
		private UserModel User;

		public ClientThread(TcpClient client)
		{
			this.Client = client;
		}

		public void Run()
		{
			String clientIp = this.Client.Client.RemoteEndPoint.ToString();
			NetworkStream NS = null;
			MemoryStream MS = new MemoryStream();
			try
			{
				NS = this.Client.GetStream();
				byte[] buf = new byte[2048];
				while (true)
				{
					do
					{
						int cnt = NS.Read(buf, 0, buf.Length);
						if (cnt == 0)
							throw new Exception("0 bytes received");
						MS.Write(buf, 0, cnt);
					} while (NS.DataAvailable);

					String input = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Position);
					MS.SetLength(0);

					String[] ss = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

					if (ss.Length > 2)
						break;

					String cmd = ss[0].Trim().ToLower();
					String parameters = "";
					if (ss.Length > 1)
						parameters = ss[1].Trim();

					String answer = "OK|";
					ServerThread.Log(input);
					switch (cmd)
					{
						case "login":
							{
								ServerThread.Log("{0} is trying to log in", clientIp);

								ss = parameters.Split(new char[] { '&' }, StringSplitOptions.None);
								String login = ss[0].Trim();
								String password = String.Empty;
								if (ss.Length > 1)
									password = ss[1].Trim();
								if (login == String.Empty || password == String.Empty)
								{
									ServerThread.Log("{0} didn`t fill all fields", clientIp);
									answer = "ERROR|Пожалуйста, заполните все поля";
									break;
								}

								String result = ClientThread.Login(login, password);
								if (result != String.Empty)
								{
									this.User = (UserModel)ClientThread.Deserialize(result, typeof(UserModel));
									ServerThread.Log("{0} successfully logged in", clientIp);
									answer += result;
								}
								else
								{
									ServerThread.Log("{0} entered wrong username or password", clientIp);
									answer = "ERROR|Неверный логин или пароль";
								}
								break;
							}
						case "register":
							{
								ServerThread.Log("{0} is trying to sign up", clientIp);
								String result;

								try
								{
									result = ClientThread.Register(parameters);
									if (this.User == null)
										this.User = (UserModel)ClientThread.Deserialize(result, typeof(UserModel));
									answer += result;
								}
								catch (Exception e)
								{
									ServerThread.Log("{0} {1}", clientIp, e.Message);
									answer = "ERROR|" + e.Message;
								}
								break;
							}
						case "getdoctors":
							{
								try
								{
									answer += ClientThread.GetDoctors();
								}
								catch (Exception e)
								{
									ServerThread.Log(e.Message);
								}
								break;
							}
						case "getdates":
							{
								String result = ClientThread.GetDates(parameters);
								if (result == String.Empty)
								{
									answer = "ERROR|Замеров данного пользователя не найдено";
								}
								else if (result == "empty")
									answer = "EMPTY|";
								else
									answer += result;
								break;
							}
						case "getstatistic":
							{
								String result = ClientThread.GetStatistic(parameters);
								if (result == String.Empty)
									answer = "ERROR|Результатов за выбранную дату не найдено";
								else
									answer += result;
								break;
							}
						case "addresult":
							{
								ss = parameters.Split(new char[] { '&' }, StringSplitOptions.None);
								String pulse = ss[0].Trim();
								String sap = ss[1].Trim();
								String dap = ss[2].Trim();
								String hb = ss[3].Trim();
								String sao = ss[4].Trim();
								String userId = String.Empty;
								if (ss.Length > 5)
									userId = ss[5].Trim();

								if (pulse == String.Empty || sap == String.Empty || dap == String.Empty || hb == String.Empty || sao == String.Empty)
								{
									answer = "ERROR|Пожалуйста, заполните все поля";
									break;
								}

								DateTime DT = DateTime.Now;
								String date = String.Format("{0}.{1}.{2} {3}:{4}:{5}.{6}", DT.Day, DT.Month, DT.Year, DT.Hour, DT.Minute, DT.Second, DT.Millisecond);

								StatisticsModel SM = null;
								try
								{
									SM = new StatisticsModel()
									{
										Id = -1,
										Pulse = Double.Parse(pulse),
										Sap = Double.Parse(sap),
										Dap = Double.Parse(dap),
										Hb = Double.Parse(hb),
										Sao = Double.Parse(sao),
										Date = date,
										UserId = Double.Parse(userId)
									};
								}
								catch
								{
									answer = "ERROR|Данные введены в неверном формате";
									break;
								}

								ClientThread.AddResult(SM);
								break;
							}
						case "getpatients":
							{
								String result = ClientThread.GetPatients(parameters);
								if (result == String.Empty)
								{
									answer = "ERROR|Не найдено записей, связанных с данным врачем";
								}
								else if (result == "empty")
									answer = "EMPTY|";
								else
									answer += result;
								break;
							}
						case "getpatient":
							{
								String result = ClientThread.GetPatient(parameters, this.User);
								if (result == String.Empty)
								{
									answer = "ERROR|Данный пациент не найден среди ваших пациентов";
								}
								else
									answer += result;
								break;
							}
						case "removeresult":
							{
								try
								{
									ClientThread.RemoveResult(parameters, this.User);
								}
								catch (Exception e)
								{
									answer = "ERROR|" + e.Message;
								}
								break;
							}
						default:
							answer = "ERROR|Неизвестная команда";
							break;
					}
					byte[] output = Encoding.UTF8.GetBytes(answer);
					Console.WriteLine(answer + " - length = " + output.Length);
					NS.Write(output, 0, output.Length);
				}
			}
			catch
			{
				ServerThread.Log("{0} disconnected", clientIp);
			}
			finally
			{
				MS.Close();
				NS?.Close();
				this.Client.Close();
			}
		}

		static public String EncryptBySHA256(String entryStr)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(entryStr + ClientThread.Salt);
			SHA256Managed hashString = new SHA256Managed();
			byte[] hash = hashString.ComputeHash(bytes);
			entryStr = String.Empty;
			foreach (byte b in hash)
				entryStr += b.ToString("X2");
			return entryStr;
		}

		static private MySqlCommand CreateCommand(String cmdText, params String[] prms)
		{
			MySqlCommand cmd = ClientThread.Connection.CreateCommand();
			cmd.CommandText = String.Format(cmdText, prms);
			return cmd;
		}

		static private String Serialize(object obj)
		{

			DataContractJsonSerializer JS = new DataContractJsonSerializer(obj.GetType());
			MemoryStream MS = new MemoryStream();
			JS.WriteObject(MS, obj);
			MS.Position = 0;
			StreamReader SR = new StreamReader(MS);
			String result = SR.ReadToEnd();
			SR.Close();
			MS.Close();
			return result;
		}

		static public object Deserialize(String str, Type type)
		{
			DataContractJsonSerializer JS = new DataContractJsonSerializer(type);
			MemoryStream MS = new MemoryStream();
			StreamWriter SW = new StreamWriter(MS);
			SW.Write(str);
			SW.Flush();
			MS.Position = 0;
			object result = JS.ReadObject(MS);
			MS.Close();
			return result;
		}

		static private String Login(String login, String password)
		{
			password = ClientThread.EncryptBySHA256(password);
			MySqlCommand cmd = ClientThread.CreateCommand("SELECT * FROM users WHERE username = '{0}' AND password = '{1}'", login, password);
			MySqlDataReader DR = cmd.ExecuteReader();
			if (DR.HasRows)
			{
				UserModel UM = new UserModel(DR);
				return ClientThread.Serialize(UM);
			}
			else
			{
				DR.Close();
				return String.Empty;
			}
		}

		static private String Register(String parameters)
		{
			String[] ss = parameters.Split(new char[] { '&' }, StringSplitOptions.None);
			if (ss.Length != 13)
				throw new Exception("Пожалуйста, заполните все поля");
			String Lastname = ss[0];
			String Firstname = ss[1];
			String Surname = ss[2];
			String sex = ss[3];
			String Address = ss[4];
			String Phone = ss[5];
			String doctor_id = ss[6];
			String Age = ss[7];
			String Height = ss[8];
			String Weight = ss[9];
			String Username = ss[10];
			String password = ss[11];
			password = ClientThread.EncryptBySHA256(password);
			int IsDoctor;

			try
			{
				IsDoctor = Int32.Parse(ss[12]);
			}
			catch
			{
				throw new Exception("Неверный формат данных");
			}

			int iSex;
			double iDoctor_id = -1;
			int iAge;
			double iHeight;
			double iWeight;

			if (IsDoctor == 0)
			{
				try
				{
					iSex = Int32.Parse(sex);
					iDoctor_id = Double.Parse(doctor_id);
					iAge = Int32.Parse(Age);
					iHeight = Double.Parse(Height);
					iWeight = Double.Parse(Weight);
					iDoctor_id = Double.Parse(doctor_id);
				}
				catch
				{
					throw new Exception("Неверный формат данных");
				}
			}
			else if (IsDoctor == 1)
			{
				iSex = 0;
				iAge = 0;
				iHeight = 0;
				iWeight = 0;
			}
			else
				throw new Exception("Неверные данные");

			MySqlCommand cmd = ClientThread.CreateCommand("INSERT INTO users (last_name, first_name, surname, sex, address, phone_number, doctor_id, age, weight, height, username, password, is_doctor) " +
				"VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
				Lastname, Firstname, Surname, iSex.ToString(), Address, Phone, (iDoctor_id == -1) ? "null" : iDoctor_id.ToString(), iAge.ToString(), iWeight.ToString(), iHeight.ToString(), Username, password, IsDoctor.ToString());
			try
			{
				cmd.ExecuteNonQuery();
				cmd = ClientThread.CreateCommand("SELECT * FROM users WHERE username = '{0}'", Username);
				MySqlDataReader DR = cmd.ExecuteReader();
				UserModel UM = new UserModel(DR);
				return ClientThread.Serialize(UM);
			}
			catch
			{
				throw new Exception("Пациент с таким логином уже существует");
			}
		}

		static private String GetDoctors()
		{
			MySqlCommand cmd = ClientThread.CreateCommand("SELECT * FROM users WHERE is_doctor = 1 ORDER BY last_name ASC");
			MySqlDataReader DR = cmd.ExecuteReader();
			if (DR.HasRows)
			{
				UserModel[] UMs = UserModel.GetUsers(DR);
				return ClientThread.Serialize(UMs);
			}
			else
				return String.Empty;
		}

		static private String GetDates(String str)
		{
			int id = -1;
			try
			{
				id = Int32.Parse(str);
			}
			catch
			{
				return String.Empty;
			}

			MySqlCommand cmd = ClientThread.CreateCommand("SELECT date, id FROM statistics WHERE user_id = {0} ORDER BY id DESC", id.ToString());
			MySqlDataReader DR = cmd.ExecuteReader();
			if (DR.HasRows)
			{
				ComboBoxItemModel[] UMs = ComboBoxItemModel.GetDates(DR);
				return ClientThread.Serialize(UMs);
			}
			else
			{
				DR.Close();
				return "empty";
			}
		}

		static public String GetStatistic(String str)
		{
			int id = -1;
			try
			{
				id = Int32.Parse(str);
			}
			catch
			{
				return String.Empty;
			}

			MySqlCommand cmd = ClientThread.CreateCommand("SELECT id, pulse, sap, dap, hb, sao, date FROM statistics WHERE id = {0}", id.ToString());
			MySqlDataReader DR = cmd.ExecuteReader();
			StatisticsModel UMs = StatisticsModel.GetStatistic(DR);
			return ClientThread.Serialize(UMs);
		}

		static public void AddResult(StatisticsModel SM)
		{
			MySqlCommand cmd = ClientThread.CreateCommand("INSERT INTO statistics (pulse, sap, dap, hb, sao, date, user_id) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", SM.Pulse.ToString(), SM.Sap.ToString(), SM.Dap.ToString(), SM.Hb.ToString(), SM.Sao.ToString(), SM.Date, SM.UserId.ToString());
			cmd.ExecuteNonQuery();
			//return ClientThread.GetDates(SM.Id.ToString());
		}

		static private String GetPatients(String str)
		{
			int id = -1;
			try
			{
				id = Int32.Parse(str);
			}
			catch
			{
				return String.Empty;
			}

			MySqlCommand cmd = ClientThread.CreateCommand("SELECT CONCAT(last_name, ' ', first_name, ' ', surname), id FROM users WHERE doctor_id = {0} ORDER BY last_name ASC", id.ToString());
			MySqlDataReader DR = cmd.ExecuteReader();
			if (DR.HasRows)
			{
				ComboBoxItemModel[] UMs = ComboBoxItemModel.GetDates(DR);
				return ClientThread.Serialize(UMs);
			}
			else
			{
				DR.Close();
				return "empty";
			}
		}

		static private String GetPatient(String str, UserModel User)
		{
			int id = -1;
			try
			{
				id = Int32.Parse(str);
			}
			catch
			{
				return String.Empty;
			}

			MySqlCommand cmd = ClientThread.CreateCommand("SELECT * FROM users WHERE doctor_id = {0} AND id = {1}", User.Id.ToString(), id.ToString());
			MySqlDataReader DR = cmd.ExecuteReader();
			if (DR.HasRows)
			{
				UserModel UM = new UserModel(DR);
				return ClientThread.Serialize(UM);
			}
			DR.Close();
			return String.Empty;
		}

		static private void RemoveResult(String str, UserModel User)
		{
			MySqlCommand cmd = ClientThread.CreateCommand("DELETE FROM statistics WHERE user_id = {0} AND id = {1}", User.Id.ToString(), str);
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch
			{
				throw new Exception("Неизвестная ошибка при удалении замера");
			}
		}
	}
}
