using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebSite.Interface;
using System.Reflection;
using System.Configuration;

namespace MyWebSite.DALFactory
{
    public class UserFactory
    {
        public static IUser Create()
        {
            string path = ConfigurationManager.AppSettings["WebDAL"].ToString();
            string className = path + ".User";

            // 用配置文件指定的类组合  
            return (IUser)Assembly.Load(path).CreateInstance(className);  
        }
    }
}