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
public partial class Resource_MyActivity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        string usr = DataAccess.UserName;
        DataSet ds = RequestResource.ShowMyActivity(usr);
        Activity.DataSource = ds.Tables[0];
        Activity.DataBind();
   //get rooms Activity for faculty and club .
        if (DataAccess.AccessLevel == "clubs/committees" || DataAccess.AccessLevel == "faculty" || DataAccess.AccessLevel == "HostelWarden")
        {
            DataSet ds2 = Buildings.GetActivity(usr);
            RoomActivity.DataSource = ds.Tables[0];
            RoomActivity.DataBind();
        }
    }

    protected void ActivityPageChange(Object sender, GridViewPageEventArgs e)
    {
        Activity.PageIndex = e.NewPageIndex;
        Activity.DataBind();

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





    protected void ActivitySort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = Activity.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                RoomActivity.DataSource = dataView;
                RoomActivity.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }




    protected void RoomActivityPageChange(Object sender, GridViewPageEventArgs e)
    {
        RoomActivity.PageIndex = e.NewPageIndex;
        RoomActivity.DataBind();

    }





    protected void RoomActivitySort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = RoomActivity.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                RoomActivity.DataSource = dataView;
                RoomActivity.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }



}
