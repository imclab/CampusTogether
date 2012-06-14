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
using System.IO;

public partial class NoticeContent_AddNotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    protected void B_Clear_Click(object sender, EventArgs e)
    {
        T_Body.Text = "";
        T_Sub.Text = "";
    }    
    protected void B_Submit_Click(object sender, EventArgs e)
    {
        bool success = DataAccess.InsertNotice(DataAccess.GetNoticeBoardID(DataAccess.UserName).ToString(), T_Sub.Text,
            T_Body.Text, DateTime.Now);
        if (success)
            Response.Redirect("notice.aspx");         
    }
}
