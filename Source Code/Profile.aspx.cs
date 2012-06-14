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

public partial class Profile_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (DataAccess.AccessLevel == "clubs/committees")
            //    L_Error.Text = "No Profile Page for Clubs/Committees";
            if (DataAccess.AccessLevel == "student")
                ShowProfile(DataAccess.UserName,1);
            if (DataAccess.AccessLevel == "staff")
                ShowProfile(DataAccess.UserName,2);
            if (DataAccess.AccessLevel == "faculty")
                ShowProfile(DataAccess.UserName,3);
            if (DataAccess.AccessLevel == "HostelWarden")
            {
                ViewOthersProfiles();
                ShowProfile(DataAccess.UserName,3);
            }
            if (DataAccess.AccessLevel == "HostelSuperVisor")
            {
                ViewOthersProfiles();
                EditInfo();
                ShowProfile(DataAccess.UserName,2);
            }
        }
    }
    private void ViewOthersProfiles()
    {
        L_D1.Visible = true;
        L_Info.Visible = true;
        T_ID.Enabled = true;
        T_ID.Visible = true;
        B_Search.Enabled = true;
        B_Search.Visible = true;        
    }
    private void EditInfo()
    {
        B_Laptop.Visible = true;
        B_Laptop.Enabled = true;
        B_Vehicle.Visible = true;
        B_Vehicle.Enabled = true;

        //B_Vehicle.Text = "Edit";
        //L_Number.ReadOnly = true;
        //L_Company.ReadOnly = true;
        //B_Laptop.Text = "Edit";
        //L_Serial.ReadOnly = true;
        //L_Brand.ReadOnly = true;
        //L_Room.ReadOnly = true;
    }
    private void ClearAll()
    {
        L_Role.Text = "";
        L_Id.Text = "";
        L_Sex.Text = "";
        L_ExtraInfo.Text = "";

        L_Serial.Text = "";
        L_Brand.Text = "";
        L_Room.Text = "";

        L_Number.Text = "";
        L_Company.Text = "";
        L_Sex.Text = "";
        I_Photo.ImageUrl = "";
        L_Name.Text = "";
        

    }
    protected void B_Search_Click(object sender, EventArgs e)
    {
        ClearAll();
        string hint = T_ID.Text.Substring(4, 2);
        using (SqlDataReader reader = DataAccess.GetRolesInfo(hint))
        {
            while (reader.Read())
            {
                string IdHint = reader.GetString(0);

                if (hint == IdHint)
                {
                    if (reader.GetString(1) == "student")
                        ShowProfile(T_ID.Text, 1);
                    if(reader.GetString(1) == "staff")
                        ShowProfile(T_ID.Text, 2);
                    if (reader.GetString(1) == "faculty")
                        ShowProfile(T_ID.Text, 3);
                    //else if (reader.GetString(1) == "clubs/committees")
                    else
                        R_Info.Text = "Profiles do not Exist";
                }
            }
        }        
            
        
    }
    private void ShowProfile(string idInfo,int view)
    {
        try
        {
            string[] register = new string[3];
            if(view == 1)      {  register = new string[] { "Laptop_Registration", "Student", "Vehicle_Registration" };}
            else if(view == 2) {  register = new string[] { "Laptop_Registration", "Staff_Info", "Vehicle_Registration" };}            
            else if(view == 3) {  register = new string[] { "Laptop_Registration", "Faculty", "Vehicle_Registration" };}            
            for (int count = 0; count < register.Count(); count++)
            {                
                using (SqlDataReader reader = DataAccess.GetInfo(register[count]))
                {
                
                    while (reader.Read())
                    {
                        string Id = reader.GetInt64(0).ToString();
                        if (Id == idInfo)
                        {
                                if (count == 0)
                                {
                                    if(reader.HasRows != null)
                                    {
                                        L_Brand.Text = reader.GetString(2);
                                        L_Serial.Text = reader.GetString(1);
                                        L_Room.Text = reader.GetString(3);
                                    }
                                }
                                if (count  == 1)
                                {
                                    if (reader.HasRows != null)
                                    {
                                        L_Id.Text = Id;
                                        if (view == 1)
                                         Student(reader); 
                                        else if (view == 2)                                        
                                            Staff(reader);
                                        else if (view == 3)
                                            Faculty(reader);
                                    }
                                }
                                if (count  == 2)
                                {
                                    if (reader.HasRows != null)
                                    {
                                        L_Number.Text = reader.GetString(1);
                                        L_Company.Text = reader.GetString(2);
                                    }
                                    else
                                    {
                                        L_Number.Text = "";
                                        L_Company.Text = "";
                                    }
                                }                           
                        }
                    }
                }
            }
        }
        catch (SqlException ex)
        {
        }
    }    
    //private void ContractorInfo(string Cid)
    //{
    //    string ret;
    //    using (SqlDataReader reader = DataAccess.GetInfo("Contractor_Info"))
    //    {
    //        while (reader.Read())
    //        {
    //            string Id = reader.GetInt64(0).ToString();
    //            if (Id == Cid)
    //            {
    //               ret = reader.GetString(1);
    //            }
    //        }
    //    }
    //    return ret;
    //}
    private void Student(SqlDataReader reader)
    {
        L_RoleL.Text = "Role";
        L_Name.Text = reader.GetString(1);
        L_Sex.Text = reader.GetString(3);
        I_Photo.ImageUrl = reader.GetString(2);
        L_SexL.Text = "Sex";
        L_Extra.Visible = false;
        L_ExtraInfo.Visible = false;
        L_Role.Text = ""; // Get Role
    }
    private void Staff(SqlDataReader reader)
    {
        L_Name.Text = reader.GetString(1);
        L_SexL.Text = "Contact";
        L_Sex.Text = reader.GetInt64(3).ToString();
        I_Photo.ImageUrl = reader.GetString(5);
        L_RoleL.Text = "Address";
        L_Role.Text = reader.GetString(2);

        L_Extra.Text = "Contractor";
        //L_ExtraInfo.Text = ContractorInfo
        //    (reader.GetInt64(4).ToString());
    }
    private void Faculty(SqlDataReader reader)
    {
        L_Name.Text = reader.GetString(1);
        L_SexL.Text = "Extension";
        L_Sex.Text = reader.GetInt32(3).ToString();
        I_Photo.ImageUrl = reader.GetString(4);
        L_RoleL.Text = "Room";
        L_Role.Text = reader.GetString(2);
    }    
    protected void B_Vehicle_Click(object sender, EventArgs e)
    {
        
        if (B_Vehicle.Text != "Update")
        {
            //Make the textbox editable.
            L_Number.ReadOnly = false;
            L_Company.ReadOnly = false;
            B_Vehicle.Text = "Update";
        }
        else
        {
            //when update is clicked just change the text and store the data in database.
            B_Vehicle.Text = "Edit";
            L_Number.ReadOnly = true;
            L_Company.ReadOnly = true;
            DataAccess.EditVehicleInfo(L_Id.Text, L_Number.Text, L_Company.Text);
        }
    }
    protected void B_Laptop_Click(object sender, EventArgs e)
    {
        if (B_Laptop.Text != "Update")
        {
            //Make the textbox editable.
            L_Serial.ReadOnly = false;
            L_Brand.ReadOnly = false;
            L_Room.ReadOnly = false;
            B_Laptop.Text = "Update";

        }
        else
        {
            //when update is clicked just change the text and store the data in database.

            B_Laptop.Text = "Edit";
            L_Serial.ReadOnly = true;
            L_Brand.ReadOnly = true;
            L_Room.ReadOnly = true;
            DataAccess.EditLaptopInfo(L_Id.Text, L_Serial.Text, L_Brand.Text,L_Room.Text);
        }
       
    }
}