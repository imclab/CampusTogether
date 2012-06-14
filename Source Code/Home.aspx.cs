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

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = HttpContext.Current.Session["role"].ToString();
        
        DateTime time = DateTime.Now;
        int day = time.Day;
        int month = time.Month;
        int year = time.Year;
        int hour = time.Hour;

        IssueUpdate();
        ReturnUpdate();
        if (DataAccess.AccessLevel == "clubs/committees" || DataAccess.AccessLevel == "faculty")
        {
            RoomsUpdate();
        }
    }

    protected void IssueUpdate()
    {
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            string q1 = "SELECT TransID,IssueDate FROM Transaction_info WHERE StudentID=@user AND IssueDate=@date AND AdminApproval='Approved' AND ReturnDate IS NULL";
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@user", DataAccess.UserName);
            comm.Parameters.AddWithValue("@date", System.DateTime.Now.Date);
            SqlDataReader r = comm.ExecuteReader();

            while (r.Read())
            {
                int transid = r.GetInt32(0);
                B_Update.Items.Add("Today is issue date of transaction " + transid.ToString());
                if (B_Update.Items.Count > 4)
                    break;
            }            
        }
    }

    protected void ReturnUpdate()
    {
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            string q1 = "SELECT TransID FROM Transaction_info WHERE StudentID=@user AND TentativeReturnDate=@date";
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@user", DataAccess.UserName);
            comm.Parameters.AddWithValue("@date", System.DateTime.Now.Date);
            SqlDataReader r = comm.ExecuteReader();

            while (r.Read())
            {
                int transid = r.GetInt32(0);
                B_Update.Items.Add("Today is return date of transaction " + transid.ToString());
                if (B_Update.Items.Count > 7)
                    break;
            }

        }
    }

    protected void RoomsUpdate()
    {
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            string q1 = "SELECT Event FROM Updates WHERE UserID=@user ORDER BY UID DESC";
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@user", DataAccess.UserName);
           
            //comm.Parameters.AddWithValue("@date", System.DateTime.Now.Date);
            SqlDataReader r = comm.ExecuteReader();

            while (r.Read())
            {
                string upd = r.GetString(0);
                B_Update.Items.Add(upd);
                if (B_Update.Items.Count >12)
                    break;
            }

        }
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Resource.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("notice.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Gate.aspx");
    }
}