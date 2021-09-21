using System;
using System.Collections.Generic;
using System.Data;
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
        public List<Sinh_Vien> GetSinhVien()
        {
            List<Sinh_Vien> sinhViens = new List<Sinh_Vien>();
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
                    sinhViens.Add(new Sinh_Vien()
                    {
                        MaSV = row["MaSV"].ToString(),
                        HoSV = row["HoSV"].ToString(),
                        TenSV = row["TenSV"].ToString(),
                        NgaySinh = DateTime.ParseExact(row["NgaySinh"].ToString(), "dddd, dd MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        GioiTinh = row["GioiTinh"].ToString(),
                        MaKhoa = row["MaKhoa"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return sinhViens;
        }
        public Sinh_Vien addStudent(Sinh_Vien s)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=StudentManagement;Integrated Security=True");

            string sql = "insert into Sinh_Vien(HoSV,TenSV,NgaySinh,GioiTinh,MaKhoa) values(@HoSV,@TenSV,@NgaySinh,@GioiTinh,@MaKhoa)";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@HoSV", s.HoSV);
            com.Parameters.AddWithValue("@TenSV", s.TenSV);
            com.Parameters.AddWithValue("@NgaySinh", s.NgaySinh);
            com.Parameters.AddWithValue("@GioiTinh", s.GioiTinh);
            com.Parameters.AddWithValue("@MaKhoa", s.MaKhoa);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return s;
        }
    }
}
