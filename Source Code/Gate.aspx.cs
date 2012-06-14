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
using sharp = iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;

public partial class GateEntry_Gate : System.Web.UI.Page
{
    string register = string.Empty;
    String c = "                                               GATE ENTRY LOG\n" 
        +      "                                                                                                                "
        + DateTime.Now.ToString()+ "\n\n\n"  ;
        
    public Hashtable ht = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            CalendarExtender2.SelectedDate = DateTime.Now.Date;
            //CompareValidator2.ValueToCompare = DateTime.Parse(T_Df.Text);
            
            T_ID.Text = "";
            
            if (DataAccess.AccessLevel == "student")
                ShowData(DataAccess.UserName, 1);
            if (DataAccess.AccessLevel == "staff")
                ShowData(DataAccess.UserName, 2);
            if (DataAccess.AccessLevel == "faculty")
                ShowData(DataAccess.UserName, 3);
            if (DataAccess.AccessLevel == "HostelWarden" ||
                DataAccess.AccessLevel == "HostelSuperVisor")
            {
                B_Pdf.Visible = true;
                ShowData(DataAccess.UserName, 4);
            }            
        }
        else
        {
            if (T_ID.Text == "") 
            {
                if (T_Df.Text == "")
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, DateTime.Parse(T_Dt.Text))).Tables[0];
                }
                else
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, DateTime.Parse(T_Df.Text), DateTime.Parse(T_Dt.Text))).Tables[0];
                }            
            }
            else
            {
                if (T_Df.Text == "")
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, T_ID.Text, DateTime.Parse(T_Dt.Text))).Tables[0];
                }
                else
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, T_ID.Text, DateTime.Parse(T_Df.Text),DateTime.Parse(T_Dt.Text))).Tables[0];
                }                
            }
            GateData.DataBind();
        }
    }
    private void ShowData(string idInfo, int view)
    {
        L_ID.Visible = false;
        T_ID.Visible = false;

        if (view == 1)
        {
            ht.Add("Student", "Student_In_Out");
            ht.Add("Vehicle", "Vehicle_In_Out");
            ht.Add("Laptop", "Laptop_In_Out");
            ht.Add("Visitor", "Visitor_Entry");
        }
        else if (view == 2) 
        {            
            ht.Add("Staff", "Staff_In_Out");
            ht.Add("Vehicle", "Vehicle_In_Out");
            ht.Add("Laptop", "Laptop_In_Out");
            ht.Add("Visitor", "Visitor_Entry");            
        }
        else if (view == 3)
        {
            ht.Add("Faculty", "Faculty_In_Out");
            ht.Add("Vehicle", "Vehicle_In_Out");
            ht.Add("Laptop", "Laptop_In_Out");
            ht.Add("Visitor", "Visitor_Entry");
        }
        else if (view == 4)
        {
            ht.Add("Student", "Student_In_Out");
            ht.Add("Staff", "Staff_In_Out");
            ht.Add("Faculty", "Faculty_In_Out");
            ht.Add("Visitor", "Visitor_Entry");
            ht.Add("Vehicle", "Vehicle_In_Out");
            ht.Add("Laptop", "Laptop_In_Out");            
            ht.Add("Complaint", "Complaint_Log");
            T_ID.Visible = true;
            L_ID.Visible = true;
        }
        D_Register.DataSource = ht;
        D_Register.DataTextField = "key";
        D_Register.DataValueField = "value";
        D_Register.DataBind();
    }
    protected void B_Search_Click(object sender, EventArgs e)
    {
        GateData.Caption = D_Register.SelectedValue.ToString();

        if (GateData.Rows.Count != 0)
        {
            B_Pdf.Enabled = true;            
        }
        try
        {
            if (T_ID.Text == "")
            {
                if (T_Df.Text == "")
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, DateTime.Parse(T_Dt.Text))).Tables[0];
                }
                else
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, DateTime.Parse(T_Df.Text), DateTime.Parse(T_Dt.Text))).Tables[0];
                }
            }
            else
            {
                if (T_Df.Text == "")
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, T_ID.Text, DateTime.Parse(T_Dt.Text))).Tables[0];
                }
                else
                {
                    GateData.DataSource = (DataAccess.GetEntryData(D_Register.SelectedValue, T_ID.Text, DateTime.Parse(T_Df.Text), DateTime.Parse(T_Dt.Text))).Tables[0];
                }
            }            
            GateData.DataBind();
        }
        catch (SqlException ex)
        {
            T_ID.Text = ex.Message;
        }     
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
    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GateData.PageIndex = e.NewPageIndex;

        GateData.DataBind();
    }
    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GateData.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GateData.DataSource = dataView;
            GateData.DataBind();
        }
    }
    protected void D_Register_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        c += "                                             " + GateData.Caption.ToString() + "\n\n";
        
        int serial = 0;
        int row = 0,column = 0;
        
        while(row < GateData.Rows.Count)
        {
            serial++;
            c += serial;
            if (serial < 10)
                c += "       ";
            else
                c += "      ";

            column = 0;
            while(column < GateData.Rows[row].Cells.Count)
            {
                if (GateData.Rows[row].Cells[column].Text == "")
                {
                    c += "                              ";
                }
                else
                {
                    c += GateData.Rows[row].Cells[column].Text;
                    c += "             ";
                }
                column++;
            }
            c += "\n";
            row++;
        }
        sharp.Document document = new sharp.Document();
        string path = Server.MapPath(".") + "\\" + "Report.pdf";

        PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
        document.Open();

        document.Add(new sharp.Paragraph(c));
        
        document.Close();

        Response.Redirect("~/Report.pdf");
    }
}
