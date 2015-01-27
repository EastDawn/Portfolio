using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeedComment : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    static User useronline = new User();
    static Feed currentfeed = new Feed();
    static Comment[] comment;
    static int allcommentamount = 0;

    TextBox newcomment = new TextBox();
    Button submit = new Button();

    public class CommentLine
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public TextBox text = new TextBox();
        public Label commentor = new Label();
        public Label commenttime = new Label();
        public Label commentstatus = new Label();
        public Button delete = new Button();
        public Comment tempcomment;

        public CommentLine(Comment comment)
        {
            tempcomment = comment;
            text.TextMode = TextBoxMode.MultiLine;
            text.ReadOnly = true;
            text.Text = tempcomment.CommentText ;
            var temp = from u in db.User
                       where u.UserID == tempcomment.CommenterID
                       select u;
            foreach (User u in temp)
                commentor.Text = u.UserName;
            commenttime.Text = tempcomment.CommentTime.ToString();
            if (tempcomment.CommentStatus == true)
            {
                commentstatus.Text = "已发布";
                delete.Text = "删除评论";
            }
            else
            {
                commentstatus.Text = "已删除";
                delete.Text = "发布评论";
            }

            delete.Click += new EventHandler(delete_Click);
        }

        void delete_Click(object sender, EventArgs e)
        {
            tempcomment.CommentStatus = !tempcomment.CommentStatus;

            var temp = from c in db.Comment
                       where c.FeedID == tempcomment.FeedID && c.CommentNumber == tempcomment.CommentNumber
                       select c;
            foreach (Comment c in temp)
            {
                c.CommentStatus = !c.CommentStatus;
                tempcomment.CommentStatus = c.CommentStatus;
            }
            db.SubmitChanges();

            if (tempcomment.CommentStatus == true)
            {
                commentstatus.Text = "已发布";
                delete.Text = "删除评论";
            }
            else
            {
                commentstatus.Text = "已删除";
                delete.Text = "发布评论";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //登陆成功判定模块
        string[] pp = Request.Url.ToString().Split('?');

        string[] p1 = pp[1].Split('=');
        string[] p11;
        string p2;
        if (p1.Length > 2)
        {
            p11 = p1[1].Split('&');
            p2 = p1[2];
        }
        else
        {
            p11 = new string[1];
            p11[0] = p1[1];
            p2 = null;
        }

        if (p1 != null)
        {
            var Find = from temp in db.User
                       where temp.UserID == p11[0]
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

        //接收feed
        var feeddata = from c in db.Feed
                       where c.FeedID == int.Parse(p2)
                       select c;
        foreach (Feed f in feeddata)
        {
            currentfeed = f;
        }

        Label4.Text = currentfeed.Title;
        var tempsearch = from u in db.User
                         where u.UserID == currentfeed.PosterID
                         select u;
        foreach (User u in tempsearch)
        {
            Label5.Text = u.UserName;
        }

        Label6.Text = currentfeed.PostTime.ToString();
        if (currentfeed.FeedStatus == true)
        {
            Label7.Text = "已发布";
            Button1.Text = "删除";
        }
        else
        {
            Label7.Text = "已删除";
            Button1.Text = "发布";
        }

        if (currentfeed.ImageStatus == true)
        {
            Image2.Visible = true;
            Image2.ImageUrl = currentfeed.ImageID;
            Label8.Text = "已发布";
            Button2.Text = "删除";
        }
        else
        {
            Image2.Visible = false;
            Label8.Text = "已删除";
            Button2.Text = "发布";
        }

        TextBox1.Text = currentfeed.FeedText;
        TextBox1.ReadOnly = true;

        //根据用户身份展示不同页面
        if (useronline.Identification == true)
        {
            Label7.Visible = true;
            Button1.Visible = true;
            if (Image2.Visible == true)
            {
                Label8.Visible = true;
                Button2.Visible = true;
            }

            var commentdata = from c in db.Comment
                              where c.FeedID == currentfeed.FeedID
                              orderby c.CommentTime
                              select c;
            allcommentamount = 0;
            foreach (Comment c in commentdata)
            {
                allcommentamount++;
            }
            comment = new Comment[allcommentamount];

            int j = 0;
            foreach (Comment c in commentdata)
            {
                comment[j] = c;
                j++;
            }

            TableRow[] row = new TableRow[allcommentamount * 2 + 2];
            TableCell[] cell = new TableCell[allcommentamount * 4];

            CommentLine[] commentline = new CommentLine[allcommentamount];

            for (int k = 0; k < allcommentamount; k++)
            {
                commentline[k] = new CommentLine(comment[k]);
            }

            for (int k = 0; k < allcommentamount; k++)
            {
                cell[k * 4] = new TableCell();
                cell[k * 4 + 1] = new TableCell();
                cell[k * 4 + 2] = new TableCell();
                cell[k * 4 + 3] = new TableCell();

                row[k * 2] = new TableRow();
                row[k * 2 + 1] = new TableRow();

                cell[k * 4].Controls.Add(commentline[k].text);
                row[k * 2].Cells.Add(cell[k * 4]);

                cell[k * 4 + 1].Controls.Add(commentline[k].commentor);
                cell[k * 4 + 2].Controls.Add(commentline[k].commenttime);
                cell[k * 4 + 3].Controls.Add(commentline[k].commentstatus);
                cell[k * 4 + 3].Controls.Add(commentline[k].delete);
                row[k * 2 + 1].Cells.Add(cell[k * 4 + 1]);
                row[k * 2 + 1].Cells.Add(cell[k * 4 + 2]);
                row[k * 2 + 1].Cells.Add(cell[k * 4 + 3]);

                CommentListTable.Rows.Add(row[k * 2]);
                CommentListTable.Rows.Add(row[k * 2 + 1]);
            }

            newcomment.TextMode = TextBoxMode.MultiLine;
            submit.Text = "评论";

            TableCell[] lastcell = new TableCell[2];

            lastcell[0] = new TableCell();
            lastcell[0].Controls.Add(newcomment);
            lastcell[1] = new TableCell();
            lastcell[1].Controls.Add(submit);

            row[allcommentamount * 2] = new TableRow();
            row[allcommentamount * 2 + 1] = new TableRow();

            row[allcommentamount * 2].Cells.Add(lastcell[0]);
            row[allcommentamount * 2 + 1].Cells.Add(lastcell[1]);
            CommentListTable.Rows.Add(row[allcommentamount * 2]);
            CommentListTable.Rows.Add(row[allcommentamount * 2 + 1]);

        }
        else
        {
            var commentdata = from c in db.Comment
                              where c.FeedID == currentfeed.FeedID && c.CommentStatus == true
                              orderby c.CommentTime
                              select c;
            allcommentamount = 0;
            foreach (Comment c in commentdata)
            {
                allcommentamount++;
            }
            comment = new Comment[allcommentamount];

            int j = 0;
            foreach (Comment c in commentdata)
            {
                comment[j] = c;
                j++;
            }

            TableRow[] row = new TableRow[allcommentamount * 2 + 2];
            TableCell[] cell = new TableCell[allcommentamount * 3];

            CommentLine[] commentline = new CommentLine[allcommentamount];

            for (int k = 0; k < allcommentamount; k++)
            {
                commentline[k] = new CommentLine(comment[k]);
            }

            for (int k = 0; k < allcommentamount; k++)
            {
                cell[k * 3] = new TableCell();
                cell[k * 3 + 1] = new TableCell();
                cell[k * 3 + 2] = new TableCell();

                row[k * 2] = new TableRow();
                row[k * 2 + 1] = new TableRow();

                cell[k * 3].Controls.Add(commentline[k].text);
                row[k * 2].Cells.Add(cell[k * 4]);

                cell[k * 3 + 1].Controls.Add(commentline[k].commentor);
                cell[k * 3 + 2].Controls.Add(commentline[k].commenttime);
                row[k * 2 + 1].Cells.Add(cell[k * 4 + 1]);
                row[k * 2 + 1].Cells.Add(cell[k * 4 + 2]);

                CommentListTable.Rows.Add(row[k * 2]);
                CommentListTable.Rows.Add(row[k * 2 + 1]);
            }

            newcomment.TextMode = TextBoxMode.MultiLine;
            submit.Text = "评论";

            TableCell[] lastcell = new TableCell[2];

            lastcell[0] = new TableCell();
            lastcell[0].Controls.Add(newcomment);
            lastcell[1] = new TableCell();
            lastcell[1].Controls.Add(submit);

            row[allcommentamount * 2] = new TableRow();
            row[allcommentamount * 2 + 1] = new TableRow();

            row[allcommentamount * 2].Cells.Add(lastcell[0]);
            row[allcommentamount * 2 + 1].Cells.Add(lastcell[1]);
            CommentListTable.Rows.Add(row[allcommentamount * 2]);
            CommentListTable.Rows.Add(row[allcommentamount * 2 + 1]);
        }

        submit.Click += new EventHandler(submit_Click);
    }

    void submit_Click(object sender, EventArgs e)
    {
        Comment c = new Comment();

        c.FeedID = currentfeed.FeedID;
        c.CommenterID = useronline.UserID;
        c.CommentStatus = true;
        c.CommentText = newcomment.Text;
        c.CommentTime = DateTime.Now;

        db.Comment.InsertOnSubmit(c);
        db.SubmitChanges();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        currentfeed.FeedStatus = !currentfeed.FeedStatus;

        var temp = from c in db.Feed
                   where c.FeedID == currentfeed.FeedID
                   select c;
        foreach (Feed c in temp)
        {
            c.FeedStatus = !c.FeedStatus;
            currentfeed.FeedStatus = c.FeedStatus;
        }
        db.SubmitChanges();

        if (currentfeed.FeedStatus == true)
        {
            Label7.Text = "已发布";
            Button1.Text = "删除评论";
        }
        else
        {
            Label7.Text = "已删除";
            Button1.Text = "发布评论";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        currentfeed.ImageStatus = !currentfeed.ImageStatus;

        var temp = from c in db.Feed
                   where c.FeedID == currentfeed.FeedID
                   select c;
        foreach (Feed c in temp)
        {
            c.ImageStatus = !c.ImageStatus;
            currentfeed.ImageStatus = c.ImageStatus;
        }
        db.SubmitChanges();

        if (currentfeed.ImageStatus == true)
        {
            Label8.Text = "已发布";
            Button2.Text = "删除评论";
        }
        else
        {
            Label8.Text = "已删除";
            Button2.Text = "发布评论";
        }
    }
}