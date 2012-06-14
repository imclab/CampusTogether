using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Session["Username"] = "";
        HttpContext.Current.Session["role"] = "";
    }
    protected void B_Login_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlDataReader reader = DataAccess.GetUserInfo(T_User.Text))
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    //Encryption of password
                    byte[] pass = Encoding.UTF8.GetBytes(T_Pass.Text);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    string strPassword = Encoding.UTF8.GetString(md5.ComputeHash(pass));

                    if (reader.GetString(0) == strPassword)
                    {
                        HttpContext.Current.Session["Username"] = T_User.Text;

                        DataAccess.UserName = T_User.Text;
                        DeciedeRole(T_User.Text.Substring(4, 2));
                    }
                    else
                    {
                        L_Status.Text = "Incorrect Username/Password";
                    }
                }
                else
                    L_Status.Text = "Incorrect Username/Password";
            }
        }
        catch (SqlException ex)
        {
            L_Status.Text = ex.Message;
        }
    }    
    public void DeciedeRole(string subuser)
    {
        try
        {
            using (SqlDataReader reader = DataAccess.GetRolesInfo(subuser))
            {                
                while (reader.Read())
                {
                    string IdHint = reader.GetString(0);
                    string role = reader.GetString(1);
                    if (IdHint == subuser)
                    {
                        if (T_User.Text == "200781002") // Give the ID for admin 
                            DataAccess.AccessLevel = "admin";
                        else if (T_User.Text == "200781001") // HostelSuperVisor
                            DataAccess.AccessLevel = "HostelSuperVisor";
                        else if (T_User.Text == "200781006") // Hostel Warden
                            DataAccess.AccessLevel = "HostelWarden";
                        else if((T_User.Text == "200781003")) // Lab Incharge
                            DataAccess.AccessLevel = "LabIncharge";
                        else if((T_User.Text == "200781004")) // CEP Incharge
                            DataAccess.AccessLevel = "CEPIncharge";
                        else if ((T_User.Text == "200781005")) // Resource Allocator
                            DataAccess.AccessLevel = "ResourceAllocator";
                        else
                            DataAccess.AccessLevel = role;
                        HttpContext.Current.Session["role"] = DataAccess.AccessLevel;
                        Response.Redirect("Home.aspx");
                        break;
                    }
                }
            }
        }
        catch(SqlException ex)
        {
           
        }
    }
}