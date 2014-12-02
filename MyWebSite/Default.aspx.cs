using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MyWebSitePresenter;

namespace MyWebSite.View
{
    public partial class Default : System.Web.UI.Page, IDefaultView
    {
        private DefaultPresenter presenter;

        public string UserName
        {
            //get { return this.textBox1; }
            get;
            set;
        }

        public string Password
        {
            //get { return this.textBox1; }
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoginButton.Click += new EventHandler(Button_Click);
        }

        public Default()
        {
            this.presenter = new DefaultPresenter(this);
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (presenter.ExistUser())
            {
                Response.Write("111111111111");
            }
            else
            {
                Response.Write("222222222222");
            }
        }
    }
}