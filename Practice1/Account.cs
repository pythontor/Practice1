using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }

    //public class ApplicationContext : PR5DataSet
    //{
        //public PR5DataSet<Account> Accounts { get; set; }
    //}
}
