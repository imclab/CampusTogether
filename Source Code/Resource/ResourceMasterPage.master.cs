using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Resource_ResourceMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Username"] != "")
        {

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        Rooms.Visible = false;
        Approval.Visible = false;
        Issue.Visible = false;
        Return.Visible = false;

        if (DataAccess.AccessLevel == "faculty" || DataAccess.AccessLevel == "LabIncharge" || DataAccess.AccessLevel == "clubs/committees" || DataAccess.AccessLevel == "CEPIncharge" || DataAccess.AccessLevel=="admin"
            || DataAccess.AccessLevel =="ResourceAllocator" || DataAccess.AccessLevel =="HostelWarden")
        {
            Rooms.Visible = true;
           
            if (DataAccess.AccessLevel == "faculty" )
                Approval.Visible = true;
            if (DataAccess.AccessLevel == "CEPIncharge" || DataAccess.AccessLevel == "LabIncharge" || DataAccess.AccessLevel == "ResourceAllocator")
            {

                if (DataAccess.AccessLevel == "CEPIncharge" || DataAccess.AccessLevel == "LabIncharge" || DataAccess.AccessLevel == "admin")
                {
                    Approval.Visible = true;
                    Activity.Visible = false;
                }
                else
                {
                    Approval.Visible = true;
                    Activity.Visible = false;
                    Issue.Visible = true;
                    Return.Visible = true;
                    Rooms.Visible = false;
                }
                }
        }

        if (DataAccess.AccessLevel == "HostelSuperVisor")
        { 
        
        }
    }
}
