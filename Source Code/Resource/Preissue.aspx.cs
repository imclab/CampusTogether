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

public partial class Resource_Preissue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
    }

    protected void Issue_Click(object sender, EventArgs e)
    {
        string user = TextBox1.Text;
        Response.Redirect("Issue.aspx?user=" + user);
    }
}
