using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Dns_
{
	class Program
	{
		static void Main(string[] args)
		{
			IPAddress[] arr = Dns.GetHostAddresses("microsoft.com");
			foreach (IPAddress ip in arr)
				Console.WriteLine(ip);
		}
	}
}
