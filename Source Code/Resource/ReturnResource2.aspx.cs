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

public partial class Resource_ReturnResource2 : System.Web.UI.Page
{

    static string user = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {     
         if(!Page.IsPostBack)
            user = Request.QueryString["user"];

         try
         {
             DataSet ds = RequestResource.GetItemsToReturn(user);
             CurrentlyIssued.DataSource = ds;
             CurrentlyIssued.DataBind();
         }
        catch(SqlException a)
         {
             System.Windows.Forms.MessageBox.Show("Error in connecting to database");  
         }
    }
    protected void CurrentlyIssued_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void CurrentlyIssuedPageChange(Object sender, GridViewPageEventArgs e)
    {
        CurrentlyIssued.PageIndex = e.NewPageIndex;
        CurrentlyIssued.DataBind();

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





    protected void CurrentlyIssuedSort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = CurrentlyIssued.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                CurrentlyIssued.DataSource = dataView;
                CurrentlyIssued.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }


    protected void CurrentlyIssued_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int transid = Convert.ToInt32(CurrentlyIssued.SelectedDataKey[0]);
        Status.Text = transid.ToString();
        try
        {
            RequestResource.ReturnResource(transid);
        }
        catch (SqlException a)
        {
            System.Windows.Forms.MessageBox.Show("Error in connecting to database");
        }
    }
}
