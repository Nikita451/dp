using System;

namespace ConsoleApplication
{
    class Cloud
    {
        public void paint(string color)
        {
            Console.WriteLine( String.Format("Painting a {0} cloud", color) );
        }
    }

    class House
    {
        public void paint(string color)
        {
            Console.WriteLine( String.Format("Painting a {0} house", color) );
        }
    }

    class Grass
    {
        public void paint(string color)
        {
            Console.WriteLine( String.Format("Painting a {0} grass", color) );
        }
    }

    class Picture 
    {
        public void paint( string colorCloud, string colorHouse, string colorGrass )
        {
            Cloud cloud = new Cloud();
            House house = new House();
            Grass grass = new Grass();

            cloud.paint(colorCloud);
            house.paint(colorHouse);
            grass.paint(colorGrass);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Picture pc = new Picture();
            pc.paint("red", "green", "blue");
        }
    }
}
