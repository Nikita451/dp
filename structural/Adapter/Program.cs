using System;

namespace ConsoleApplication
{

    class SomeClass {
        public void badMethod1() {
            Console.WriteLine("Method 1");
        }

        public void badMethod2() {
            Console.WriteLine("Method 2");
        }
    }


    interface IAdapter {
        void myMethod1();
        void myMethod2();
    }


    class Adapter : IAdapter {

        private SomeClass ad = new SomeClass();

        public void myMethod1() {
            this.ad.badMethod1();
        }

        public void myMethod2() {
            this.ad.badMethod2();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IAdapter myad = new Adapter();
            myad.myMethod1();
            myad.myMethod2();
        }
    }
}
