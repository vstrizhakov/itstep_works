using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMethods
{
	class Program
	{
		class Time
		{
			private int hour;
			private int minute;
			private int seconds;

			public int Hour
			{
				get
				{
					return this.hour;
				}
			}

			public int Minute
			{
				get
				{
					return this.minute;
				}
			}

			public int Seconds
			{
				get
				{
					return this.seconds;
				}
			}

			private Time(int hour, int minute, int seconds)
			{
				this.hour = hour;
				this.minute = minute;
				this.seconds = seconds;
			}

			public static Time GetTimeInstance()
			{
				DateTime Dt = DateTime.Now;
				return new Time(Dt.Hour, Dt.Minute, Dt.Second);
			}

			public void Show()
			{
				Console.WriteLine("H: {0} M: {1} S: {2}", this.Hour, this.Minute, this.Seconds);
			}
		}

		static void Main(string[] args)
		{
			Time mt = Time.GetTimeInstance();
			mt.Show();
		}
	}
}
