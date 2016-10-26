using System;

namespace ConsoleApplication
{

    interface IVsitor 
    {
        void visit( Square rep );
        void visit(Rectangle rep);
    }

    class VisitorPerimeter : IVsitor 
    {
        public void visit( Square rep ) 
        {
            Console.WriteLine( String.Format("Perimeter: {0}",  4 * rep.getA() ) );
        }

        public void visit(Rectangle rep)
        {
            int per = 2 * rep.getA() + 2 * rep.getB();
            Console.WriteLine( String.Format("Perimeter: {0}", per  ) );
        }
    }

    class VisitorSquare : IVsitor
    {
        public void visit( Square rep ) 
        {
           int sq = rep.getA() * rep.getA();
           Console.WriteLine( String.Format("Square: {0}", sq) );
        }

        public void visit(Rectangle rep)
        {
           int sq = rep.getA() * rep.getB();
           Console.WriteLine( String.Format("Square: {0}", sq) );
        }
    }

    interface Figure
    {
        void accept( IVsitor vis );
    }
    
    class Square : Figure
    {
        private int a;
        public Square(int a) {
            this.a = a;
        }
        public void accept( IVsitor vis )
        {
            vis.visit(this);
        }

        // side of Square
        public int getA() 
        {
            return this.a;
        }
        
    }

    class Rectangle : Figure
    {
        private int a, b;
        public Rectangle(int a, int b) 
        {
            this.a = a; this.b = b;
        }
        public void accept(IVsitor vis)
        {
            vis.visit( this );
        }

        public int getA() 
        {
            return this.a;
        }

        public int getB()
        {
            return this.b;
        }

    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Figure rec = new Rectangle(4, 5);
            rec.accept( new VisitorPerimeter() );
            rec.accept( new VisitorSquare() );

            Figure sq = new Square(5);
            sq.accept( new VisitorPerimeter() );
            sq.accept( new VisitorSquare() );
            
        }
    }
}
