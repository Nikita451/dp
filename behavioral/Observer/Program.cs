using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    interface IGirl {
         void goFromHome( );
         void addObserver( IAm am );
         void removeObserver( IAm am );
         void emitEvent();
    }

    class MyGirl : IGirl {
        protected List<IAm> boys = new List<IAm>();
        public void goFromHome() 
        {
            Console.WriteLine("Going from home ...");
            this.emitEvent();
        }

        public void addObserver(IAm am) 
        {
            this.boys.Add( am );
        }

        public  void removeObserver(IAm am) {
            this.boys.Remove( am );
        }

        public void emitEvent() 
        {
            foreach (IAm am in this.boys) 
            {
                am.whenSheGoaway();
            }
        }
        
    }


    interface IAm {
        void whenSheGoaway();
    }


    class Jack : IAm {
        public void whenSheGoaway()
        {
            Console.WriteLine("Jack knows everything ... :(");
        }
    }

    class Bob : IAm {
        public void whenSheGoaway()
        {
            Console.WriteLine("Bob knows everything ... :(");
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            IGirl girl = new MyGirl();
            IAm bob = new Bob();
            IAm jack = new Jack();

            girl.addObserver( bob );
            girl.addObserver( jack );

            girl.goFromHome();
        }
    }
}
