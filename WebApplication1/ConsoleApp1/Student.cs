using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student : TableEntity
    {
        public String name { get; set; }
        public String email { get; set; }
        public String mark { get; set; }
        public String comment { get; set; }
    }
}
