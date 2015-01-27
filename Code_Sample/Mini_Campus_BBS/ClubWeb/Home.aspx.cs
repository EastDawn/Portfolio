using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    static User useronline = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        //登陆成功判定模块
        if (Request.QueryString.ToString() != "")
        {
            var Find = from temp in db.User
                       where temp.UserID == Request.QueryString["useronline"]
                       select temp;

            int i = 0;
            foreach (User c in Find)
            {
                i++;
            }
            if (i == 1)
            {
                i = 0;
                foreach (User c in Find)
                {
                    useronline.UserID = c.UserID;
                    useronline.UserName = c.UserName;
                    useronline.Password = c.Password;
                    useronline.Identification = c.Identification;
                    useronline.UserStatus = c.UserStatus;
                    i++;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
                //Response.Redirect("~/Login.aspx?useronline=" + Request.QueryString["useronline"]);
            }
        }

        if (useronline.Identification == false)
        {
            Button1.Visible = false;
            Button2.Visible = true;
            Button2.Text = "社团墙";
        }
        else if (useronline.Identification == true)
        {
            Button1.Visible = true;
            Button2.Text = "社团墙管理";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manage.aspx?useronline=" + Request.QueryString["useronline"]);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FeedList.aspx?useronline=" + Request.QueryString["useronline"]);
    }
}