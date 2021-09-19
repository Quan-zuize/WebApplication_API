using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace service_bus
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public static List<Student> GetSinhVien()
        {
            List<Student> sinhViens = new List<Student>();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=StudentManagement;Integrated Security=True");
            string sql = "select * from Sinh_Vien ";
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();

                foreach (DataRow row in dt.Rows)
                {
                    sinhViens.Add(new Student()
                    {
                        Id = Convert.ToInt32(row["MaSV"].ToString()),
                        Name = row["HoSV" + "TenSV"].ToString(),
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return sinhViens;
        }
    }
}