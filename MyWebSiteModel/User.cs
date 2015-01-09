using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebSiteModel
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User : ICloneable
    {
        #region Fields

        /// <summary>
        /// 表名称
        /// </summary>
        public const string TableName = "user";

        #endregion

        #region Contructors

        public User() { }

        #endregion

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

        #region Methods

        public User Clone()
        {
            User entity = new User();
            entity.name = this.name;
            entity.password = this.password;
            entity.email = this.email;
            return entity;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion
    }
}
