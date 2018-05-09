using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Streams
{
	class Auto
	{
		private String mark;
		private double capacity;
		private int year;

		public Auto(String mark = "unknown", double capacity = 0, int year = 0)
		{
			this.mark = mark;
			this.capacity = capacity;
			this.year = year;
		}

		public override string ToString()
		{
			return String.Format("Автомобиль {0}, имеет объем двигателя {1}, {2} года выпуска", this.mark, this.capacity, this.year);
		}

		public void Write(Stream outStream)
		{
			BinaryWriter BW = new BinaryWriter(outStream);
			BW.Write(this.mark);
			BW.Write(this.capacity);
			BW.Write(this.year);
		}

		public void Read(Stream inStream)
		{
			BinaryReader BR = new BinaryReader(inStream);
			this.mark = BR.ReadString();
			this.capacity = BR.ReadDouble();
			this.year = BR.ReadInt32();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//MemoryStream MS = new MemoryStream();
			//StreamWriter SW = new StreamWriter(MS, Encoding.UTF8);
			//char[] sentence = { 'П', 'р', 'и', 'в', 'е', 'т', ',', 'м', 'и', 'р' };
			//SW.Write(sentence, 0, sentence.Length);
			//SW.Write(true);
			//SW.Write(47);
			//SW.Write(4.56);
			//SW.Write("Hello, world!");
			//SW.Flush();
			//byte[] buf = MS.GetBuffer();
			//for (int i = 0; i < (int)MS.Length; i++)
			//{
			//	Console.WriteLine("a[{0}] = {1}", i, buf[i]);
			//}
			//SW.Close();

			//FileStream FS = new FileStream("123.txt", FileMode.Create, FileAccess.Write);
			//StreamWriter SW = new StreamWriter(FS, Encoding.UTF8);
			//char[] sentence = { 'П', 'р', 'и', 'в', 'е', 'т', ',', 'м', 'и', 'р' };
			//SW.Write(sentence, 0, sentence.Length);
			//SW.Write(true);
			//SW.Write(47);
			//SW.Write(4.56);
			//SW.Write("Hello, world!");
			//SW.Close();

			//int[] A = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
			//FileStream MS = new FileStream("1234.txt", FileMode.Create, FileAccess.Write);
			//BinaryWriter BW = new BinaryWriter(MS);
			//int a = 12;
			//double b = 5.67;
			//char c = 'A';
			//short e = 51;
			//bool d = true;
			//String f = "Hello";
			//BW.Write(a);
			//BW.Write(b);
			//BW.Write(c);
			//BW.Write(d);
			//BW.Write(e);
			//BW.Write(f);
			////BW.Flush();
			////byte[] z = MS.GetBuffer();
			////for (int i = 0; i < (int)MS.Length; i++)
			////{
			////	Console.WriteLine("z[{0}] = {1}", i, z[i]);
			////}
			//BW.Close();

			//FileStream FS = new FileStream("1234.txt", FileMode.Open, FileAccess.Read);
			//BinaryReader BR = new BinaryReader(FS);
			//int a = BR.ReadInt32();
			//double b = BR.ReadDouble();
			//char c = BR.ReadChar();
			//short d = BR.ReadInt16();
			//bool e = BR.ReadBoolean();
			//String f = BR.ReadString();

			//Console.WriteLine(a);
			//Console.WriteLine(b);
			//Console.WriteLine(c);
			//Console.WriteLine(d);
			//Console.WriteLine(e);
			//Console.WriteLine(f);
			//BR.Close();

			Auto[] A = {
						new Streams.Auto("Daewoo", 1.3, 2007),
						new Streams.Auto("Niva", 1.7, 2012),
						new Streams.Auto("Opel", 1.9, 2015),
						new Streams.Auto("Nissan", 2.2, 2011),
						new Streams.Auto("Mersedes", 1.5, 2002),
						};
			FileStream FS = new FileStream("autos.dat", FileMode.Create, FileAccess.Write);
			foreach (Auto a in A)
			{
				a.Write(FS);
			}
			FS.Close();
			FS = new FileStream("autos.dat", FileMode.Open, FileAccess.Read);
			Auto[] b = new Auto[5];
			for (int i = 0; i < b.Length; i++)
			{
				b[i] = new Auto();
				b[i].Read(FS);
				Console.WriteLine(b[i]);
			}
			FS.Close();
		}
	}
}
