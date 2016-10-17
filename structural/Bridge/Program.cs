using System;

namespace ConsoleApplication
{
    abstract class Report {
        protected Format format;
         abstract public void print();
    }

    class Report1 : Report {
        public Report1( Format format )
        {
            this.format = format;
        }
        public override void print() {
            string text =  "Text of report 1";
            this.format.print( text );
        }
    }

    class Report2 : Report {
        public Report2( Format format ) {
            this.format = format;
        }
        public override void print() {
            string text =  "Text of report 2";
            this.format.print( text );
        }
    }


    abstract class Format {
        abstract public void print( string text );
    }

     class PdfFormat : Format {
         public override void print( string text ) {
             Console.WriteLine( text + "  in PDF format" );
         }
    }

    class XmlFormat : Format {
        public override void print( string text ) {
            Console.WriteLine( text + " in XML format" );
        }
    }

    

    public class Program
    {
        public static void Main(string[] args)
        {
            Report1 pr1 = new Report1( new PdfFormat() );
            pr1.print();

            Report2 pr2 = new Report2( new XmlFormat() );
            pr2.print();

        }
    }
}
