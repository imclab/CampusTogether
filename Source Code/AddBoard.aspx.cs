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

public partial class NoticeContent_AddBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        T_Name.Text = "";
        T_Mod.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DataAccess.CreateBoard(T_Mod.Text,T_Name.Text) == true)
            Response.Redirect("~/notice.aspx");
        //insert board info into database.
    }
}
