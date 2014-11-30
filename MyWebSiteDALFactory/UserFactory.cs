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
            string className = path + ".UserDAL";

            Assembly a = Assembly.Load("MyWebSiteDAL");
            return (IUser)Assembly.Load(path).CreateInstance(className);
        }
    }
}
