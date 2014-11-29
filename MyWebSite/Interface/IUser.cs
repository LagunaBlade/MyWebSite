using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebSite.Entity;

namespace MyWebSite.Interface
{
    public interface IUser 
    {
        bool ExistUser(User user);
    }
}