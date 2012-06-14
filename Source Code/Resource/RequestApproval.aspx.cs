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
using System.Windows.Forms;

public partial class Resource_RequestApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {           
            //todo:
            // ***Add authentication according to role and faculty name
            //    pass name as parameter.***
            // ** add authentication check for admin **
        
        string usr = DataAccess.UserName;
        
            try
            {
                if (DataAccess.AccessLevel == "ResourceAllocator" || DataAccess.AccessLevel == "faculty")
                {
                    Res.DataSourceID = String.Empty;
                    DataSet reader = RequestResource.GetRequestForApproval(usr);
                    Res.DataSource = reader;
                    Res.DataBind();
                }
                }
            catch(Exception a)
            {
                Label1.Text = a.Message;
            }

            if (DataAccess.AccessLevel == "LabIncharge" || DataAccess.AccessLevel == "CEPIncharge" || DataAccess.AccessLevel=="faculty")
            {
                try
                {
                   
                    {
                        DataSet ds2 = Buildings.AlreadyApproved(usr);
                        ApprovedRoom.DataSource = ds2.Tables[0]; //insert paging
                        ApprovedRoom.DataBind();
                    }
                    }
                catch (Exception a)
                {
                    Label1.Text = a.Message;
                }

            }

            else
            {
                try
                {
                    if (DataAccess.AccessLevel == "ResourceAllocator" || DataAccess.AccessLevel == "faculty")
                    {
                        DataSet reader1 = RequestResource.Alreadyapproved(usr);
                        Approved.DataSource = reader1.Tables[0];
                        Approved.DataBind();
                    }
                 }
                catch
                {
                    Label1.Text = "Some error in getting Approved Data";
                }
            }

            if (DataAccess.AccessLevel == "LabIncharge" || DataAccess.AccessLevel == "CEPIncharge" || DataAccess.AccessLevel == "faculty")
            {
                try
                {
                    rooms.DataSourceID = String.Empty;
                    DataSet ds = Buildings.GetRoomApproval(usr);
                    rooms.DataSource = ds;
                    rooms.DataBind();
                }
                catch (SqlException a)
                {
                    Label1.Text = a.Message;

                }
            }



        
       
    }   
    protected void grid_SelectedIndexChanged1(object sender, EventArgs e)
    {
        int ans=RequestResource.ApprovedByFaculty(Convert.ToInt32(Res.SelectedDataKey[0]));
        //grid.DeleteRow(grid.SelectedIndex);
        //string usr = User.Identity.Name;
        //using (SqlDataReader reader = RequestResource.GetRequestForApproval(usr))
        //{
        //    grid.DataSource = reader;
        //    grid.DataBind();
        //}
        
        //Response.Redirect("RequestApproval.aspx");
        Label1.Text = ans.ToString();
    }

    protected void grid_RowCommandHandler(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Reject")
        {
           // Label1.Text = "INside rowhandler";
            int row = Convert.ToInt32(e.CommandArgument);
            GridViewRow row1 = ((sender as GridView).Rows[row]);
            RequestResource.Reject(Convert.ToInt32(row1.Cells[2].Text));

        }
        else 
        {
            Label1.Text = "Approve clicked";
            int row = Convert.ToInt32(e.CommandArgument);
            GridViewRow row1 =((sender as GridView).Rows[row]);
            
            //check if resource is available.
            if (DataAccess.AccessLevel == "staff")
            {
                if (Convert.ToInt32(row1.Cells[4].Text) > RequestResource.AvailableResource(Convert.ToInt32(row1.Cells[2].Text)))
                {
                    MessageBox.Show("The Requested items are not available currently");
                }
                else
                    RequestResource.ApprovedByFaculty(Convert.ToInt32(row1.Cells[2].Text));
            }
            else 
            {
                RequestResource.ApprovedByFaculty(Convert.ToInt32(row1.Cells[2].Text));
            }
        
        
        }
        Response.Redirect("RequestApproval.aspx");

    }

    protected void room_RowCommandHandler(Object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Reject")
        {
            // Label1.Text = "INside rowhandler";
            int row = Convert.ToInt32(e.CommandArgument);
            GridViewRow row1 = ((sender as GridView).Rows[row]);
            Buildings.Room_Reject(Convert.ToInt32(row1.Cells[2].Text));
        }
        else
        {
            Label1.Text = "Approve clicked";
            int row = Convert.ToInt32(e.CommandArgument);
            GridViewRow row1 = ((sender as GridView).Rows[row]);
            Buildings.Room_ApprovedByFaculty(Convert.ToInt32(row1.Cells[2].Text));

        }
        Response.Redirect("RequestApproval.aspx");
    }

    protected void rooms_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

 
    
    //------------------Paging and Sorting------------
    
    protected void gridPageChange(Object sender, GridViewPageEventArgs e)
    {
        Res.PageIndex = e.NewPageIndex;
        Res.DataBind();

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





    protected void gridSort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = Res.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                Res.DataSource = dataView;
                Res.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }
//-------------------------------------------------------------------------

 
    //Approved-----------------------------------------


    protected void ApprovedPageChange(Object sender, GridViewPageEventArgs e)
    {
        Approved.PageIndex = e.NewPageIndex;
        Approved.DataBind();

    }

   





    protected void ApprovedSort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = Approved.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                Approved.DataSource = dataView;
                Approved.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }

    //------------------------------------------------

    //rooms------------------------------------------------------

    protected void roomsPageChange(Object sender, GridViewPageEventArgs e)
    {
        rooms.PageIndex = e.NewPageIndex;
        rooms.DataBind();

    }

  



    protected void roomsSort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = rooms.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                rooms.DataSource = dataView;
                rooms.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }
    //-------------------------------------------------------------



//-------------------------------------------------------------------------------------
    protected void ApprovedRoomPageChange(Object sender, GridViewPageEventArgs e)
    {
        ApprovedRoom.PageIndex = e.NewPageIndex;
        ApprovedRoom.DataBind();

    }







    protected void ApprovedRoomSort(object sender, GridViewSortEventArgs e)
    {

        try
        {
            DataTable dataTable = ApprovedRoom.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                ApprovedRoom.DataSource = dataView;
                ApprovedRoom.DataBind();
            }

        }
        catch (Exception a)
        {
            //Label1.Text = a.Message;
        }

    }
    //------------------------------------------------------------------------------------



}
