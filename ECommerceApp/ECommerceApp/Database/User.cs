
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.Database
{
    public class User:BaseRecordType
    {
        public string LoginName { get; set; }
        public string PassWord { get; set; }
        public string Profile { get; set; }
        public User(string loginname,string password,string profile)
        {
            this.Name = loginname;
            this.LoginName = loginname;
            this.PassWord = password;
            this.Profile = profile;
        }
    }
}
