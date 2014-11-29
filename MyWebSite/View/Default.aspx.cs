using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MyWebSite.Control;

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

        }

        public Default()
        {
            this.presenter = new DefaultPresenter(this);
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Response.Write("111111111111");
        }
    }
}