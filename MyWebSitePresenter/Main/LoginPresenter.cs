using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWebSiteModel;
using MyWebSiteInterfaceDAL;
using MyWebSiteDALFactory;

namespace MyWebSitePresenter.Main
{
    public class LoginPresenter
    {
        private ILoginView _view;

        public LoginPresenter(ILoginView loginView)
        {
            this._view = loginView;
            this.Initialize();
        }

        private void Initialize()
        {

        }

        public User GetLoginUser()
        {
            User user = new User();
            user.Name = _view.UserName;
            user.Password = _view.Password;
            user.Email = _view.Email;

            IUser dal = UserFactory.Create();
            return dal.GetLoginUser(user);
        }
    }

    public interface ILoginView
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
