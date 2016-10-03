using System;

namespace ConsoleApplication
{
    interface IButton 
    {
        void paint();
    }

    class WindowsButton : IButton
    {
        public void paint()
        {
            Console.WriteLine("Painting windows button ...");
        }
    }

    class LinuxButton : IButton
    {
        public void paint()
        {
            Console.WriteLine("Painting linux button ...");
        }
    }

    interface ITable 
    {
        void paint();
    }

    class WindowsTable : ITable
    {
        public void paint()
        {
            Console.WriteLine("Painting windows table ...");
        }
    }

    class LinuxTable : ITable
    {
        public void paint()
        {
            Console.WriteLine("Painting linux table...");
        }
    }

    interface Factory
    {
        IButton createButton();
        ITable createTable();
    }

    class WindowsFactory : Factory
    {
        public IButton createButton()
        {
            return new WindowsButton();
        }

        public ITable createTable()
        {
            return new WindowsTable();
        }
        
    }

    class LinuxFactory : Factory
    {
        public IButton createButton()
        {
            return new LinuxButton();
        }

        public ITable createTable()
        {
            return new LinuxTable();
        }
    }


    public class Program
    {
        static Factory createGui()
        {
            // reading some config file ...
            string currentOs = "linux";
            if (currentOs == "linux")
            {
                return new LinuxFactory();
            }   else {
                return new WindowsFactory();
            }     
        }
        public static void Main(string[] args)
        {
            Factory guiFactory = createGui();
            IButton button =  guiFactory.createButton();
            ITable table = guiFactory.createTable();

            button.paint();
            table.paint();
        }
    }
}
