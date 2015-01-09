using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSitePresenter.Main;

namespace MyWebSite.Main
{
    public partial class Login : PageBase, ILoginView
    {
        private LoginPresenter presenter;

        public string UserName
        {
            get { return this.username.Value; }
            set { UserName = value; }
        }

        public string Password
        {
            get { return this.password.Value; }
            set { Password = value; }
        }

        public string Email
        {
            //get { return this.txtEmail; }
            get;
            set;
        }

        public Login()
        {
            this.presenter = new LoginPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.ServerClick += new EventHandler(Login_Click);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (presenter.GetLoginUser() != null)
            {
                //HttpCookie cookie = new HttpCookie("UserName");
                //cookie.Value = presenter.GetLoginUser();
                //HttpContext.Current.Response.Cookies.Add(cookie);
                Session["User"] = presenter.GetLoginUser();

                Response.Redirect(@"~\Default.aspx");
            }
            else
            {
                base.Alert(this, "用户名或密码错误，请重新输入！");
            }
        }
    }
}