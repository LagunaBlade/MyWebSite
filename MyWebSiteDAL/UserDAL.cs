using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MyWebSiteModel;
using MyWebSiteInterfaceDAL;

namespace MyWebSiteDAL
{
    public class UserDAL : IUser
    {
        /// <summary>
        /// 是否存在用户，用于用户登录判断等
        /// </summary>
        /// <param name="User">用户</param>
        /// <returns></returns>
        public bool ExistUser(User User)
        {
            using (SqlConnection sqlCon = new SqlConnection(BaseDAL.connectString))
            {
                SqlCommand sqlCommand = sqlCon.CreateCommand();
                sqlCommand.CommandText = "select * from user";

                sqlCon.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
