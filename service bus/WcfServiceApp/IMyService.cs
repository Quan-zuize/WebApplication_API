using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        List<SinhVien> GetAllUser();

        [OperationContract]
        SinhVien GetSvById(int id);

        [OperationContract]
        int AddSv(string Name, string Email, string Phone, string Pass, int ClassID);

        [OperationContract]
        int UpdateSv(int Id, string Name, string Email, string Phone, string Pass, int ClassID);

        [OperationContract]
        int DeleteSvById(int Id);
    }
}
