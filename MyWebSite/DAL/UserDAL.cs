using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebSite.Entity;
using System.Data.SqlClient;
using MyWebSite.Interface;

namespace MyWebSite.DAL
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
                sqlCommand.CommandText = "";

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