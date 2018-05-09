using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DataContract_
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceHost serviceHost = new ServiceHost(typeof(Navigator));
			serviceHost.Open();
			Console.ReadKey(true);
			serviceHost.Close();
		}
	}

	[DataContract]
	[KnownType(typeof(MyPoint3D))]
	public class MyPoint
	{
		[DataMember]
		public int y;
		[DataMember]
		public int x;

		public MyPoint(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return String.Format("x = {0}, y = {1}", this.x, this.y);
		}
	}

	[DataContract]
	public class MyPoint3D : MyPoint
	{
		[DataMember]
		public int z;

		public MyPoint3D(int x, int y, int z) : base(x, y)
		{
			this.z = z;
		}
	}

	[ServiceContract]
	public class Navigator
	{
		private static Random R = new Random();

		[OperationContract]
		MyPoint GetPoint()
		{
			return (R.Next(0, 2) % 2 == 0) ? (new MyPoint(10, 13)) : (new MyPoint3D(0, 1, 2));
		}

		[OperationContract]
		MyPoint[] GetPoints()
		{
			return new MyPoint[]
			{
				new MyPoint(1,2),
				new MyPoint(11,22),
				new MyPoint(21,22),
				new MyPoint(31,32),
				new MyPoint(41,42),
			};
		}

		[OperationContract]
		public List<MyPoint> GetPointsList()
		{
			List<MyPoint> L = new List<MyPoint>();
			L.Add(new MyPoint(1, 2));
			L.Add(new MyPoint(21, 22));
			L.Add(new MyPoint(31, 32));
			L.Add(new MyPoint(41, 42));
			return L;
		}

		[OperationContract]
		public MyPointCollection GetMyPointCollection()
		{
			MyPointCollection L = new MyPointCollection();
			L.Add(new MyPoint(1, 2));
			L.Add(new MyPoint(21, 22));
			L.Add(new MyPoint(31, 32));
			L.Add(new MyPoint(41, 42));
			return L;
		}
	}

	[CollectionDataContract]
	public class MyPointCollection : List<MyPoint>
	{

	}
}
