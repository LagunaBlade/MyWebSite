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
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
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

        #endregion
    }
}
