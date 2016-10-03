using System;

// Modern version of the pattern
namespace ConsoleApplication
{
    interface IApplication
    {
        void run();
    }

    class WebApp : IApplication
    {
        public void run()
        {
            Console.WriteLine("running web application ...");
        }
    }

    class DesktopApp : IApplication
    {
        public void run()
        {
            Console.WriteLine("running desktop application ...");
        }
    }

    class CreatorApp
    {
        static public IApplication createApp(string app)
        {
            if (app == "web")
            {
                return new WebApp();
            } else {
                return new DesktopApp();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IApplication app =  CreatorApp.createApp("web");
            app.run();
        }
    }
}
