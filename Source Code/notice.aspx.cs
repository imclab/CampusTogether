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

public partial class NoticeContent_AddBoard : System.Web.UI.Page
{
    public  int NBID = 0;
    public  int NID = 0;

    public Table MidTable(SqlDataReader read,int count)
    {
        Table mid = new Table();        
        int j = 0;
        while (read.Read() && j < count/3)
        {
            TableRow midrow = new TableRow();
            TableCell midcell = new TableCell();
            midcell.Controls.Add(CreateTable(read));
            midrow.Controls.Add(midcell);
            mid.Controls.Add(midrow);        
            j++;
        }
        return mid;
    }
    protected void MakeView()
    {        
        int i = 0;

        Table page = new Table();
        TableRow row = new TableRow();
        
        using (SqlDataReader reader = DataAccess.GetIn("Notice_Board"))
        {
            int count = GetTotalTables();
            TableCell cell1 = new TableCell();
            cell1.VerticalAlign = VerticalAlign.Top;
            cell1.BorderColor = System.Drawing.Color.Black;
            cell1.BorderWidth = 2;     
            cell1.Controls.Add(MidTable(reader,count));
            row.Controls.Add(cell1);

            TableCell cell2 = new TableCell();
            cell2.VerticalAlign = VerticalAlign.Top;
            cell2.BorderColor = System.Drawing.Color.Black;
            cell2.BorderWidth = 2;
            cell2.Controls.Add(MidTable(reader,count));
            row.Controls.Add(cell2);

            TableCell cell3 = new TableCell();
            cell3.VerticalAlign = VerticalAlign.Top;
            cell3.BorderColor = System.Drawing.Color.Black;
            cell3.BorderWidth = 2;
            cell3.Controls.Add(MidTable(reader, count));
            row.Controls.Add(cell3);
        }
        
        
        page.Controls.Add(row);
        P_Board.Controls.Add(page);
    }
    public Table CreateTable(SqlDataReader reader)
    {
        Table board = new Table();
        board.Width = 218;
        board.BorderColor = System.Drawing.Color.Black;
        board.BorderWidth = 2;
        TableRow title = new TableRow();
        TableCell title1 = new TableCell();
        title1.Font.Bold = true;
        title1.Font.Size = 18;
        title1.HorizontalAlign = HorizontalAlign.Center;

        Label label = new Label();
        label.Text = reader.GetString(2);
        title1.Controls.Add(label);
        title.Controls.Add(title1);

        board.Controls.Add(title);

        try
        {
            SqlDataReader reader1 = DataAccess.GetNotices(reader.GetInt32(0));
            int count = 0;

            while (count < 3 && reader1.Read())
             {
                if (reader1.GetInt32(0) == reader.GetInt32(0))
                {
                    TableRow sub = new TableRow();
                    TableCell subC = new TableCell();
                    subC.HorizontalAlign = HorizontalAlign.Left;
                    Label L_Sub = new Label();
                    L_Sub.Text = reader1.GetString(2).Substring(0,10);
                    L_Sub.Font.Bold = true;
                    L_Sub.Font.Size = 12;
                    //reader.GetString(2);
                    subC.Controls.Add(L_Sub);
                    sub.Controls.Add(subC);

                    TableCell close = new TableCell();
                    ImageButton IB = new ImageButton();
                    IB.ImageUrl = "~/images/close.png";
                    NBID = reader1.GetInt32(0);
                    NID = reader1.GetInt32(1);
                    string head = Convert.ToString(NBID);
                    string tail = Convert.ToString(NID);
                    IB.CommandArgument = head + ":" + tail;

                    IB.Click += new ImageClickEventHandler(IB_Close_Click);
                    close.HorizontalAlign = HorizontalAlign.Right;
                    close.Controls.Add(IB);
                    sub.Controls.Add(close);

                    board.Controls.Add(sub);

                    TableRow body = new TableRow();
                    TableCell body1 = new TableCell();
                    body1.HorizontalAlign = HorizontalAlign.Left;
                    Label L_Body = new Label();
                    L_Body.ForeColor = System.Drawing.Color.Black;
                    L_Body.Font.Size = 10;
                    L_Body.Text = reader1.GetString(3);
                    //reader.GetString(3); //body of notice.        

                    body1.Controls.Add(L_Body);
                    body.Controls.Add(body1);

                    board.Controls.Add(body);
                }
                count++;
            }
        }
        catch(SqlException ex)
        {

        }
        TableRow footer = new TableRow();
        TableCell Add = new TableCell();
        Add.HorizontalAlign = HorizontalAlign.Left;
        if (reader.GetString(1) == DataAccess.UserName)
        {
            HyperLink L_Add = new HyperLink();
            L_Add.Text = "ADD";
            L_Add.NavigateUrl = "~/AddNotice.aspx";
            Add.Controls.Add(L_Add);
        }        

        footer.Controls.Add(Add);        
        board.Controls.Add(footer);        
        return board;
    }
    public TableRow Spacer()
    {
        TableRow spacer = new TableRow();
        TableCell spacerC = new TableCell();
        Label space = new Label();
        space.Text = "";
        space.Height = 15;
        spacerC.Controls.Add(space);
        spacer.Controls.Add(spacerC);
        return spacer;
    }    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DataAccess.AccessLevel == "admin")
        {
            B_Add.Visible = true;
            B_Add.Enabled = true;
            B_Delete.Enabled = true;
            B_Delete.Visible = true;
        }
        MakeView();
     }
    protected void B_Add_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBoard.aspx");
    }
    protected void B_Delete_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteBoard.aspx");
    }
    protected void IB_Close_Click(object sender, ImageClickEventArgs e)
    {
        
        string code = (sender as ImageButton).CommandArgument;
        int pos= code.IndexOf(":");
        int nbid = Convert.ToInt32(code.Substring(0, pos));
        int len = code.Length;
        int nid = Convert.ToInt32(code.Substring(pos + 1, code.Length-2));        
        DataAccess.DeleteNotice(nbid,nid);
        Response.Redirect("notice.aspx");
    }
    protected void B_Detail_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/DetailView.aspx?NBName={0}",D_NB.SelectedValue));
    }
    public static int GetTotalTables()
    {
        string q1 = "SELECT COUNT(*) FROM Notice_Board";
        int count = 0;
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            object result = comm.ExecuteScalar();
            count = Convert.ToInt32(result);

        }
        return count;
    }


}
