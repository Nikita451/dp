using System;

namespace ConsoleApplication
{
    interface IButton {
        void paint();
        void destroy();
    }


    class Button : IButton {
        public void paint() {
            Console.WriteLine("Painting button");
        }

        public void destroy() {
            Console.WriteLine("Removing button ...");
        }
    }


    class ProxyButton : IButton {
        
        private IButton button = new Button();
        public void paint() {
            this.button.paint();
            Console.WriteLine("some extra operations");
        }

        public void destroy() {
            this.button.destroy();
            Console.WriteLine("Some extra operations");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // pattern for adding extra static functionality
            IButton button = new ProxyButton();
            button.paint();
            button.destroy();
        }
    }
}
