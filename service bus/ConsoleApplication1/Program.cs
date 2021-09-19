using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello baby!");
            ServiceReference1.Service1Client myService = new ServiceReference1.Service1Client();
            var lists = myService.GetSinhVien();

            foreach (var a in lists)
            {
                Console.WriteLine("ID: {0} | Name : {1} ", a.Id, a.Name);
            }
            Console.ReadLine();

            ServiceReference1.Student s = new ServiceReference1.Student();
            Console.WriteLine("Enter student's information");
            Console.Write("Enter Id:");
            s.Name = Console.ReadLine();
            Console.Write("Enter Name:");
            s.Id = Convert.ToInt32(Console.ReadLine());
            myService.ad
        }
    }
}
