using MyWebSiteModel;
using MyWebSiteInterfaceDAL;
using MyWebSiteDALFactory;

namespace MyWebSitePresenter
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

            IUser dal = UserFactory.Create();
            return dal.ExistUser(user);
        }
    }

    public interface IDefaultView
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}
