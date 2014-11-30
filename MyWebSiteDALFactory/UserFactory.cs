using System.Reflection;
using System.Configuration;
using MyWebSiteInterfaceDAL;

namespace MyWebSiteDALFactory
{
    public class UserFactory
    {
        public static IUser Create()
        {
            string path = ConfigurationManager.AppSettings["WebDAL"].ToString();
            string className = path + ".User";
            //MyWebSiteDAL.UserDAL

            Assembly a = Assembly.Load("MyWebSiteDAL");
            // 用配置文件指定的类组合  
            return (IUser)Assembly.Load(path).CreateInstance(className);
        }
    }
}
