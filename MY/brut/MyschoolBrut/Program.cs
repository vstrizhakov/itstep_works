using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace MyschoolBrut
{
	class Program
	{
		static void Main(string[] args)
		{
			FileStream FS = new FileStream("teachers.txt", FileMode.Open, FileAccess.Read);
			StreamReader SR = new StreamReader(FS);
			String[] teachers = SR.ReadToEnd().Trim().Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			SR.Close();
			FS.Close();

			FileStream FS1 = new FileStream("lps.txt", FileMode.Create, FileAccess.Write);
			StreamWriter SW = new StreamWriter(FS1);
			foreach (String teacher in teachers)
			{
				for (int i = 0; i < 9999; i++)
				{
					for (int i1 = 0; i1 < 10; i1++)
						for (int i2 = 0; i2 < 10; i2++)
							for (int i3 = 0; i3 < 10; i3++)
								for (int i4 = 0; i4 < 10; i4++)
									for (int i5 = 0; i5 < 10; i5++)
									{
										for (int i6 = 0; i6 < 10; i6++)
										{

											SW.Write((teacher + i.ToString()) + ":" + String.Format("{0}{1}{2}{3}{4}{5}\r\n", i1, i2, i3, i4, i5, i6));
											Console.WriteLine((teacher + i.ToString()) + ":" + String.Format("{0}{1}{2}{3}{4}{5}", i1, i2, i3, i4, i5, i6));
										}
										SW.Flush();
									}
				}
			}
			SW.Close();
			FS1.Close();
		}
	}
}
