using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class NoticeContent_DetailView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Table noticeBoard = new Table();
            noticeBoard.Width = 600;
            noticeBoard.BorderWidth = 1;
            noticeBoard.BorderColor = System.Drawing.Color.Black;

            TableRow title = new TableRow();
            TableCell title1 = new TableCell();
            title1.BorderStyle = BorderStyle.None;
            title1.BorderWidth = 1;
            title1.BackColor = System.Drawing.Color.Olive;
            title1.ForeColor = System.Drawing.Color.White;
            title1.Font.Size = 20;
            title1.Font.Bold = true;            
            title1.Font.Name = "Times New Roman";
            title1.HorizontalAlign = HorizontalAlign.Center;
            Label label = new Label();
            SqlDataReader reader1 = DataAccess.GetNoticeBoardInfo(Request.QueryString["NBName"]);
            reader1.Read();
            label.Text = reader1.GetString(2);
            //"Synapse";        //here set the Notice Board text from database.                
            title1.Controls.Add(label);
            title.Controls.Add(title1);
            noticeBoard.Controls.Add(title);

            //Add Space in Middle
            TableRow space = new TableRow();
            TableCell space1 = new TableCell();
            Label label1 = new Label();
            label1.Height = 16;
            space1.Controls.Add(label1);
            space.Controls.Add(space1);
            noticeBoard.Controls.Add(space);
            try
            {
                using (SqlDataReader reader = DataAccess.GetNotices(reader1.GetInt32(0)))
                {

                    while (reader.Read())
                    {
                        TableRow notices = new TableRow();
                        TableCell cell = new TableCell();
                        Table notice = new Table();
                        notice.BorderWidth = 2;
                        notice.BorderStyle = BorderStyle.Outset;
                        notice.Width = 560;
                        notice.HorizontalAlign = HorizontalAlign.Center;

                        TableRow sub = new TableRow();

                        TableCell sub1 = new TableCell();
                        sub1.ForeColor = System.Drawing.Color.Brown;
                        sub1.Font.Size = 16;
                        sub1.Font.Bold = true;
                        sub1.Width = 450;

                        Label L_Sub = new Label();
                        L_Sub.Text = reader.GetString(2);
                        sub1.Controls.Add(L_Sub);
                        sub.Controls.Add(sub1);

                        TableCell date = new TableCell();
                        date.HorizontalAlign = HorizontalAlign.Right;
                        Label L_Date = new Label();
                        L_Date.Text = reader.GetDateTime(4).ToString();
                        date.Controls.Add(L_Date);
                        sub.Controls.Add(date);

                        TableRow body = new TableRow();
                        TableCell body1 = new TableCell();
                        Label L_Body = new Label();
                        L_Body.ForeColor = System.Drawing.Color.Black;
                        L_Body.Font.Size = 10;
                        L_Body.Text = reader.GetString(3); //body of notice.        

                        body1.Controls.Add(L_Body);
                        body.Controls.Add(body1);

                        notice.Controls.Add(sub);
                        notice.Controls.Add(body);

                        cell.Controls.Add(notice);
                        notices.Controls.Add(cell);
                        noticeBoard.Controls.Add(notices);
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            noticeBoard.HorizontalAlign = HorizontalAlign.Center;
            P_Data.Controls.Add(noticeBoard);
        }
        catch (SqlException ex)
        {
         
        }
    }
}
