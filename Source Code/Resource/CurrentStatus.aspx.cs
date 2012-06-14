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
using System.Data.SqlClient ;

public partial class Resource_CurrentStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = RequestResource.cstatus(DataAccess.UserName);
        CurrStatus.DataSource = ds.Tables[0];
        CurrStatus.DataBind();

        if (DataAccess.AccessLevel == "clubs/committees" || DataAccess.AccessLevel == "faculty" || DataAccess.AccessLevel=="HostelWarden")
        {
            DataSet ds2 = Buildings.CurrStatus(DataAccess.UserName);
            RoomStatus.DataSource = ds2.Tables[0];
            RoomStatus.DataBind();
        }
    }

    protected void GridView2_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        CurrStatus.PageIndex = e.NewPageIndex;
        CurrStatus.DataBind();

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





    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = CurrStatus.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                CurrStatus.DataSource = dataView;
                CurrStatus.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }



// for other grid


    protected void RoomStatus_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        RoomStatus.PageIndex = e.NewPageIndex;
        RoomStatus.DataBind();

    }







    protected void RoomStatus_Sorting(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = RoomStatus.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                RoomStatus.DataSource = dataView;
                RoomStatus.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }


    
}
