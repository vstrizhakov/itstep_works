using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			ChannelFactory<DataContract_.Navigator> channelFactory = new ChannelFactory<DataContract_.Navigator>("MyConfig");
			DataContract_.Navigator client = channelFactory.CreateChannel();
			List<DataContract_.MyPoint> mps = client.GetPointsList();
			foreach (DataContract_.MyPoint mp in mps)
				Console.WriteLine(mp);
		}
	}
}

namespace DataContract_
{
	[DataContract]
	[KnownType(typeof(MyPoint3D))]
	public class MyPoint
	{
		[DataMember]
		public int y;
		[DataMember]
		public int x;

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

		public override string ToString()
		{
			return String.Format("x = {0}, y = {1}, z = {2}", this.x, this.y, this.z);
		}
	}

	[ServiceContract]
	public interface Navigator
	{
		[OperationContract]
		MyPoint GetPoint();

		[OperationContract]
		MyPoint[] GetPoints();

		[OperationContract]
		List<MyPoint> GetPointsList();

		[OperationContract]
		MyPointCollection GetMyPointCollection();
	}

	[CollectionDataContract]
	public class MyPointCollection : List<MyPoint>
	{

	}
}
