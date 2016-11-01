using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    abstract class HttpResponse 
    {
        protected HttpResponse nextAction = null;
        public void setNextPage( HttpResponse na ) 
        {
            this.nextAction = na;
        }

        public void renderNext( HttpResponse hr, string url )
        {
            if (hr != null) 
                {
                    hr.handleMessage(url);
                } else {
                    Console.WriteLine("Rendering ERROR template ...");
                }
        }

        public abstract void handleMessage(string url);

    }

    class ResponseHome : HttpResponse {
        public override void handleMessage(string url) 
        {
            if (url == "/home")
            {
                Console.WriteLine("Rendering template for home page ...");
            } else {
                this.renderNext( this.nextAction, url );
            }
        }
    }

    class ResponseContact : HttpResponse {
        public override void handleMessage(string url) 
        {
            if (url == "/contact")
            {
                Console.WriteLine("Rendering template for contact page ...");
            } else {
                this.renderNext( this.nextAction, url );
            }
        }
    }

    class ResponseAbout : HttpResponse 
    {
        public override void handleMessage(string url)
        {
            if (url == "/about")
            {
                Console.WriteLine("Rendering template for about page ...");
            } else {
                this.renderNext( this.nextAction, url );
            }
        }
    }


    class WebSite
    {
        private HttpResponse start;
        public WebSite()
        {
            ResponseHome rh = new ResponseHome();
            ResponseContact rc = new ResponseContact();
            ResponseAbout ro = new ResponseAbout();

            rh.setNextPage( rc );
            rc.setNextPage( ro );
            this.start = rh;
        }
        public void getRequest(string url) 
        {
             this.start.handleMessage( url );
        }
    }



    

    public class Program
    {
        public static void Main(string[] args)
        {
            string request_url1 = "/about";
            string request_url2 = "/123";

            WebSite wb = new WebSite();
            wb.getRequest( request_url1 );
            wb.getRequest(request_url2);
        }
    }
}
