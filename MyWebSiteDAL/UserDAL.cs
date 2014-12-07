using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MyWebSiteModel;
using MyWebSiteInterfaceDAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace MyWebSiteDAL
{
    public class UserDAL : IUser
    {
        #region User信息处理

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
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand);
                DataTable data = new DataTable();
                adapter.Fill(data);

                sqlCon.Open();
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 是否存在用户，用于用户登录判断等
        /// </summary>
        /// <param name="User">用户</param>
        /// <returns></returns>
        public User GetLoginUser(User User)
        {
            List<User> userList = new List<User>();

            using (MySqlConnection sqlCon = new MySqlConnection(BaseDAL.connectString))
            {
                MySqlCommand sqlCommand = sqlCon.CreateCommand();
                sqlCommand.CommandText = "select * from user where name = @name and password = @password";
                sqlCommand.Parameters.AddWithValue("@name", User.Name);
                sqlCommand.Parameters.AddWithValue("@password", User.Password);

                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand);
                DataTable data = new DataTable();
                adapter.Fill(data);
                userList = ExecuteEntity.GetEntities<User>(data);

                if (userList.Count == 1)
                {
                    return userList[0];
                }
            }

            return null;
        }

        #endregion
    }
}
