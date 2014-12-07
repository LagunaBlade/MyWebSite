using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSiteModel;

namespace MyWebSiteInterfaceDAL
{
    public interface IUser
    {
        bool ExistUser(User user);

        User GetLoginUser(User user);
    }
}
