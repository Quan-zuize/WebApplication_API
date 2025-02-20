﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<Movie> GetAll();

        [OperationContract]
        List<Movie> Search(string Search);

        [OperationContract]
        Movie GetById(int Id);

        [OperationContract]
        void Add(Movie m);

        [OperationContract]
        void Edit(Movie m);

        [OperationContract]
        void Delete(int Id);
    }
}
