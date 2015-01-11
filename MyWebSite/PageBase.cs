using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.UI;
using MyWebSiteModel;

namespace MyWebSite
{
    public class PageBase : System.Web.UI.Page
    {
        public PageBase()
        {

        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            if (Request.Url.AbsolutePath != "/Main/Login.aspx")
            {
                //if (Session["User"] == null)
                //{
                //    base.Response.Redirect("~/Main/Login.aspx");
                //}
            }
        }  

        #region 用户信息Cookie

        private User _ui;

        protected virtual User Ui
        {
            get
            {
                if (Session["UserInfo"] != null)
                    _ui = (User)Session["UserInfo"];
                else
                {
                    if (Request.Cookies["UserName"] != null)
                    {
                        //_ui = UsersBLL.GetUserByUserName(Request.Cookies["UserName"].Value);
                        Session["UserInfo"] = _ui;
                    }
                }
                return _ui;
            }
            set { _ui = value; }
        }

        #endregion

        #region Alert提示信息

        /// <summary>
        /// 仅提示信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public void Alert(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "alert('" + msg + "');", true);
        }

        /// <summary>
        /// 提示并返回
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public void AlertAndBack(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + msg + "'); history.back() ", true);
        }

        /// <summary>
        /// 提示并跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转地址</param>
        public void AlertRedirectUrl(System.Web.UI.Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "", "alert('" + msg + "'); window.parent.location.href='" + url + "'", true);
        }

        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public void AlertConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }

        /// <summary>
        /// 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="yesUrl">点“是”的跳转路径</param>
        /// <param name="noUrl">点“否”的跳转路径</param>
        public void AlertConfirm(System.Web.UI.Page page, string msg, string yesUrl, string noUrl)
        {
            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "提示信息",
                       " if( window.confirm('" + msg + "'))"
                        + " { window.location.href='" + yesUrl + "' } "
                        + " else {  window.location.href='" + noUrl + "' } "
                   , true);
        }

        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }

        #endregion

        #region 字符串处理

        /// <summary>
        ///  加密字符,防止敏感信息外泄.
        /// </summary>
        /// <param name="str">加密字符串</param>
        /// <returns></returns>
        public string StringEncodeBase(string str)
        {
            string strResult = "";
            if (str != "" && str != null)
            {
                strResult = Convert.ToBase64String(System.Text.ASCIIEncoding.Default.GetBytes(str));
            }
            return strResult;
        }

        /// <summary>
        /// 解密字符,防止敏感信息外泄.
        /// </summary>
        /// <param name="s">解密字符串</param>
        /// <returns></returns>
        public string StringDecodeBase(string str)
        {
            string strResult = "";
            if (str != "" && str != null)
            {
                strResult = System.Text.ASCIIEncoding.Default.GetString(Convert.FromBase64String(str));
            }
            return strResult;
        }

        /// <summary>
        /// 字符串截取方法
        /// </summary>
        /// <param name="len">大于len长度时截取</param>
        /// <param name="str">截取str字符串</param>
        /// <returns></returns>
        public string StringFormat(int len, string str)
        {
            return (str.Length > len) ? str.Substring(0, len) + " ..." : str;
        }

        /// <summary>
        /// 字符串截取方法
        /// </summary>
        /// <param name="len">大于len长度时截取</param>
        /// <param name="num">截取num长</param>
        /// <param name="str">截取str字符串</param>
        /// <returns></returns>
        public string StringFormat(int len, int num, string str)
        {
            return (str.Length > len) ? str.Substring(0, len) + " ..." : str;
        }

        /// <summary>
        /// 替换字符串里的单引号，主要应用于SQl语句中。
        /// </summary>
        /// <param name="theValue">要替换的字符串</param>
        /// <returns>替换后的新值</returns>
        public static string ReplaceString(string theValue)
        {
            if (theValue != null) theValue = theValue.Replace("'", "''");
            return theValue;
        }

        #endregion

        #region  文件处理

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="path">相对路径</param>
        public void DownloadFile(string path)
        {
            string filePath = Server.MapPath("../" + path);
            if (!File.Exists(filePath))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('文件不存在！'); history.back()", true);
                return;
            }
            new FileInfo(filePath).Attributes = FileAttributes.Normal;
            FileStream r = new FileStream(filePath, FileMode.Open);
            //设置基本信息
            Response.Buffer = false;
            Response.AddHeader("Connection", "Keep-Alive");
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(HttpUtility.UrlEncode(filePath)));
            Response.AddHeader("Content-Length", r.Length.ToString());
            while (true)
            {
                //开辟缓冲区空间
                byte[] buffer = new byte[1024];
                //读取文件的数据
                int leng = r.Read(buffer, 0, 1024);
                if (leng == 0)//到文件尾，结束
                    break;
                if (leng == 1024)//读出的文件数据长度等于缓冲区长度，直接将缓冲区数据写入
                    Response.BinaryWrite(buffer);
                else
                {
                    //读出文件数据比缓冲区小，重新定义缓冲区大小，只用于读取文件的最后一个数据块
                    byte[] b = new byte[leng];
                    for (int i = 0; i < leng; i++)
                        b[i] = buffer[i];
                    Response.BinaryWrite(b);
                }
            }
            r.Close();//关闭下载文件
            Response.End();//结束文件下载
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="sourcePath">源路径</param>
        /// <param name="destPath">目标路径</param>
        /// <param name="overwrite">OverWrite参数设为true，如果文件已存在，将会覆盖文件</param>
        public void CopyFile(string sourcePath, string destPath, bool overwrite)
        {
            File.Copy(@sourcePath, @destPath, overwrite);
        }


        #endregion

        #region 时间处理

        /// <summary>
        /// 时间比较大小
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>开始时间大于等于结束返回True; 否则返回False</returns>
        public bool TimeCompare(string beginTime, string endTime)
        {
            DateTime time1 = DateTime.Parse(beginTime);
            DateTime time2 = DateTime.Parse(endTime);
            if (time1 >= time2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 时间相减
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>返回TimeSpan; span.Days:天数、span.Hours：小时、span.Minutes分钟、span.Seconds：秒数</returns>
        public TimeSpan TimeMinus(string beginTime, string endTime)
        {
            DateTime dtone = Convert.ToDateTime(endTime);
            DateTime dtwo = Convert.ToDateTime(beginTime);
            TimeSpan span = dtone.Subtract(dtwo);
            return span;
        }

        /// <summary>
        /// 某年共多少天
        /// </summary>
        /// <param name="year">某年</param>
        /// <returns>天数</returns>
        public int TimeGetDayByYear(int year)
        {
            int days = 0;
            for (int i = 0; i < 12; i++)
            {
                days += DateTime.DaysInMonth(year, i);
            }
            return days;
        }

        /// <summary>
        /// 获取本周开始时间和结束时间
        /// </summary>
        /// <returns>返回string数组</returns>
        public string[] TimeThisWeek()
        {
            string[] time = new string[2];
            int nowWeek = Convert.ToInt32(DateTime.Now.DayOfWeek);

            time[0] = DateTime.Now.AddDays(1 - nowWeek).ToString("yyyy-MM-dd");
            time[1] = DateTime.Now.AddDays(7 - nowWeek).ToString("yyyy-MM-dd");
            return time;
        }

        /// <summary>
        /// 获取本月开始时间和结束时间
        /// </summary>
        /// <returns>返回string数组</returns>
        public string[] TimeThisMonth()
        {
            string[] time = new string[2];
            DateTime bTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
            time[0] = bTime.ToString("yyyy-MM-01");
            time[1] = bTime.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            return time;
        }

        #endregion

        #region 正则表达式验证

        /// <summary>
        /// 正则验证数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsNumeric(string str)
        {
            Regex reg1 = new Regex(@"^[-]?/d+[.]?/d*$");
            return reg1.IsMatch(str);
        }

        //  c#验证网络地址URL
        public bool ValidateUrl(string strUrl)
        {
            string patten = @"^http://(www/.){0,1}.+/.(com|net|cn)$"; //正则表达式
            Regex r = new Regex(patten);           //声明一个Regex对象
            Match m = r.Match(strUrl);            //使用Match方法进行匹配
            if (m.Success)      //匹配成功
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 随机数
        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <returns></returns>
        public static string RandomnAlpha(int i)
        {
            string oriStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstyuwxyz";
            string reStr = "";
            Random rd = new Random();
            for (int k = 0; k < i; k++)
            {
                reStr += oriStr[rd.Next(0, oriStr.Length)].ToString();
            }
            return reStr;
        }

        #endregion

        #region 获取系统数据

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string myIP;
            System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            myIP = addressList[0].ToString();
            return myIP;
        }

        #endregion

        #region 打开窗口

        /// <summary>
        /// 打开一个.net窗口口，并且这个.net窗口位于最前面
        /// </summary>
        /// <param name="page">提用的页面</param>
        /// <param name="URL">要打开的URL</param>
        /// <param name="PageName">要打开页面的名称</param>
        /// <param name="Win_Width">窗口宽度</param>
        /// <param name="Win_Hight">窗口高度</param>
        /// <param name="Left">窗口左侧位置</param>
        /// <param name="Top">窗口右侧位置</param>
        /// <param name="CenterFlag">是否右中 yes/no</param>
        /// <param name="Status">是否显示状态栏 yes/no</param>
        /// <param name="ParentFlag">true:不关闭弹出窗口，将不能操作父窗口 false 可以操作父窗口</param>
        public static void OpenNewWindow(Page page,string URL,string PageName,string Win_Width,string Win_Hight,string Left,string Top,string CenterFlag,string Status,bool ParentFlag)
        {
 
            string scriptstr="";
            if(ParentFlag)               
            {
                scriptstr="<script language=javascript>showModalDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:"+Left+"px;dialogTop:"+Top+"px;center:"+CenterFlag.ToString()+";help:no;resizeable:yes;status:"+Status+"')</script>";
            }
            else
            {
                scriptstr="<script language=javascript>showModelessDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:"+Left+"px;dialogTop:"+Top+"px;center:"+CenterFlag.ToString()+";help:no;resizeable:yes;status:"+Status+"')</script>";
            }
            page.Response.Write(scriptstr);
        }
        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page">提用的页面</param>
        /// <param name="URL">要打开的URL</param>
        /// <param name="PageName">要打开页面的名称</param>
        /// <param name="Win_Width">窗口宽度</param>
        /// <param name="Win_Hight">窗口高度</param>
        /// <param name="Left">窗口左侧位置</param>
        /// <param name="Top">窗口右侧位置</param>
        /// <param name="CenterFlag">是否右中 yes/no</param>
        /// <param name="ParentFlag">true:不关闭弹出窗口，将不能操作父窗口 false 可以操作父窗口</param>
        public static void OpenNewWindow(Page page,string URL,string PageName,string Win_Width,string Win_Hight,string Left,string Top,string CenterFlag,bool ParentFlag)
        {
            string scriptstr="";
            if(ParentFlag)               
            {
                scriptstr="<script language=javascript>showModalDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:"+Left+"px;dialogTop:"+Top+"px;center:"+CenterFlag+";help:no;resizeable:yes;status:no')</script>";
            }
            else
            {
                scriptstr="<script language=javascript>showModelessDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:"+Left+"px;dialogTop:"+Top+"px;center:"+CenterFlag+";help:no;resizeable:yes;status:no')</script>";
            }
            page.Response.Write(scriptstr);
        }
 
        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page">提用的页面</param>
        /// <param name="URL">要打开的URL</param>
        /// <param name="PageName">要打开页面的名称</param>
        /// <param name="Win_Width">窗口宽度</param>
        /// <param name="Win_Hight">窗口高度</param>
        /// <param name="Left">窗口左侧位置</param>
        /// <param name="Top">窗口右侧位置</param>
        /// <param name="ParentFlag">true:不关闭弹出窗口，将不能操作父窗口 false 可以操作父窗口</param>
        public static void OpenNewWindow(Page page,string URL,string PageName,string Win_Width,string Win_Hight,string Left,string Top,bool ParentFlag)
        {
            string scriptstr="";
            if(ParentFlag)               
            {
                scriptstr="<script language=javascript>showModalDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:"+Left+"px;dialogTop:"+Top+"px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            else
            {
                scriptstr="<script language=javascript>showModelessDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:"+Left+"px;dialogTop:"+Top+"px;center:no;help:no;resizeable:yes;status:no')</script>";
       
            }
            page.Response.Write(scriptstr);
        }
 
        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page">提用的页面</param>
        /// <param name="URL">要打开的URL</param>
        /// <param name="PageName">要打开页面的名称</param>
        /// <param name="Win_Width">窗口宽度</param>
        /// <param name="Win_Hight">窗口高度</param>
        /// <param name="ParentFlag">true:不关闭弹出窗口，将不能操作父窗口 false 可以操作父窗口</param>
        public static void OpenNewWindow(Page page,string URL,string PageName,string Win_Width,string Win_Hight,bool ParentFlag)
        {
            string scriptstr="";
            if(ParentFlag)               
            {
                scriptstr="<script language=javascript>showModalDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            else
            {
                scriptstr="<script language=javascript>showModelessDialog('"+URL+"','"+PageName+"','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";       
            }
            page.Response.Write(scriptstr);
        }
        /// <summary>
        /// 打开一个窗口，并且这个窗口位于最前面，不关闭，将不能操作父窗口
        /// </summary>
        /// <param name="page">提用的页面</param>
        /// <param name="URL">要打开的URL</param>
        /// <param name="Win_Width">窗口宽度</param>
        /// <param name="Win_Hight">窗口高度</param>
        /// <param name="ParentFlag">true:不关闭弹出窗口，将不能操作父窗口 false 可以操作父窗口</param>
        public static void OpenNewWindow(Page page,string URL,string Win_Width,string Win_Hight,bool ParentFlag)
        {
            string scriptstr="";
            if(ParentFlag)               
            {
                scriptstr="<script language=javascript>showModalDialog('"+URL+"','','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";
            }
            else
            {
                scriptstr="<script language=javascript>showModelessDialog('"+URL+"','','dialogWidth:"+Win_Width+"px;"
                    +"dialogHeight:"+Win_Hight+"px;dialogLeft:0px;dialogTop:0px;center:no;help:no;resizeable:yes;status:no')</script>";       
            }
            page.Response.Write(scriptstr);
        }
        #endregion
    }
}