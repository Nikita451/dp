using System;

namespace ConsoleApplication
{
    public class Program
    {
        interface IWindow 
        {
            void paint();
        }

        class Button : IWindow 
        {
            public void paint() 
            {
                Console.WriteLine("Painting button ...");
            }
        }


        class Decorator : IWindow 
        {
            protected IWindow dec;

            public Decorator ( IWindow dec )
            {
                this.dec = dec;
            }
            private Button  button = new Button();

            public virtual void paint()
            {
                this.button.paint();
            }
        }

        class DecorationBackground : Decorator
        {
            public DecorationBackground( IWindow dec ) : base(dec)
            {}
            public override void paint()
            {
                Console.WriteLine("Some background ...");
                this.dec.paint();
            }
        }

        class DecorationText : Decorator {
            
            public DecorationText( IWindow dec ) : base(dec)
            {}
            public override void paint()
            {
                Console.WriteLine("setting text for button ...");
                this.dec.paint();
            }
        }

        class DecorationStyle : Decorator {
            public DecorationStyle( IWindow dec ) : base(dec)
            {}
            public override void paint()
            {
                Console.WriteLine("style for button");
                this.dec.paint();
            }
        }

        public static void Main(string[] args)
        {
            IWindow dc = new DecorationStyle( new DecorationText( new DecorationBackground( new Button() ) ) );
            dc.paint();
            // output:
            /*
            style for button
            setting text for button ...
            Some background ...
            Painting button ...
            */
            
        }
    }
}
