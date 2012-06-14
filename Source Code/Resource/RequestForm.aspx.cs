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
using System.Globalization;

public partial class Resource_RequestForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        CompareValidator2.ValueToCompare = DateTime.Now.Date.ToString();
        if (!Page.IsPostBack)
        {
            //get all details about the request made 
            L_com.Text = Request.QueryString["nam"]; //name of rresource
            int max = Convert.ToInt32(Request.QueryString["avail"]);//quantity available
            int i = 1;

            if (DataAccess.AccessLevel != "student")
            {
                DL_fac.Visible = false;
                DL_fac.Text = "NULL";
                Mentor.Visible = false;
                //Faculty.Visible = false;
            }
            for (i = 1; i <= max; i++)
            {
                DL_quan.Items.Add(Convert.ToString(i));
            }
        }
        else 
        {
            //reset all buttons.
            //TB_df.Text = "";
            //TB_dt.Text = "";
            //TB_pur.Text = "";
            //DL_fac.ClearSelection();
            //DL_quan.ClearSelection();
        
        }
   
    
    
    }
    protected void Reset_Button_Click(object sender, EventArgs e)
    {        
        TB_df.Text = "";
        TB_dt.Text = "";
        TB_pur.Text = "";
        DL_fac.ClearSelection();
        DL_quan.ClearSelection();
    }
    protected void Cancel_Button_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hardware.aspx");
    }
    protected void request_button_Click(object sender, EventArgs e)
    {
        //Add information to the database...... 
        int ResId= Convert.ToInt32(Request.QueryString["id"]);
        int quantity = Convert.ToInt32(Convert.ToString(DL_quan.SelectedValue));
        string userid = DataAccess.UserName;//User.Identity.Name;
        string mentor="";
        if (DataAccess.AccessLevel == "faculty")
        { mentor = "NULL"; Mentor.Visible = false; }
        else
            mentor = DL_fac.SelectedItem.ToString();
        try
        {
            DateTime issuedate = Convert.ToDateTime((TB_df.Text));
            DateTime returndate = Convert.ToDateTime((TB_dt.Text));

            //string[] formats = { "dd/MM/yy hh:mm tt" };
            //DateTime issuedate = DateTime.ParseExact(TB_df.Text, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            //DateTime returndate = DateTime.ParseExact(TB_dt.Text, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            
            string Facultyapproval = "Pending";
        if (DataAccess.AccessLevel == "faculty")
            Facultyapproval = "Approved";
        string Adminapproval = "Pending";
        string purpse = TB_pur.Text;
        string Issued = "NO";
        if (DateTime.Compare(issuedate, returndate) == 1)
        {
            L_Continue.Text = "Date is not right";
        }
        else
        {
            string ans = RequestResource.Request(ResId, userid, quantity, mentor, issuedate, returndate, Facultyapproval, Adminapproval, purpse, Issued);
        }
        //--------------------------------------------        
        
            
        B_Cancel.Enabled = false;
        B_Request.Enabled = false;
        B_Reset.Enabled = false; 
        
        L_Continue.Visible = true;
        L_Continue.Text = "Your Request has been sent for approval";
        B_Continue.Visible = true;
        B_Continue.Enabled = true;
        B_Done.Enabled = true;
        B_Done.Visible = true;
        //TB_df.Text = "";
        //TB_dt.Text = "";
        //TB_pur.Text = "";
        //DL_fac.ClearSelection();
        //DL_quan.ClearSelection();
        }
        catch (Exception a)
        {
            L_Continue.Text = a.Message;
        }
    }
    protected void B_Continue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Hardware.aspx");
    }
    protected void B_Done_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Resource.aspx");
    }
}