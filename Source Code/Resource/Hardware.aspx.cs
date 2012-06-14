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

public partial class Resource_Hardware : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = ShowAll();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = GridView1.SelectedDataKey[0].ToString();
        int quant = Convert.ToInt32(GridView1.SelectedDataKey[2].ToString());
        int issued = Convert.ToInt32(GridView1.SelectedDataKey[1].ToString());
        int resourceid = Convert.ToInt32(GridView1.SelectedDataKey[3].ToString());
       
        int avail = quant - issued;
        if (avail <= 0)
            status.Text = "There is no availability of resource you have requested ";
        else
        {
            string avbl = Convert.ToString(avail);
            Response.Redirect("RequestForm.aspx?nam=" + name + "&avail=" + avbl + "&id=" + resourceid);
        }
    }

    protected void GridView1PageChange(Object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();

    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }





    protected void GridView1Sort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = GridView1.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }

  protected static DataSet ShowAll()
  {
   string q1="SELECT * FROM Resource_info";  
    DataSet ds = new DataSet();
      using (SqlConnection conn = connection.GetConnectionCC())
    {
      SqlCommand comm = new SqlCommand(q1,conn);
        comm.CommandType=CommandType.Text;
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds);
        
    
    }
  return ds;
  }


  protected static DataSet ShowAll(string res)
  {
      string q1 = "SELECT * FROM Resource_info WHERE Name=@res";
      DataSet ds = new DataSet();
      using (SqlConnection conn = connection.GetConnectionCC())
      {
          SqlCommand comm = new SqlCommand(q1, conn);
          comm.CommandType = CommandType.Text;
          comm.Parameters.AddWithValue("@res", res);
          SqlDataAdapter adp = new SqlDataAdapter(comm);
          adp.Fill(ds);


      }
      return ds;
  }


  protected void Search_Click(object sender, EventArgs e)
  {
      DataSet ds = ShowAll(TextBox1.Text);
      GridView1.DataSource = ds;
      GridView1.DataBind();
  }
  protected void Show_Click(object sender, EventArgs e)
  {
      DataSet ds = ShowAll();
      GridView1.DataSource = ds;
      GridView1.DataBind();
  }
}
