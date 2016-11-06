using System;

namespace ConsoleApplication
{
    abstract class Day
    {
        public abstract void startDay(int a);

        public abstract void dayEvent();

        // tempalte method
        public void day( int number )
        {
            Console.WriteLine( String.Format("Day {0}. Wake up!", number));
            this.startDay(number);
            this.dayEvent();
            this.finishDay(number);
            Console.WriteLine( String.Format("Day {0} has been finished. Go to bed", number) );
        }

        public abstract void finishDay(int a);

    }


    class Day1 : Day
    {
        public override void startDay(int a) 
        {
            Console.WriteLine( String.Format("reading the book") );
        }

        public override void dayEvent()
        {
            Console.WriteLine("Go to the cinema");
        }

        public override void finishDay(int a) 
        {
            Console.WriteLine("plaing CS GO");
        }
    }


    class Day2 : Day
    {
        public override void startDay(int a) 
        {
            Console.WriteLine("talking with my friend");
        }

        public override void dayEvent()
        {
            Console.WriteLine("Go to the shop!");
        }

        public override void finishDay(int a) 
        {
            Console.WriteLine("plaing fifa 17");
            
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Day d1 = new Day1();
            d1.day( 1 );

            Day d2 = new Day2();
            d2.day( 2 );
        }
    }
}
