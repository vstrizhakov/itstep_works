using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home0609
{
	class Time
	{
		private int h;
		private int m;
		private int s;

		public int H
		{
			set
			{
				this.h = (this.h + value) % 24;
			}
			get
			{
				return this.h;
			}
		}

		public int M
		{
			set
			{
				if ((this.m + value) / 60 >= 1)
					this.H = (this.m + value) / 60;
				this.m = (this.m + value) % 60;				
			}
			get
			{
				return this.m;
			}
		}

		public int S
		{
			set
			{
				if ((this.s + value) / 60 >= 1)
					this.M = (this.s + value) / 60;
				this.s = (this.s + value) % 60;
			}
			get
			{
				return this.s;
			}
		}

		public Time(int h = 0, int m = 0, int s = 0)
		{
			this.H = h;			
			this.M = m;			
			this.S = s;
		}

		public Time(int s = 0)
		{
			this.S = s;
		}

		public Time()
		{
			this.H = 0;
			this.M = 0;
			this.S = 0;
		}

		public override String ToString()
		{
			return String.Format("{0:D2}:{1:D2}:{2:D2}", this.h, this.m, this.s);
		}

		public int ToSeconds()
		{
			return ((this.H * 60) + this.M) * 60 + this.S;
		}

		public Time AddTime(Time t)
		{
			Time tmp = new Time(this.ToSeconds() + t.ToSeconds());
			return tmp;
		}

		public Time SubTime(Time t)
		{
			Time tmp;
			int t1 = this.ToSeconds(), t2 = t.ToSeconds();
			if (t1 > t2)
				tmp = new Time(t1 - t2);
			else
				tmp = new Time(t2 - t1);
			return tmp;
		}

		public int Compare(Time t)
		{
			int t1 = this.ToSeconds(), t2 = t.ToSeconds();
			return t1 - t2;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Time mt = new Time(3662);
			Time mt2 = new Time(62);
			Time nt = mt.SubTime(mt2);
			int sub = mt.Compare(mt2);
			Console.WriteLine(sub);
		}
	}
}
