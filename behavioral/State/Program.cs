using System;

namespace ConsoleApplication
{
    interface IState
    {
        void eat();
        void drink();
    }


    class StateMoscow : IState
    {
        public void eat()
        {
            Console.WriteLine("eating a potatoes (Moscow)");
        }

        public void drink()
        {
            Console.WriteLine("drinking some juice (Moscow)");
        }

    }


    class StateSPB : IState
    {
        public void eat()
        {
            Console.WriteLine("eating a chicken (SPB)");
        }

        public void drink()
        {
            Console.WriteLine("drinking some beer (SPB)");
        }

    }

    class StateMurmansk : IState
    {
        public void eat()
        {
            Console.WriteLine("eating a fish (Murmansk)");
        }

        public void drink()
        {
            Console.WriteLine("drinking some water (Murmansk)");
        }

    }

    // Widget
    class Traveler
    {
        // some states .
        private const string state1 = "Murmansk";
        private const string state2 = "SPB";
        private const string state3 = "Moscow";
        private int count = 0;

        private IState state;
        public Traveler()
        {
            this.setState( Traveler.state1 );
        }

        public void setState( string st)
        {
            if (st ==  Traveler.state1 ) 
            {
                this.state = new StateMurmansk();
            } 
            else if (st == Traveler.state2)
            {
                this.state = new StateSPB();   
            } else {
                this.state = new StateMoscow();
            }
        }

        public void buyTickets()
        {
            Console.WriteLine("buing tickets for traveling ...");
        }

        public void eat()
        {
            this.state.eat();
            this.incCount();
            this.changeState();
        }

        public void drink()
        {
            this.state.drink();
            this.incCount();
            this.changeState();
        }

        private void incCount()
        {
            this.count++;
        }

        private void changeState()
        {
            if (this.count < 2) 
            {
                this.setState( Traveler.state1 );
            } 
            else if (this.count < 4)
            {
                this.setState( Traveler.state2 );
            } 
            else if (this.count < 6)
            {
                this.setState( Traveler.state3 );
            } 
            else 
            {
                // we are at Home.
                this.count = 0;
                this.setState( Traveler.state1 );
            }
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Our path: Murmansk -> SPB -> Moscow
            // In the every city we must eat and drink (or eat twice, or drink twice )
            // And return to the back. (Murmansk)
            // start position is Murmansk.

            Traveler tr = new Traveler();
            tr.eat();
            tr.drink();

            tr.eat();
            tr.eat();

            tr.drink();
            tr.drink();

            tr.eat();
            tr.drink();

        }
    }
}
