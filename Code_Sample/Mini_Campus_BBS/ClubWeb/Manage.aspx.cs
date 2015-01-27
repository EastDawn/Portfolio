using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manage : System.Web.UI.Page
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
    }
}