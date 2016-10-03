using System;

namespace ConsoleApplication
{
    public class Program
    {
        class Singleton 
        {
            private int counter = 0;
            private Singleton(){}
            static private Singleton obj = null;
            public static Singleton getInstance()
            {
                if ( obj == null)
                {  
                   obj = new Singleton();
                   return obj; 
                } else {
                    return obj;
                }
            }

            public int counterInc()
            {
                return ++this.counter;
            }
        }
        public static void Main(string[] args)
        {
            Singleton st = Singleton.getInstance();
            Console.WriteLine( st.counterInc() );

            Singleton st2 = Singleton.getInstance();
            Console.WriteLine( st2.counterInc() );
        }
    }
}
