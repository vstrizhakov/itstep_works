using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files
{
	class Program
	{
		static String filePath = "log.txt";
		static void Main(string[] args)
		{
			//FileStream FS = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			//Byte[] buf = new Byte[2048];
			//while (FS.Position != FS.Length)
			//{
			//	int cnt = FS.Read(buf, 0, buf.Length);
			//	if (cnt == 0) break;
			//	//for (int i = 0; i < cnt; i++)
			//	//	Console.WriteLine("buf[{0}] = {1}", i, buf[i]);
			//	Console.WriteLine(Encoding.UTF8.GetString(buf, 0, cnt));
			//}
			//FS.Close();

			//FileStream FS = new FileStream(Program.filePath, FileMode.Open, FileAccess.Read);
			//Byte[] buf = new Byte[2048];
			//int cnt = FS.Read(buf, 0, 3);
			//int offset = 3;
			//if (cnt != 3 || (buf[0] != 239 && buf[1] != 187 && buf[2] != 191))
			//{
			//	// ASCII
			//	while (FS.Position != FS.Length)
			//	{
			//		cnt = FS.Read(buf, offset, buf.Length - offset);
			//		if (cnt == 0) break;
			//		Console.WriteLine(Encoding.Default.GetString(buf, 0, cnt + offset));
			//		offset = 0;
			//	}
			//}
			//{
			//	// UTF8
			//  MemoryStream MS = new MemoryStream();
			//	while (FS.Position != FS.Length)
			//	{
			//		cnt = FS.Read(buf, 0, buf.Length);
			//		if (cnt == 0) break;
			//		MS.Write(buf, 0, cnt);
			//	}
			//	byte[] a = MS.GetBuffer();
			//	String str = Encoding.UTF8.GetString(a, 0, a.Length);
			//	Console.WriteLine(str);
			//}

			//FileInfo FI = new FileInfo(filePath);
			//if (FI.Exists == false)
			//{
			//	FI.Create();
			//}

			//Console.WriteLine("Дата создания: {0}", FI.CreationTime);
			//Console.WriteLine("Дата изменения: {0}", FI.LastWriteTime);

			//FileStream FS = FI.Open(FileMode.Append, FileAccess.Write);
			//String str = "Hello, world!";
			//Byte[] bud = Encoding.UTF8.GetBytes(str);
			//FS.Write(bud, 0, bud.Length);
			//FS.Close();

			//try
			//{
			//	FI.CopyTo("hello1.txt");
			//}
			//catch { }

			FileStream FS = new FileStream(filePath, FileMode.Open,FileAccess.Read);
			StreamReader SR = new StreamReader(FS);
			String str;
			while (SR.EndOfStream == false)
			{
				str = SR.ReadLine();
				Console.WriteLine(str);
			}
			SR.Close();
		}
	}
}
