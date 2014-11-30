using System.Reflection;
using System.Configuration;
using MyWebSiteInterfaceDAL;

namespace MyWebSiteDALFactory
{
    public class UserFactory
    {
        /// <summary>
        /// 反射User实例
        /// </summary>
        /// <returns></returns>
        public static IUser Create()
        {
            string path = ConfigurationManager.AppSettings["WebDAL"].ToString();
            string className = path + ".UserDAL";

            Assembly a = Assembly.Load("MyWebSiteDAL");
            return (IUser)Assembly.Load(path).CreateInstance(className);
        }
    }
}
