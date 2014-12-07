using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebSiteModel
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User
    {
        #region Properties

        /// <summary>
        /// 用户名
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Email
        /// </summary>
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        #endregion
    }
}
