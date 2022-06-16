using HRMWebAPI2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMWebAPI2022
{
    public class Security
    {
        public bool Login(string username, string password)
        {
            using (HRMDBEntities5 db = new HRMDBEntities5())
            {
                string pass = MySecurity.MD5Hash(password);
                var account = db.Accounts.SingleOrDefault(a=> a.Username == username && a.Password == MySecurity.MD5Hash(password));
                if(account != null)
                    return true;
                else
                    return false;
            }
        }
    }
}