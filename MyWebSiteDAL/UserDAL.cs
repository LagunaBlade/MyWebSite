using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MyWebSiteModel;
using MyWebSiteInterfaceDAL;
using MySql.Data.MySqlClient;

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
            using (MySqlConnection sqlCon = new MySqlConnection(BaseDAL.connectString))
            {
                MySqlCommand sqlCommand = sqlCon.CreateCommand();
                sqlCommand.CommandText = "select * from user";

                sqlCon.Open();
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
