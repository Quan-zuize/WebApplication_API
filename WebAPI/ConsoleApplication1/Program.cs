using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApp.Start<startupService>(url: "http://localhost:9095");
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> resp = client.GetAsync("http://localhost:9095/Quan/Product");
            var response = resp.Result;
            Task<String> respMessage = response.Content.ReadAsStringAsync();
            Console.WriteLine(response);
            Console.WriteLine(respMessage.Result);
            Console.ReadLine();
        }
    }
}
