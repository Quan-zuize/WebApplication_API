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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello baby!");
            ServiceReference1.MyServiceClient myService = new ServiceReference1.MyServiceClient();
            var lists = myService.GetAllUser();

            foreach (var a in lists)
            {
                Console.WriteLine("ID: {0} | Name : {1} | Email : {2} | Phone : {3} | Pass {4} | ClassId {5} |", a.Id, a.Name, a.Email, a.Phone, a.Pass, a.ClassID);
            }
            Console.ReadLine();

            ServiceReference1.SinhVien s = new ServiceReference1.SinhVien();
            Console.WriteLine("Enter student's information");
            Console.Write("Enter Name:");
            s.Name = Console.ReadLine();
            Console.Write("Enter Email:");
            s.Email = Console.ReadLine();
            Console.Write("Enter Phone:");
            s.Phone = Console.ReadLine();
            Console.Write("Enter Pass:");
            s.Pass = Console.ReadLine();
            Console.Write("Enter Class id:");
            s.ClassID = Convert.ToInt32(Console.ReadLine());
            myService.AddSv(s.Name, s.Email, s.Phone, s.Pass, s.ClassID);
        }
    }
}
