using System;
using System.Data.Linq.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        var Checka = from c1 in db.User
                     where c1.UserID == TextBox1.Text
                     select c1;

        var Checkb = from c2 in db.StudentReference
                     where c2.StudentID == TextBox1.Text
                     select c2;
       
        int i = 0;
        foreach (User c in Checka)
        {
            i++;
        }
        
        int j = 0;
        foreach (StudentReference c in Checkb)
        {
            j++;
        }

        if (i != 0 && j == 0)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "test逻辑出错";
            Label5.Text = "test逻辑出错";
            Label5.ForeColor = System.Drawing.Color.Red;
        }
        else if (i == 0 && j == 0)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "此学号无效";
            Label5.Text = "此学号无效";//e.g.3
            Label5.ForeColor = System.Drawing.Color.Red;
        }
        else if (i == 0 && j != 0)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            TextBox1.ToolTip = "test可以注册";
            Label5.Text = "test可以注册";//e.g.2011131110;2011131111
            Label5.ForeColor = System.Drawing.Color.Green;
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
            }
        }
        else if (i != 0 && j != 0)//两个表中都查找出该学号
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "此用户已存在";
            Label5.Text = "此用户已存在";//e.g.2011131100
            Label5.ForeColor = System.Drawing.Color.Red;
        }

        /*if(i!=0)
        {
            TableUser[] Check1 = new TableUser[i];
            for (; i > 0;i-- )
                Check1[i-1] = new TableUser();     //bug解决：对于Check1数组每一个元素都要调用构造函数进行初始化
        
            i = 0;
            foreach (User c in Checka)
            {
                Check1[i].userid = c.UserID;
                Check1[i].username = c.UserName;
                Check1[i].password = c.Password;
                Check1[i].identification = c.Identification;
                Check1[i].userstatus = c.UserStatus;
                i++;
            }
        }

        if(j!=0)
        {
            TableStudentReference[] Check2 = new TableStudentReference[j];
            for (; j > 0;j-- )
                Check2[j-1] = new TableStudentReference();     //bug解决：对于Check2数组每一个元素都要调用构造函数进行初始化
        
            j = 0;
            foreach (StudentReference c in Checkb)
            {
                Check2[j].studentid = c.StudentID;
                Check2[j].studentname = c.StudentName;
                j++;
            }
        }*/

        if (TextBox1.Text == "" || TextBox2.Text == "" || IsValid == false)
            Button1.Enabled = false;
        else
            Button1.Enabled = true;

       /* SqlConnection db = new SqlConnection(@"Data source=.;AttachDbFilename=F:\Web\Program\ClubWeb\App_Data\ClubWebDB.mdf;Integrated Security=True;");
        //db.Open();
        string Check = "select UserID from User where UserID ='"+TextBox1.Text+"'";
        SqlCommand command1 = new SqlCommand(Check, db);
        object Check1 = command1.ExecuteScalar();
        Check = "select StudentID from StudentReference where StudentID ='" + TextBox1.Text + "'";
        SqlCommand command2 = new SqlCommand(Check, db);
        object Check2 = command2.ExecuteScalar();
        db.Close();

        if (Check1 != null && Check2 == null)
            Label5.Text = "test逻辑出错";
        else if (Check1 == null && Check2 == null)
            Label5.Text = "此学号无效";//3
        else if (Check1 == null && Check2 != null)
            Label5.Text = "test可以注册";//2011131110;2011131111
        else if (Check1 != null && Check2 != null)//两个表中都查找出该学号
            Label5.Text = "此用户已存在";//2011131100
        * */
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        var temp = from t in db.StudentReference
                    where t.StudentID == TextBox1.Text
                    select t;
        var Check = from c in temp
                     where c.StudentName == TextBox2.Text
                     select c;

        int i = 0;
        foreach(StudentReference c in Check)
        {
            i++;
        }

        if (i != 0)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            TextBox1.ToolTip = "test通过身份验证";
            Label6.Text = "test通过身份验证";
            Label6.ForeColor = System.Drawing.Color.Green;
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                TextBox1.ReadOnly = true;
                TextBox2.ReadOnly = true;
            }
        }
        else if (i == 0)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "姓名与学号不匹配";
            Label6.Text = "姓名与学号不匹配";
            Label6.ForeColor = System.Drawing.Color.Red;
        }

        if (TextBox1.Text == "" || TextBox2.Text == "" || IsValid == false)
            Button1.Enabled = false;
        else
            Button1.Enabled = true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Label5.Text == "test可以注册" && Label6.Text == "test通过身份验证" && TextBox3.Text != "" && TextBox3.Text != "" && IsValid == true)
        {
            User u = new User();
            u.UserID = TextBox1.Text;
            u.UserName = TextBox2.Text;
            u.Password = TextBox3.Text;
            u.UserStatus = true;
            u.Identification = false;
            db.User.InsertOnSubmit(u);
            db.SubmitChanges();
            Response.Redirect("~/Login.aspx?userid="+TextBox1.Text);
        }
        else
        {
            ;
        }
    }
}