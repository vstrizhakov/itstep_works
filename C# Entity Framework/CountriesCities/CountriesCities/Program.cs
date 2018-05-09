using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesCities
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var ctx = new sp2822Entities1())
			{
				var countries = from T in ctx.Countries_09358_09701_09625 select T;
				foreach (Countries_09358_09701_09625 C in countries)
					Console.WriteLine("Id: {0}, Name: {1}", C.id, C.name);
				Console.WriteLine("==========================================");

				countries = from T in ctx.Countries_09358_09701_09625 select T;
				foreach (Countries_09358_09701_09625 C in countries)
				{
					Console.Write("{0} : {1} - ", C.id, C.name);
					foreach (Cities_09358_09701_09625 c in C.Cities_09358_09701_09625)
						Console.Write(c.name + ", ");
					Console.WriteLine();
				}

				Console.WriteLine("==========================================");
				var cities = from T in ctx.Cities_09358_09701_09625 select T;
				foreach (Cities_09358_09701_09625 C in cities)
					Console.WriteLine("{0} : {1} : {2}", C.id, C.name, C.Countries_09358_09701_09625.name);

				Console.WriteLine("==========================================");
				var C1 = from T in ctx.Countries_09358_09701_09625 where (T.name == "Украина") select T;
				List<Countries_09358_09701_09625> L = C1.ToList();
				if (L.Count > 0)
				{
					Cities_09358_09701_09625 c1 = new Cities_09358_09701_09625()
					{
						name = "Днепр",
						id_country = L[0].id
					};
					ctx.Cities_09358_09701_09625.Add(c1);
					ctx.SaveChanges();
				}
				else
				{
					Console.WriteLine("Страна не найдена");
				}
			}
		}
	}
}
