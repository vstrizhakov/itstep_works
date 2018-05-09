using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceC.NET
{
    class MyPoint
    {
        protected int x;
        protected int y;

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
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("MyPoint constructor with params");
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void ShowPoint()
        {
            Console.WriteLine("x = {0} y = {1}", this.x, this.y);
        }

        public MyPoint()
        {
            Console.WriteLine("MyPoint default constructor");
        }

        public virtual void test()
        {
            Console.WriteLine("MyPoint test");
        }
    }

    class MyPoint3D : MyPoint
    {
        protected int z;

        public override void test()
        {
            Console.WriteLine("MyPoint 3D test");
        }
        public void SetZ(int z)
        {
            this.z = z;
        }

        public MyPoint3D(int x, int y, int z) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            Console.WriteLine("MyPoint3D constructor with params");
        }

        public new void ShowPoint()
        {
            Console.WriteLine("x = {0} y = {1}", this.x, this.y);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            MyPoint mp = new MyPoint3D(12, 50, 0);
            mp.test();

            if (mp is MyPoint3D)
            {
                ((MyPoint3D)mp).ShowPoint();
            }
            else
            {
                Console.WriteLine("Приведение к типу mypoint3D невозможно");
            }

            MyPoint mp1 = mp as MyPoint3D;
            if (mp1 != null)
            {
                ((MyPoint3D)mp).ShowPoint();
            }
            else
            {
                Console.WriteLine("Приведение к типу MyPoint3D невозможно");
            }
        }
    }
}
