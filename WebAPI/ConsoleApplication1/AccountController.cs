using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleApplication1
{
    public class AccountController:ApiController
    {
        //Account_Model dbContext = new Account_Model();
        //static private List<Account> accounts = new List<Account>()
        //{
        //    new Account{id = 1,AccName = "Quanprovjp",AccEmail = "quan@gmail.com",AccNo=1},
        //    new Account{id = 2,AccName = "Anonymous",AccEmail = "wwhat@gmail.hoi",AccNo=2}
        //};
        //public IEnumerable<Account> Get()
        //{
        //    return accounts;
        //}
        //public void Post([FromBody] Account item)
        //{
        //    dbContext.Accounts.Add(item);
        //    dbContext.SaveChanges();
        //}
        //public void Put(Account item)
        //{
        //    if (item != null)
        //    {
        //        Account a = dbContext.Accounts.Where(n => n.id == item.id).First();
        //        a.id = item.id;
        //        a.AccName = item.AccName;
        //        a.AccEmail = item.AccEmail;
        //        a.AccNo = item.AccNo;
        //    }
        //}
        //public void Delete(int id)
        //{
        //    Account s = (from a in dbContext.Accounts
        //              where a.id == id
        //              select a).FirstOrDefault();
        //    dbContext.Accounts.Remove(s);
        //    dbContext.SaveChanges();
        //}
    }
}
