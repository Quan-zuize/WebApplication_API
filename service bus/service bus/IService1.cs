﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace service_bus
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Sinh_Vien> GetSinhVien();

        [OperationContract]
        Sinh_Vien addStudent(Sinh_Vien s);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}
