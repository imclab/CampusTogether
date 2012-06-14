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

public partial class Resource_Buildings_buildings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            int i = 1;
            for (; i <= 31; i++)
                Day.Items.Add(Convert.ToString(i));
        
            DataSet ds = Buildings.GetRoomType();
            type.DataSource = ds;
            type.DataTextField = ds.Tables[0].Columns[0].ColumnName.ToString();
            type.DataValueField = ds.Tables[0].Columns[0].ColumnName.ToString();
            type.DataBind();

            DataSet ds1 = Buildings.GetRooms(type.SelectedValue);
            number.DataSource = ds1;
            number.DataTextField = ds1.Tables[0].Columns[0].ColumnName.ToString();
            number.DataValueField = ds1.Tables[0].Columns[0].ColumnName.ToString();
            number.DataBind();
            //Purpose.Text = Calendar1.VisibleDate.Date.ToString();
            Calendar1.SelectedDate = System.DateTime.Now;
        }
        if (DataAccess.AccessLevel == "staff")
        {
            Req.Visible = false;
            Avail.Visible = false;
       
        }
            UpdateTimeTable();
        }

    protected void type_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            DataSet ds1 = Buildings.GetRooms(type.SelectedValue);
            number.DataSource = ds1;
            number.DataBind();
            Label1.Text = type.SelectedValue;
            UpdateTimeTable(); 
        }
        catch (SqlException a)
        {
            Label1.Text = a.Message;
        }
    
    }
    // On pressing Request Button.
    public void Button1_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(hour.Text)>Convert.ToInt32(hour2.Text)
           || (Convert.ToInt32(hour.Text)==Convert.ToInt32(hour2.Text)&& (Convert.ToInt32(minutes.Text)>= Convert.ToInt32(minutes2.Text))))
       {
         status.Text="Time selected is Invalid";       
       }   // the selected index starts from zero so add one to it .
        else if (
            (Convert.ToInt32(Year.SelectedValue))< (System.DateTime.Now.Year) ||
            ((Convert.ToInt32(Year.SelectedValue)) == (System.DateTime.Now.Year) && (Month.SelectedIndex + 1)< (System.DateTime.Now.Month)) ||
          ((Convert.ToInt32(Year.SelectedValue)) == (System.DateTime.Now.Year) && (Month.SelectedIndex + 1) == (System.DateTime.Now.Month) && (Convert.ToInt32(Day.SelectedValue)) < (System.DateTime.Now.Day)))
          {
            status.Text = "Invalid Date";
          }
        else
        {
            try
            {
                string roomno = type.Text + number.Text;
                string studid = DataAccess.UserName;
                //if role is faculty then don't ask for mentor . set it to null 
                //DateTime date = Convert.ToDateTime(Date.Text + Time.Text);

                string mon = Convert.ToString(Month.SelectedIndex + 1);
                if (mon.Length == 1)
                    mon = "0" + mon;
                string selday = Day.Text;
                if (selday.Length == 1)
                    selday = "0" + selday;

                string date = selday + "/" + mon + "/" + Year.Text.Substring(2, 2);
                string tfm = hour.Text + ":" + minutes.Text;
                string tto = hour2.Text + ":" + minutes2.Text;

                string purpose = Purpose.Text;
                string fapp = "Pending"; //if user is faculty then set it Approved.
                string Aapp = "Pending";
                Buildings.RequestRoom(roomno, studid, date, tfm, tto, purpose, fapp, Aapp);
                status.Text = "Your Request has been sent for Approval";
            }
            catch (SqlException a)
            {
                status.Text = a.Message;
            }
        }
     }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        
        string date = getdate();
       // Purpose.Text=(DateTime.Compare(Calendar1.SelectedDate, System.DateTime.Now)).ToString();

        UpdateTimeTable();
        //Purpose.Text = date;

       
       
    }

   //returns the selected calendar date.
    protected string getdate()
    {

        string day = Calendar1.SelectedDate.Day.ToString();
        string month = Calendar1.SelectedDate.Month.ToString();
        string year = Calendar1.SelectedDate.Year.ToString();

        if (day.Length == 1)
            day = "0" + day;
        if (month.Length == 1)
            month = "0" + month;
       // if (year.Length == 1)
            //year = "0" + year;
       
            year=year.Substring(2, 2);
        string date = day + month + year;
        return date;
    
    }

    protected void UpdateTimeTable()
    {
         
        string date = getdate();
        string room = type.Text + number.Text;
        string dd = date;
        dd = dd.Insert(4, "-"); dd = dd.Insert(2, "-");
        roomno.Text = room + " " + dd;
        DataSet ds = Buildings.GetTimeTable(room, date);
        ttbl.DataSource = ds;
        ttbl.DataBind();
    
    
    }

    protected void number_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTimeTable();
    }
    protected void Month_SelectedIndexChanged(object sender, EventArgs e)
    {
        Day.Items.Clear();
        if (Month.Text == "Jan" || Month.Text == "March" || Month.Text == "May"
            || Month.Text == "July" || Month.Text == "Aug" || Month.Text == "Oct"
            || Month.Text == "Dec")
        { 
          int i=1;
          for (; i <= 31; i++)
              Day.Items.Add(Convert.ToString(i));
        
        }
        else if (Month.Text != "Feb")
        {
            int i = 1;
            for (; i <= 30; i++)
            {
                Day.Items.Add(Convert.ToString(i));
            }

        }
        else
        {
            int i = 1;
            for (; i <= 28; i++)
            {
                Day.Items.Add(Convert.ToString(i));
            }
            
            if (Convert.ToInt32(Year.Text) % 4 == 0)
            {
                Day.Items.Add(Convert.ToString(i));
            }
        
        }
    
    
    }
  
    //checking availability
    protected void Button2_Click(object sender, EventArgs e)
    {

        //Checking Validation of date
        if (Convert.ToInt32(hour.Text) > Convert.ToInt32(hour2.Text)
           || (Convert.ToInt32(hour.Text) == Convert.ToInt32(hour2.Text) && (Convert.ToInt32(minutes.Text) >= Convert.ToInt32(minutes2.Text))))
        {
            status.Text = "Time selected is Invalid";
        }   // the selected index starts from zero so add one to it .
        else if (
            (Convert.ToInt32(Year.SelectedValue)) < (System.DateTime.Now.Year) ||
            ((Convert.ToInt32(Year.SelectedValue)) == (System.DateTime.Now.Year) && (Month.SelectedIndex + 1) < (System.DateTime.Now.Month)) ||
          ((Convert.ToInt32(Year.SelectedValue)) == (System.DateTime.Now.Year) && (Month.SelectedIndex + 1) == (System.DateTime.Now.Month) && (Convert.ToInt32(Day.SelectedValue)) < (System.DateTime.Now.Day)))
        {
            status.Text = "Invalid Date";
        }    
      else{  
        string mon = Convert.ToString(Month.SelectedIndex + 1);
        if (mon.Length == 1)
            mon = "0" + mon;
        string selday = Day.Text;
        if (selday.Length == 1)
            selday = "0" + selday;

        string date=selday + mon + Year.Text.Substring(2,2);
         string room = type.Text + number.Text;
         GiveAvail(date, room);     
       
        }
    }      
    
    
    // returns 1 if the slot is available else 0;
    protected int GiveAvail(string date,string room)
    {
        try
        {
            using (SqlDataReader reader = Buildings.CheckAvail(date, room))
            {
                while (reader.Read())
                {
                    int tempstart = Convert.ToInt32(reader.GetString(0));
                    int tempmfin = Convert.ToInt32(reader.GetString(1));
                    int selctedstart = Convert.ToInt32(hour.Text + minutes.Text);
                    int selctedfin = Convert.ToInt32(hour2.Text + minutes2.Text);
                    Purpose.Text = Convert.ToString(tempstart) + Convert.ToString(tempmfin)
                                     + " " + Convert.ToString(selctedstart) + Convert.ToString(selctedfin);

                    if ((selctedstart < tempstart && selctedfin <= tempstart) || (selctedstart >= tempmfin && selctedfin > tempmfin))
                    {
                        status.Text = "Your Requested slot is available.";

                    }
                    else
                    {
                        status.Text = "Your Requested slot is not available";
                        return 0;
                    }

                }
            }
        }
        catch(SqlException a)
        {
            status.Text = a.Message;
        } 
        return 1;
    }

}
