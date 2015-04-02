using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FeedList : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    static User useronline = new User();

    public class FeedLine 
    {
        DataClassesDataContext db = new DataClassesDataContext();

        public Label selectbox = new Label();
        public HyperLink feedlink = new HyperLink();
        public Label posttime = new Label();
        public Label feedstatus = new Label();
        public Button look = new Button();
        public Button delete = new Button();

        Feed tempfeed;

        public FeedLine(Feed feed)
        {
            tempfeed = feed;
            selectbox.Text = tempfeed.Title;
            feedlink.Text = tempfeed.Title;
            feedlink.NavigateUrl = "~/FeedComment.aspx?useronline=" + useronline.UserID + "&feedid=" + tempfeed.FeedID;
            feedlink.ToolTip = tempfeed.FeedText;
            look.Text = "查看";
            look.PostBackUrl = "~/FeedComment.aspx?useronline=" + useronline.UserID + "&feedid="+ tempfeed.FeedID;
            look.ToolTip = tempfeed.FeedText;
            posttime.Text = tempfeed.PostTime.ToString();

            if (tempfeed.FeedStatus == true)
            {
                feedstatus.Text = "已发布";
                delete.Text = "删除";
            }
            else
            {
                feedstatus.Text = "已禁止";
                delete.Text = "发布";
            }
            delete.Click += new EventHandler(delete_Click);
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            //页面状态取反
            tempfeed.FeedStatus = !tempfeed.FeedStatus;
            //服务器状态取反
            var temp = from c in db.Feed
                       where c.FeedID == tempfeed.FeedID
                       select c;
            foreach (Feed f in temp)
            {
                f.FeedStatus = !f.FeedStatus;
                tempfeed.FeedStatus = f.FeedStatus;
            }
            db.SubmitChanges();

            //修改页面对应项的内容
            if (tempfeed.FeedStatus == true)
            {
                feedstatus.Text = "已发布";
                delete.Text = "删除";
            }
            else
            {
                feedstatus.Text = "已禁止";
                delete.Text = "发布";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string[] pp = Request.Url.ToString().Split('?');

        string[] p1 = pp[1].Split('=');
        //登陆成功判定模块
        if (p1 != null)
        {
            var Find = from temp in db.User
                       where temp.UserID == p1[1]
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

        //根据用户身份展示不同页面
        if (useronline.Identification == true)
        {
            Button1.Visible = true;
            Button2.Visible = true;

            //读取数据库中feed表,保存在数组变量里
            var allfeeddata = from temp in db.Feed
                              orderby temp.PostTime descending
                              select temp;
            int allfeedamount = 0;
            foreach (Feed f in allfeeddata)
            {
                allfeedamount++;
            }

            FeedLine[] feedline = new FeedLine[allfeedamount];
            int j = 0;
            foreach (Feed f in allfeeddata)
            {
                feedline[j] = new FeedLine(f);
                j++;
            }

            //创建动态表格
            TableCell firstline1 = new TableCell();
            firstline1.Text = "标题";
            TableCell firstline2 = new TableCell();
            firstline2.Text = "发布时间";
            TableCell firstline3 = new TableCell();
            firstline3.Text = "状态/操作";

            TableCell[] cellcheckbox = new TableCell[allfeedamount];
            TableCell[] cellposttime = new TableCell[allfeedamount];
            TableCell[] cellopt = new TableCell[allfeedamount];
            TableRow[] row = new TableRow[allfeedamount+1];

            for (int k = 0; k < allfeedamount; k++)
            {
                cellcheckbox[k] = new TableCell();
                cellcheckbox[k].Controls.Add(feedline[k].selectbox);

                cellposttime[k] = new TableCell();
                cellposttime[k].Controls.Add(feedline[k].posttime);

                cellopt[k] = new TableCell();
                cellopt[k].Controls.Add(feedline[k].feedstatus);
                cellopt[k].Controls.Add(feedline[k].look);
                cellopt[k].Controls.Add(feedline[k].delete);
            }

            row[0] = new TableRow();
            row[0].Cells.Add(firstline1);
            row[0].Cells.Add(firstline2);
            row[0].Cells.Add(firstline3);
            FeedListTable.Rows.Add(row[0]);

            for (int k = 0; k < allfeedamount; k++)
            {
                row[k+1] = new TableRow();
                row[k+1].Cells.Add(cellcheckbox[k]);
                row[k+1].Cells.Add(cellposttime[k]);
                row[k+1].Cells.Add(cellopt[k]);
                FeedListTable.Rows.Add(row[k+1]);
            }
        }
        else
        {
            //读取数据库中feed表,保存在数组变量里
            var allfeeddata = from temp in db.Feed
                              where temp.FeedStatus == true
                              orderby temp.PostTime descending
                              select temp;
            int allfeedamount = 0;
            foreach (Feed f in allfeeddata)
            {
                allfeedamount++;
            }

            FeedLine[] feedline = new FeedLine[allfeedamount];
            int j = 0;
            foreach (Feed f in allfeeddata)
            {
                feedline[j] = new FeedLine(f);
                j++;
            }

            //创建动态表格
            TableCell firstline1 = new TableCell();
            firstline1.Text = "标题";
            TableCell firstline2 = new TableCell();
            firstline2.Text = "发布时间";

            TableCell[] cellcheckbox = new TableCell[allfeedamount];
            TableCell[] cellposttime = new TableCell[allfeedamount];
            TableRow[] row = new TableRow[allfeedamount + 1];

            for (int k = 0; k < allfeedamount; k++)
            {
                cellcheckbox[k] = new TableCell();
                cellcheckbox[k].Controls.Add(feedline[k].feedlink);

                cellposttime[k] = new TableCell();
                cellposttime[k].Controls.Add(feedline[k].posttime);
            }

            row[0] = new TableRow();
            row[0].Cells.Add(firstline1);
            row[0].Cells.Add(firstline2);
            FeedListTable.Rows.Add(row[0]);

            for (int k = 0; k < allfeedamount; k++)
            {
                row[k+1] = new TableRow();
                row[k + 1].Cells.Add(cellcheckbox[k]);
                row[k+1].Cells.Add(cellposttime[k]);
                FeedListTable.Rows.Add(row[k+1]);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Post.aspx?useronline=" + Request.QueryString["useronline"]);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Post.aspx?useronline=" + Request.QueryString["useronline"]);
    }
}