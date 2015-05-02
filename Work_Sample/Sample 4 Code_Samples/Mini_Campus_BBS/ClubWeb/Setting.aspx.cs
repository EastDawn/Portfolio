using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setting : System.Web.UI.Page
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
        TextBox1.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
        TextBox2.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
        TextBox1.Text = useronline.UserID;
        TextBox2.Text = useronline.UserName;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == useronline.Password)
        {
            TextBox3.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            if (TextBox4.Text == TextBox5.Text)
            {
                TextBox4.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
                TextBox5.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
                var temp = from c in db.User
                           where c.UserID == useronline.UserID
                           select c;
                foreach (User u in temp)
                {
                    u.Password = TextBox4.Text;
                    useronline.Password = TextBox4.Text;
                }
                db.SubmitChanges();
                Response.Redirect("~/Home.aspx?useronline=" + Request.QueryString["useronline"]);
            }
            else
            {
                TextBox5.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
                TextBox5.ToolTip = "密码不一致，请重新输入";
            }
        }
        else
        {
            TextBox3.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox3.ToolTip = "密码错误，请重新输入";
        }
    }
}