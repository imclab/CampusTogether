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
/// <summary>
/// Summary description for Buildings
/// </summary>
public class Buildings
{
  
    // Returns the names of the rooms.
    
    
    public static DataSet GetRoomType()
    {
        SqlConnection conn = connection.GetConnectionCC();
        string q1 = "SELECT Name FROM Buildings ";
        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds,"rooms");
        conn.Close();
        return ds;

    }

    //Returns the number of the type of the room

    public static DataSet GetRooms(string name)
    {

            SqlConnection conn = connection.GetConnectionCC();
            string q1 = "SELECT CategoryID FROM Buildings WHERE Name=@type";
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@type", name);
            object result = comm.ExecuteScalar();
            int id = Convert.ToInt32(result);


            string q2 = "SELECT Number FROM BuildingNumber WHERE CategoryID=@id";
            SqlCommand comm2 = new SqlCommand(q2, conn);
            comm2.CommandType = CommandType.Text;
            comm2.Parameters.AddWithValue("@id", id);


            DataSet ds = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter(comm2);  
            adaptor.Fill(ds,"roomtype");   
            conn.Close();
            //
            //SqlDataReader reader = comm2.ExecuteReader();
            //reader.Read();
             
            //string aid = ((reader.GetString(0)));
            //return aid;
            //conn.Close();
            return ds;
        
        
        

        
      }

    //Insert the information in Roombook_info

    public static void RequestRoom(string RoomNo, string StudentID, string date, string tfm,string tto,string purpose, string FacultyApproval, string AdminApproval)
    {
        /*
         check if user is faculty or student 
         * if club or committee ... manipulate mentor id
         */
        SqlConnection conn = connection.GetConnectionCC();
        string mentorid= "";
      //if user role = club get mentor
        if (DataAccess.AccessLevel == "clubs/committees")
        {
            object result;
            string q2 = "SELECT MentorID FROM Predefined_mentors WHERE ClubID=@studid";
            SqlCommand com2 = new SqlCommand(q2, conn);
            com2.CommandType = CommandType.Text;
            com2.Parameters.AddWithValue("@studid", StudentID);
            result = com2.ExecuteScalar();
            mentorid = Convert.ToString(result);
        }
        else if (DataAccess.AccessLevel == "faculty") 
        {
            mentorid = "-1";
            FacultyApproval = "Approved";
        }

        string q1 = "INSERT INTO Roombook_info(RoomNo,StudentID,MentorID,Date,TimeFrom,Timeto,Purpose,FacultyApproval,AdminApproval)" +
            "VALUES(@roomno,@studentid,@mentorid,@date,@tfm,@tto,@purpose,@fapp,@Aapp)";
        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        
        comm.Parameters.AddWithValue("@roomno",RoomNo);
        comm.Parameters.AddWithValue("@studentid",StudentID);
        comm.Parameters.AddWithValue("@date",date);
        comm.Parameters.AddWithValue("@tfm", tfm);  //tfm=TimeFrom , tto=TimtTo
        comm.Parameters.AddWithValue("@tto", tto);
        comm.Parameters.AddWithValue("@purpose",purpose);
        comm.Parameters.AddWithValue("@mentorid",mentorid);
        comm.Parameters.AddWithValue("@fapp",FacultyApproval);
        comm.Parameters.AddWithValue("@Aapp",AdminApproval);

        comm.ExecuteNonQuery();
        conn.Close();
    }

   
    /*
     The following function gets the current status for faculty and clubs
     
     */

    public static DataSet CurrStatus(string usr)
    {

        string q1 = "SELECT Roombook_info.RoomNo, Roombook_info.Date, Roombook_info.TimeFrom," +
                    "Roombook_info.TimeTo, Roombook_info.Purpose, Roombook_info.FacultyApproval, Roombook_info.AdminApproval" +
                        " FROM Roombook_info" +
                        " WHERE Roombook_info.StudentID=@usr AND Roombook_info.AdminApproval='Pending' AND (Roombook_info.AdminApproval<>'Rejected' AND Roombook_info.AdminApproval<>'Rejected')";
        DataSet ds = new DataSet();
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@usr", usr);

            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds);
                 
        
        }
        return ds;
    }


    public static DataSet GetActivity(string user)
    {
        string q1 = "SELECT Roombook_info.TransID,Roombook_info.RoomNo, Roombook_info.Date,Roombook_info.TimeFrom, Roombook_info.TimeTo, Roombook_info.Purpose " +
            "FROM Roombook_info WHERE StudentID=@user AND FacultyApproval='Approved' AND AdminApproval='Approved' OR (FacultyApproval='Rejected' OR AdminApproval='Rejected')";
        DataSet ds = new DataSet();
        using(SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@user", user);

            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds); 
        
        
        }
        return ds;
    }




    /*
     returns dataset containing requests which are pending for approval . 
     */
    
    public static DataSet GetRoomApproval(string usr)
    {
        SqlConnection conn = connection.GetConnectionCC();
        DataSet ds = new DataSet();
        if (DataAccess.AccessLevel != "faculty")
        {

            string q1 = string.Empty;
            if (DataAccess.AccessLevel == "LabIncharge")
            {
                 q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date, Roombook_info.TimeFrom," +
                    "Roombook_info.TimeTo, Roombook_info.Purpose" +
                        " FROM Roombook_info" +
                        " WHERE Roombook_info.FacultyApproval='Approved' AND Roombook_info.AdminApproval='Pending' AND (Roombook_info.RoomNo LIKE 'LT%' OR Roombook_info.RoomNo LIKE 'LAB%')";
                 SqlCommand comm = new SqlCommand(q1, conn);
                 //id1
                 comm.CommandType = CommandType.Text;


                 SqlDataAdapter adp = new SqlDataAdapter(comm);
                 adp.Fill(ds);
            }
            else if (DataAccess.AccessLevel == "CEPIncharge")
            {
                q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date, Roombook_info.TimeFrom," +
                        "Roombook_info.TimeTo, Roombook_info.Purpose" +
                            " FROM Roombook_info" +
                            " WHERE Roombook_info.FacultyApproval='Approved' AND Roombook_info.AdminApproval='Pending' AND Roombook_info.RoomNo LIKE 'CEP%'";
                SqlCommand comm = new SqlCommand(q1, conn);
                //id1
                comm.CommandType = CommandType.Text;


                SqlDataAdapter adp = new SqlDataAdapter(comm);
                adp.Fill(ds);
            }
            else if (DataAccess.AccessLevel == "admin")
            {
                q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date, Roombook_info.TimeFrom," +
                        "Roombook_info.TimeTo, Roombook_info.Purpose" +
                            " FROM Roombook_info" +
                            " WHERE Roombook_info.FacultyApproval='Approved' AND Roombook_info.AdminApproval='Pending' AND (Roombook_info.RoomNo LIKE 'SAC%' OR Roombook_info.RoomNo LIKE 'OAT%' OR Roombook_info.RoomNo LIKE 'CLUB%' )";

                SqlCommand comm = new SqlCommand(q1, conn);
                //id1
                comm.CommandType = CommandType.Text;


                SqlDataAdapter adp = new SqlDataAdapter(comm);
                adp.Fill(ds);
            }
        
           
            
        
        }
       else if (DataAccess.AccessLevel == "faculty")
        {

        string q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date,Roombook_info.TimeFrom,"+
                  " Roombook_info.TimeTo, Roombook_info.Purpose" +
                  " FROM Roombook_info" +
                  " WHERE Roombook_info.MentorID=@mentorid AND Roombook_info.FacultyApproval='Pending'";

            SqlCommand comm = new SqlCommand(q1, conn);
           //id2 
           comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@mentorid", usr);
            
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds);
            
        }
        conn.Close();
        return ds;
    }


    //the following function returns data according to the role and which have been already approved

    public static DataSet AlreadyApproved(string usr)
    {
        SqlConnection conn = connection.GetConnectionCC();
        DataSet ds = new DataSet();
     
        if(DataAccess.AccessLevel!="faculty")
        {
        string q1 = string.Empty;
            if (DataAccess.AccessLevel == "LabIncharge")
            {
                 q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date, Roombook_info.TimeFrom," +
                    "Roombook_info.TimeTo, Roombook_info.Purpose" +
                        " FROM Roombook_info" +
                        " WHERE Roombook_info.FacultyApproval='Approved' AND Roombook_info.AdminApproval='Approved' AND (Roombook_info.RoomNo LIKE 'LT%' OR Roombook_info.RoomNo LIKE 'LAB%')";
            }
            else if (DataAccess.AccessLevel == "CEPIncharge")
            {
                q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date, Roombook_info.TimeFrom," +
                        "Roombook_info.TimeTo, Roombook_info.Purpose" +
                            " FROM Roombook_info" +
                            " WHERE Roombook_info.FacultyApproval='Approved' AND Roombook_info.AdminApproval='Approved' AND Roombook_info.RoomNo LIKE 'CEP%'";
            }
            else if (DataAccess.AccessLevel == "admin")
            {
                q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date, Roombook_info.TimeFrom," +
                        "Roombook_info.TimeTo, Roombook_info.Purpose" +
                            " FROM Roombook_info" +
                            " WHERE Roombook_info.FacultyApproval='Approved' AND Roombook_info.AdminApproval='Approved' AND (Roombook_info.RoomNo LIKE 'SAC%' OR Roombook_info.RoomNo LIKE 'OAT%' OR Roombook_info.RoomNo LIKE 'CLUB%' )";
            
            }
        
            SqlCommand comm = new SqlCommand(q1, conn);
            //id3
            comm.CommandType = CommandType.Text;
           
            
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds);
            
        
        }
       else if (DataAccess.AccessLevel == "faculty")
        {

        string q1 = "SELECT Roombook_info.TransID, Roombook_info.RoomNo, Roombook_info.StudentID, Roombook_info.Date,Roombook_info.TimeFrom,"+
                  " Roombook_info.TimeTo, Roombook_info.Purpose" +
                  " FROM Roombook_info" +
                  " WHERE Roombook_info.MentorID=@mentorid AND Roombook_info.FacultyApproval='Approved'";

            SqlCommand comm = new SqlCommand(q1, conn);
           //id4
           comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@mentorid", usr);
            
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds);
            
        }
        conn.Close();
        return ds;
    
    }



    // The following function updates the timetable if a request is approved by the faculty.
    public static void UpdateTT(int Transid)
    {
        SqlConnection conn = connection.GetConnectionCC();
        string q1 = "SELECT Roombook_info.Date, Roombook_info.TimeFrom, Roombook_info.TimeTo, " +
            "Roombook_info.Roomno, Roombook_info.Purpose " +
            "FROM Roombook_info WHERE Roombook_info.TransID=@transid";

        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@transid",Transid); 
        SqlDataReader reader = comm.ExecuteReader();
        string date, Timefrom, Timeto, Event, Room;
       reader.Read();
        
            date=reader.GetString(0);
            Timefrom = reader.GetString(1);
            Timeto = reader.GetString(2);
            Room = reader.GetString(3);
            Event = reader.GetString(4);

            date=date.Remove(5, 1);
            date = date.Remove(2,1);

            Timefrom=Timefrom.Remove(2,1);
            Timeto=Timeto.Remove(2, 1);

            using (SqlConnection conn2 = connection.GetConnectionCC())
            {
                string q2 = "INSERT INTO Timetable(Date,TimeFrom,TimeTo,Building,Event)"
                     + "VALUES(@date,@Timefrom,@Timeto,@Room,@event)";
                SqlCommand comm2 = new SqlCommand(q2, conn2);

                comm2.CommandType = CommandType.Text;
                comm2.Parameters.AddWithValue("@date", date);
                comm2.Parameters.AddWithValue("@Timefrom", Timefrom);
                comm2.Parameters.AddWithValue("@Timeto", Timeto);
                comm2.Parameters.AddWithValue("@Room", Room);
                comm2.Parameters.AddWithValue("@event", Event);
                comm2.ExecuteNonQuery();
            }
        
       using( SqlConnection conn3 = connection.GetConnectionCC())
       {
           string q4="SELECT StudentID FROM Roombook_info WHERE TransID=@trid";
           SqlCommand comm4 = new SqlCommand(q4, conn3);
           comm4.CommandType = CommandType.Text;
           comm4.Parameters.AddWithValue("@trid", Transid);
           object result = comm4.ExecuteScalar();
           string userid=Convert.ToString(result);

           string q5 = "SELECT COUNT(UID) FROM Updates WHERE UserID=@usr";
           SqlCommand comm5 = new SqlCommand(q5, conn3);
           comm5.CommandType = CommandType.Text;
           comm5.Parameters.AddWithValue("@usr", userid);
           object result1 = comm5.ExecuteScalar();
           int count = Convert.ToInt32(result1);

           if (count >= 10)
           {
               string q6 = "DELETE FROM Updates WHERE UID=min(UID) AND UserID=@usr";
               SqlCommand comm6 = new SqlCommand(q6, conn3);
               comm6.CommandType = CommandType.Text;
               comm6.Parameters.AddWithValue("@usr", userid);
               comm6.ExecuteNonQuery();
           }

           
           
           string q3 = "INSERT INTO Updates(UserID, Event)VALUES(@usr,@event)";
           SqlCommand comm3 = new SqlCommand(q3, conn3);
           comm3.CommandType = CommandType.Text;
           comm3.Parameters.AddWithValue("@usr", userid );
           comm3.Parameters.AddWithValue("@event", "Your request for " + Room + " is approved");
           comm3.ExecuteNonQuery();
       
       }
        
        
        
        
        conn.Close();
    }
    

    
    /*
     * The following function actually works for both the AccessLevels 
     * staff and faculty(inspite of its name).It updates the Approved by 
     * Faculty/Admin . Also after the Admin approves the update timetable method is 
     * called to make an entry corresponding to the room
     */
    
    public static int Room_ApprovedByFaculty(int Transid)
    {
        string q2 = "";
        if (DataAccess.AccessLevel == "LabIncharge" || DataAccess.AccessLevel == "CEPIncharge")
        {
            q2 = "UPDATE Roombook_info SET AdminApproval='Approved' WHERE TransID=@transid";
            UpdateTT(Transid);
        }
        else if (DataAccess.AccessLevel == "faculty")
            q2 = "UPDATE Roombook_info SET FacultyApproval='Approved' WHERE TransID=@transid";
        
        SqlConnection conn = connection.GetConnectionCC();
        SqlCommand comm2 = new SqlCommand(q2, conn);
        comm2.Parameters.AddWithValue("@transid", Transid);
        comm2.CommandType = CommandType.Text;
        comm2.ExecuteNonQuery();
        //if (DataAccess.AccessLevel == "staff")
           // UpdateTT(Transid);
       
        conn.Close();
        return Transid;
        
    }


   
    /*
     Below function handles the reject button clicked by the user
      It acts acoording to the access level the user has , for staff it updates 
     * AdminApproval as rejected .
     */
    
    public static void Room_Reject(int transid)
    {
      string q2 = "";

      if (DataAccess.AccessLevel == "staff")
          q2 = "UPDATE Roombook_info SET AdminApproval='Rejected' WHERE TransID=@transid";
      else if (DataAccess.AccessLevel == "faculty")
          q2 = "UPDATE Roombook_info SET FacultyApproval='Rejected' WHERE TransID=@transid";
        SqlConnection conn = connection.GetConnectionCC();
        SqlCommand comm2 = new SqlCommand(q2, conn);
        comm2.Parameters.AddWithValue("@transid", transid);
        comm2.CommandType = CommandType.Text;
        comm2.ExecuteNonQuery();
        conn.Close();
    }


    /*
     Below function returns datset containing the timetable of the room and on the date
     * passed as parameters.
     */
    
    public static DataSet GetTimeTable(string room, string date)
    { 
      SqlConnection conn = connection.GetConnectionCC();
      string q1 = "SELECT Timetable.TimeFrom, Timetable.TimeTo, Timetable.Event "
          + "FROM Timetable WHERE Date=@date AND Building=@room";
      SqlCommand comm = new SqlCommand(q1, conn);
      comm.CommandType = CommandType.Text;
      comm.Parameters.AddWithValue("@date", date);
      comm.Parameters.AddWithValue("@room", room);
        SqlDataAdapter adp = new SqlDataAdapter(comm);
      DataSet ds = new DataSet();
      adp.Fill(ds, "tt");
      conn.Close();
      return ds;
    }

    /*
     * The following function returns the reader conatining 
     * information for a particular room and date
     * the comparison is done at the place of calling.
     */
    
    public static SqlDataReader CheckAvail(string date,string room)
    {
        SqlConnection conn = connection.GetConnectionCC();
        string q1 = "SELECT Timetable.TimeFrom, Timetable.TimeTo " +
                   "FROM Timetable WHERE Timetable.Date=@date AND Timetable.Building=@room";
        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@date", date);
        comm.Parameters.AddWithValue("@room", room);
        SqlDataReader read = comm.ExecuteReader(CommandBehavior.CloseConnection);
        return read;
    }

}
