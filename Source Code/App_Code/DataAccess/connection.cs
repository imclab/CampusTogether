using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public class connection
{
	public static SqlConnection GetConnectionDA()
	{
        string str = "DA-IICTConnectionString";        
        string connectionstring1 = ConfigurationManager.ConnectionStrings[str].ConnectionString;        
        SqlConnection connect = new SqlConnection(connectionstring1);
        connect.Open();
        return connect;
	}
    public static SqlConnection GetConnectionCC()
    {
        //Establishes connection to Campus Connect database
        string connectionstring2 = ConfigurationManager.ConnectionStrings["CampusConnectionString"].ConnectionString;
        SqlConnection connect = new SqlConnection(connectionstring2);
        connect.Open();
        return connect;
    }
    public static SqlConnection GetConnectionGE()
    {
        //Establishes connection to GateEntry database
        string connectionstring3 = ConfigurationManager.ConnectionStrings["GateEntryConnectionString"].ConnectionString;
        SqlConnection connect = new SqlConnection(connectionstring3);
        connect.Open();
        return connect;
    }
}   
