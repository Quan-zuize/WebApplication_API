using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace service_bus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Student> GetSinhVien()
        {
            List<Student> list = Student.GetSinhVien();
            return list;
        }
        public Student addStudent(Student s)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-03RSBTH;Initial Catalog=GetStudent;Integrated Security=True");

            string sql = "insert into Student(Id,Name) values(@Id,@Name)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@Name", s.Name);
            com.Parameters.AddWithValue("@Email", s.Id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return s;
        }

        public Student addStudent()
        {
            throw new NotImplementedException();
        }
    }
}
