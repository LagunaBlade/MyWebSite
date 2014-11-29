using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebSite.Entity;
using MyWebSite.Interface;
using MyWebSite.DAL;

namespace MyWebSite.Control
{
    public class DefaultPresenter
    {
        private IDefaultView _view;

        public DefaultPresenter(IDefaultView testMvpView) 
        {
            this._view = testMvpView;
            this.Initialize();
        }

        private void Initialize()
        {

        }

        public bool ExistUser()
        {
            User user = new User();
            user.UserName = _view.UserName;
            user.Password = _view.Password;

            IUser dal = DALFactory.UserFactory.Create();
            return dal.ExistUser(user);
        }
    }

    public interface IDefaultView
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}