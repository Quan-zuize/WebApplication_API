using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        EntityModel db = new EntityModel();

        public List<SinhVien> GetAllUser()
        {
            List<SinhVien> userlst = new List<SinhVien>();   
            var listUsr = from a in db.SinhViens select a;
            foreach (var item in listUsr)
            {
                SinhVien sv = new SinhVien();
                sv.Id = item.Id;
                sv.Name = item.Name;
                sv.Phone = item.Phone;
                sv.Email = item.Email;
                sv.Pass = item.Pass;
                sv.ClassID = item.ClassID;
                userlst.Add(sv);
            }
            return userlst;
        }

        public SinhVien GetSvById(int id)
        {
            var listUsr = from a in db.SinhViens where a.Id==id select a;
            SinhVien sv = new SinhVien();
            foreach(var item in listUsr)
            {
                sv.Id = item.Id;
                sv.Name = item.Name;
                sv.Email = item.Email;
                sv.Phone = item.Phone;
                sv.Pass = item.Pass;
                sv.ClassID = sv.ClassID;
            }
            return sv;
        }

        public int DeleteSvById(int Id)
        {
            SinhVien sv = new SinhVien();
            sv.Id = Id;
            db.Entry(sv).State = System.Data.Entity.EntityState.Deleted;
            int Retval = db.SaveChanges();
            return Retval;
        }

        public int AddSv(string Name, string Email, string Phone, string Pass, int ClassID)
        {
            SinhVien sv = new SinhVien();
            sv.Name = Name;
            sv.Email = Email;
            sv.Phone = Phone;
            sv.Pass = Pass;
            sv.ClassID = ClassID;
            db.SinhViens.Add(sv);
            int Retval = db.SaveChanges();
            return Retval;
        }
        public int UpdateSv(int Id, string Name, string Email, string Phone, string Pass, int ClassID)
        {
            SinhVien sv = new SinhVien();
            sv.Id = Id;
            sv.Name = Name;
            sv.Email = Email;
            sv.Phone = Phone;
            sv.Pass = Pass;
            sv.ClassID = ClassID;
            db.Entry(sv).State = System.Data.Entity.EntityState.Modified;

            int Retval = db.SaveChanges();
            return Retval;
        }
    }
}
