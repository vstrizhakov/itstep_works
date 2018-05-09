using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork0609
{
    class Program
    {
        static void swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        static void minmax(int[] a, out int min, out int max)
        {
            min = max = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (min > a[i])
                    min = a[i];
                if (max < a[i])
                    max = a[i];
            }
        }
        static void Main(string[] args)
        {
            int[] z = { 2, 4, 5, 7, 8, 9, 0, 2, 4, 6, -5 };
            int min, max;
            minmax(z, out min, out max);
            Console.WriteLine("m = {0} n = {1}", min, max);
        }
    }

    class MyPoint
    {
        private int x = 1;
        private int y = 9;

        public int X
        {
            set
            {
                this.x = value;
            }
            get
            {
                return this.x;
            }
        }

        public MyPoint(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public void ShowPoint()
        {
            Console.WriteLine("x = {0}, y = {1}", this.x, this.y);
        }
    }

    class Length
    {
        private int km;
        public int KM
        {
            set
            {
                if (value < 0) value *= -1;
                this.km = value;
            }
            get
            {
                return this.km;
            }
        }

        private int m;
        public int M
        {
            set
            {
                if (value < 0) value *= -1;
                this.km += value / 1000;
                this.m = value % 1000;
            }
            get
            {
                return this.m;
            }
        }

        public Length(int km, int m)
        {
            this.KM = km;
            this.M = m;
        }
    }
}
