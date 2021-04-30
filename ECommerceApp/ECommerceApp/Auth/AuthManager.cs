using ECommerceApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp.Auth
{
    public class AuthManager
    {
       

        public static string AcceptLoginCreds(string name,string password)
        {
            bool res = ValidateUser(name, password);
            if (res)
            {
                string type = "";
                RepoDb.users.ForEach((i) =>
                {
                    if (i.LoginName == name)
                    {
                        type = i.Profile;
                    }
                });
                return type;
            }
            return "exit";

        }

        private static bool ValidateUser(string name,string password)
        {
            try
            {
                var res = RepoDb.users.Single((i) => i.LoginName == name && i.PassWord == password);
            }
            catch
            {
                return false;
            }
            return true;
            //bool flag = false;
            //RepoDb.users.ForEach((i) =>
            //{
            //    if(i.LoginName==name && i.PassWord==password)
            //    {
            //        flag = true;
                   
                   
            //    }
            //});
            //if(flag)
            //{
            //    return true;
            //}
            //return false;
           
        }
    }
}
