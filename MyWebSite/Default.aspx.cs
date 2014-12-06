﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MyWebSitePresenter;

namespace MyWebSite.View
{
    public partial class Default : PageBase, IDefaultView
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

        protected void Login_Click(object sender, EventArgs e)
        {
//            if (presenter.ExistUser())
//            {
//                this.Response.Write(@"<script language=javascript>window.open
//                    ('Login.aspx','newwindow','width=200,height=200')</script>");
//            }
//            else
//            {
//                Response.Write("222222222222");
//            }

            Response.Redirect(@"Main\Login.aspx");
        }
    }
}