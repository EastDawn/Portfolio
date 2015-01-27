using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    static User useronline = new User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString() != "")
        {
            TextBox1.Text = Request.QueryString["userid"];
        }
    }
   
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        useronline.UserID = TextBox1.Text;
        var c1 = from temp1 in db.User
                 where temp1.UserID == useronline.UserID
                 select temp1;
        int i = 0;
        foreach (User u in c1)
        {
            i++;
        }
        if (i == 1)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0x99,0xff,0x66);
            TextBox1.ToolTip = "test找到该用户";
        }
        else 
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "没有找到该用户，请重新输入学号";
        }
        if (TextBox1.Text == "")
            Button1.Enabled = false;
        else
            Button1.Enabled = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        useronline.UserID = TextBox1.Text;
        useronline.Password = TextBox2.Text;
        var c1 = from temp1 in db.User
                 where temp1.UserID == useronline.UserID
                 select temp1;
        var c2 = from temp2 in c1
                 where temp2.Password == useronline.Password
                 select temp2;
        int i = 0;
        foreach (User u in c1)
        {
            i++;
        }
        int j = 0;
        foreach (User u in c2)
        {
            j++;
        }
        if (i == 1 && j == 1)
        {
            Response.Redirect("~/Home.aspx?useronline=" + TextBox1.Text);
        }
        else if (i == 1 && j == 0)
        {
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox2.ToolTip = "密码错误";
        }
        else if(i == 0) 
        {
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox2.ToolTip = "用户名错误或没有该用户";
        }
    }
}