using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
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
                    useronline = c;
                    i++;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        Button1.Enabled = false;
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length <= 50)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            TextBox1.ToolTip = "test";
        }
        else 
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "标题超出长度，请缩短至50个字符以内";
        }

        if (TextBox1.Text.Length > 0)
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            TextBox1.ToolTip = "test";
        }
        else 
        {
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox1.ToolTip = "标题不能为空";
        }

        if (TextBox1.Text.Length <= 50 && TextBox1.Text.Length > 0 && TextBox2.Text.Length <= 500 && TextBox2.Text.Length > 0)
            Button1.Enabled = true;
        else
            Button1.Enabled = false;
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (TextBox2.Text.Length <= 500)
        {
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            TextBox2.ToolTip = "test";
        }
        else
        {
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox2.ToolTip = "正文超出长度，请缩短至500个字符以内";
        }

        if (TextBox2.Text.Length > 0)
        {
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
            TextBox2.ToolTip = "test";
        }
        else
        {
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox2.ToolTip = "正文不能为空";
        }

        if (TextBox1.Text.Length <= 50 && TextBox1.Text.Length > 0 && TextBox2.Text.Length <= 500 && TextBox2.Text.Length > 0)
            Button1.Enabled = true;
        else
            Button1.Enabled = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length <= 50 && TextBox1.Text.Length > 0 && TextBox2.Text.Length <= 500 && TextBox2.Text.Length > 0)
        {
            if (FileUpload1.PostedFile.FileName != "")
            {
                Feed newfeed = new Feed();
                newfeed.Title = TextBox1.Text;
                newfeed.FeedText = TextBox2.Text;
                newfeed.PosterID = useronline.UserID;
                newfeed.PostTime = DateTime.Now;
                newfeed.FeedStatus = true;
                db.Feed.InsertOnSubmit(newfeed);
                db.SubmitChanges();

                var temp0 = from c0 in db.Feed
                            where c0.Title == newfeed.Title
                            select c0;
                var temp1 = from c1 in temp0
                            where c1.FeedText == newfeed.FeedText
                            select c1;
                Feed currentfeed = new Feed();
                foreach (Feed f in temp1)
                {
                    currentfeed.FeedID = f.FeedID;
                }
                if (Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower() != ".jpg" && Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower() != ".bmp" && Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower() != ".gif" && Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower() != ".png")
                {
                    FileUpload1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
                    FileUpload1.ToolTip = "文件格式错误";
                }
                else
                {
                    if (FileUpload1.PostedFile.ContentLength > 1024000)
                    {
                        FileUpload1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
                        FileUpload1.ToolTip = "文件太大，不能上传";
                    }
                    else
                    {
                        try
                        {
                            FileUpload1.PostedFile.SaveAs(Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "FeedImage"), currentfeed.FeedID.ToString() + Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower().ToString()));

                            var temp3 = from f in db.Feed
                                        where f.FeedID == currentfeed.FeedID
                                        select f;

                            foreach (Feed f in temp3)
                            {
                                f.ImageID = Path.Combine(Path.Combine(Request.PhysicalApplicationPath, "FeedImage"), currentfeed.FeedID.ToString());
                                f.ImageStatus = true;
                            }
                            db.SubmitChanges();

                            FileUpload1.BackColor = System.Drawing.Color.FromArgb(0x99, 0xff, 0x66);
                            FileUpload1.ToolTip = "上传成功";
                            Response.Redirect("~/FeedList.aspx?useronline=" + Request.QueryString["useronline"]);
                        }
                        catch (Exception ee)
                        {
                            FileUpload1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
                            FileUpload1.ToolTip = "上传过程出现错误";
                        }

                        //这里应该是有一个逻辑上的bug，下面这句跳转有一个问题：不论是否有图片、是否上传成功，都会跳转到feedlist页面
                        //Response.Redirect("~/FeedList.aspx?useronline=" + Request.QueryString["useronline"]);
                    }
                }
            }
            else
            {
                Feed newfeed = new Feed();
                newfeed.Title = TextBox1.Text;
                newfeed.FeedText = TextBox2.Text;
                newfeed.PosterID = useronline.UserID;
                newfeed.PostTime = DateTime.Now;
                newfeed.FeedStatus = true;
                newfeed.ImageStatus = false;
                db.Feed.InsertOnSubmit(newfeed);
                db.SubmitChanges();

                Response.Redirect("~/FeedList.aspx?useronline=" + Request.QueryString["useronline"]);
            }                   
        }
        else
        {
            Button1.Enabled = false;
            TextBox1.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
            TextBox2.BackColor = System.Drawing.Color.FromArgb(0xff, 0x99, 0x99);
        }
    }
}