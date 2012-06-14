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

public partial class MasterPage : System.Web.UI.MasterPage
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
        L_Name.Text = "Welcome , "+ DataAccess.UserName;
        if (DataAccess.AccessLevel == "clubs/committees" || DataAccess.AccessLevel == "admin")
            H_Profile.Visible = false;
        if (DataAccess.AccessLevel == "clubs/committees" || DataAccess.AccessLevel == "admin")
            H_Gate.Visible = false;
    }
    protected void B_Help_Click(object sender, EventArgs e)
    {
        H_ENotice.Visible = true;
        H_GateEntry.Visible = true;
        H_Manual.Visible = true;
        H_Res.Visible = true;
    }
    protected void B_LogOut_Click(object sender, EventArgs e)
    {
        DataAccess.UserName = string.Empty;
        DataAccess.AccessLevel = string.Empty;
        Response.Redirect("~/Default.aspx");
    }
}
