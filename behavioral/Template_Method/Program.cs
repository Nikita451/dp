using System;

namespace ConsoleApplication
{
    abstract class Day
    {
        public void startDay(int a)
        {
            Console.WriteLine( String.Format("Wake up! (Day {0})", a) );
        }

        public abstract void day();

        public void finishDay(int a)
        {
            Console.WriteLine( String.Format("Go to bed! (Day {0} )", a) );
        }

    }


    class Day1 : Day
    {
        public override void day()
        {
            this.startDay(1);

            Console.WriteLine("go to the cinema!");

            this.finishDay(1);
        }
    }


    class Day2 : Day
    {
        public override void day()
        {
            this.startDay(2);

            Console.WriteLine("go to the shop!");
            
            this.finishDay(2);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Day d1 = new Day1();
            d1.day();

            Day d2 = new Day2();
            d2.day();
        }
    }
}
