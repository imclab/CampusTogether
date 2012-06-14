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

public partial class Resource_Issue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        DataSet ds = RequestResource.GetIssuedItems(Request.QueryString["user"]);
        Issue.DataSource = ds;
        Issue.DataBind();
        
    }
    protected void Issue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Issue.SelectedDataKey[0].ToString());
        RequestResource.Issue(id);
      Label1.Text="Item issued succesfully";

      Response.Redirect("Issue.aspx");
    }



    protected void IssuePageChange(Object sender, GridViewPageEventArgs e)
    {
        Issue.PageIndex = e.NewPageIndex;
        Issue.DataBind();

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





    protected void IssueSort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = Issue.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                Issue.DataSource = dataView;
                Issue.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }
}
