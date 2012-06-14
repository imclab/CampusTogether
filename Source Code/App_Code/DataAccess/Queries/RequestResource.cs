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

public class RequestResource
{
	public static string Request(int ResId,string StudId,int quant,string mentor,DateTime IDate,DateTime RDate,string FacApp,string AdnApp,string purp,string issued)
	{
        
        try
        {
            SqlConnection conn = connection.GetConnectionCC();
        
        object result=new object();
        int menid; string res="";
            if (mentor != "NULL")
        {
            string q1 = "SELECT MentorID FROM Faculty WHERE FacultyName=@mtrname";
            SqlCommand command = new SqlCommand(q1, conn);
            command.Parameters.AddWithValue("@mtrname", mentor);
            command.CommandType = CommandType.Text;
            result = command.ExecuteScalar();
            menid = Convert.ToInt32(result);
            res = " " + mentor + " ";
        }
        else
           menid = -1;        //menid==mentorid;
    
            string q2 = "INSERT INTO Transaction_info(ID,StudentID,Quantity,MentorID,IssueDate,TentativeReturnDate,FacultyApproval,AdminApproval,Purpose,Issued)" +
                                "VALUES(@id,@studid,@quant,@mentorid,@Idate,@Rdate,@FacApp,@AdApp,@purp,@issued)";

           
            //Done - > change the StudentID to currently logged in userid....
            
            
            SqlCommand com2 = new SqlCommand(q2, conn);
            com2.Parameters.AddWithValue("@id", ResId);
            com2.Parameters.AddWithValue("@studid", (StudId));
            com2.Parameters.AddWithValue("@mentorid", menid);
            com2.Parameters.AddWithValue("@quant", quant);
            com2.Parameters.AddWithValue("@Idate", IDate);
            com2.Parameters.AddWithValue("@Rdate",RDate);
            com2.Parameters.AddWithValue("@FacApp", FacApp);
            com2.Parameters.AddWithValue("@AdApp",AdnApp);
            com2.Parameters.AddWithValue("@purp", purp);
            com2.Parameters.AddWithValue("@issued", issued);

            com2.CommandType = CommandType.Text;
            int raffected=com2.ExecuteNonQuery();
            //String.Format("{0} rows affected",raffected);             
            conn.Close();
            res = res + Convert.ToString(raffected);
            return res; 
        }
        catch(SqlException e )
        {
            string.Format("Cannot connect to database \n");
            return e.Message;
        }
        return "nothing ";       
	}
    
    
    /*---------------------
   
     * * The following function gets list of all the requests pending for approval.

     * If the user is incharge of resource allocation then he should get all faculty approved 
     * entities.
     * ---------------------------------------------------*/


    public static DataSet GetRequestForApproval(string usr)
    {
        
        SqlConnection conn = connection.GetConnectionCC();
        DataSet ds = new DataSet();
        
        if (DataAccess.AccessLevel == "ResourceAllocator")
        {

            string q1 = "SELECT Transaction_info.TransID,Transaction_info.StudentID,Transaction_info.Quantity,Resource_info.Name" +
                    ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.Purpose" +
                   " FROM Transaction_info ,Resource_info" +
                   " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.FacultyApproval='Approved' AND AdminApproval='Pending'";
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds);
        }

        else if (DataAccess.AccessLevel=="faculty" || DataAccess.AccessLevel == "HostelWarden")
        {
            object result = new object();
         //the following query gets mentor id of the logged in faculty.
           
            string q2 = "SELECT MentorID FROM Faculty WHERE MentorID=@usr";
            SqlCommand comm2 = new SqlCommand(q2, conn);
            comm2.Parameters.AddWithValue("@usr", usr); 
            comm2.CommandType = CommandType.Text;
            result = comm2.ExecuteScalar();
            int mentid = Convert.ToInt32(result);

            string q1 = "SELECT Transaction_info.TransID,Transaction_info.StudentID,Transaction_info.Quantity,Resource_info.Name" +
                        ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.Purpose" +
                       " FROM Transaction_info ,Resource_info" +
                       " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.MentorID=@menid AND Transaction_info.FacultyApproval='Pending'";

          
            SqlCommand comm = new SqlCommand(q1, conn);
            
            comm.Parameters.AddWithValue("@menid",usr);
            comm.CommandType = CommandType.Text;
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds);

        }
        conn.Close();
   return ds;

    }


    /*
     The following function returns no of available quantities
     
     */

    public static int AvailableResource(int transid)
    {
       int avail;
       string q1 = "SELECT Total, Issued FROM Resource_Info WHERE ID=@id";
       string q2 = "SELECT ID FROM Transaction_info WHERE TransID=@transid"; 
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm2 = new SqlCommand(q2, conn);
            comm2.CommandType = CommandType.Text;
            comm2.Parameters.AddWithValue("@transid", transid);
            object result = comm2.ExecuteScalar();
            int id = Convert.ToInt32(result);
            
           SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
              avail = reader.GetInt32(0) - reader.GetInt32(1);
        }

        return avail;    
   }


    
    /*
     * ------------------------------------------------------------------------------------------
    This function displays the list of requests which have already been approved by the faculty
    -------------------------------------------------------------------------------------------
     */
    public static DataSet Alreadyapproved(string usr)
    {
        SqlConnection conn = connection.GetConnectionCC();
        DataSet ds = new DataSet();
        if (DataAccess.AccessLevel == "ResourceAllocator")
        {
            string q1 = "SELECT Transaction_info.TransID, Transaction_info.StudentID, Transaction_info.Quantity, Resource_info.Name" +
                                    ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.Purpose" +
                                   " FROM Transaction_info ,Resource_info" +
                                   " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.AdminApproval='Approved'";


            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds,"curr");
        
        }
        else if (DataAccess.AccessLevel == "faculty" || DataAccess.AccessLevel == "HostelWarden")
        {
            object result = new object();
            
            string q2 = "SELECT MentorID FROM Faculty WHERE FacultyName=@usr";
            SqlCommand comm2 = new SqlCommand(q2, conn);
            comm2.Parameters.AddWithValue("@usr", usr);
            comm2.CommandType = CommandType.Text;
            result = comm2.ExecuteScalar();
            int mentid = Convert.ToInt32(result);

            string q1 = "SELECT Transaction_info.TransID, Transaction_info.StudentID, Transaction_info.Quantity, Resource_info.Name" +
                        ",Transaction_info.IssueDate, Transaction_info.TentativeReturnDate, Transaction_info.Purpose" +
                       " FROM Transaction_info ,Resource_info" +
                       " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.MentorID=@menid AND Transaction_info.FacultyApproval='Approved'";


            SqlCommand comm = new SqlCommand(q1, conn);

            comm.Parameters.AddWithValue("@menid", usr);
            comm.CommandType = CommandType.Text;
            
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(ds,"curr");
        }
        conn.Close();
        return ds;
    
    }
/*
 * The below function updates the resource_info table by increasing the no of issued items 
 * when it is approved by faculty.
 
 */
    public static void UpdateResource(int transid)
    {
        SqlConnection conn1 = connection.GetConnectionCC();
        
        string q1 = "SELECT Quantity, ID FROM Transaction_info WHERE TransID=@transid";
        SqlCommand comm = new SqlCommand(q1, conn1);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@transid",transid);
        SqlDataReader reader=comm.ExecuteReader();
        reader.Read();
       
        int quant = reader.GetInt32(0);
        int id = reader.GetInt32(1);
        conn1.Close();

        SqlConnection conn = connection.GetConnectionCC();
        string q3="SELECT Issued FROM Resource_info WHERE ID=@id";
        SqlCommand comm3 = new SqlCommand(q3, conn);
        comm3.CommandType = CommandType.Text;
        comm3.Parameters.AddWithValue("@id",id);
        object result = comm3.ExecuteScalar();
        int alreadyIssued = Convert.ToInt32(result);

        quant = quant + alreadyIssued;
        string q2 = "UPDATE Resource_info SET Issued=@new WHERE ID=@id";
        SqlCommand comm2 = new SqlCommand(q2, conn);
        comm2.CommandType = CommandType.Text;
        comm2.Parameters.AddWithValue("@new",quant);
        comm2.Parameters.AddWithValue("@id", id);
        comm2.ExecuteNonQuery();
        conn.Close();
    }
    
    
 //Returns all the data records which are approved ,also it updates the resources info    
    public static int ApprovedByFaculty(int Transid)
    {
        string q2="";
        if (DataAccess.AccessLevel == "staff")
        {
            q2 = "UPDATE Transaction_info SET AdminApproval='Approved' WHERE TransID=@transid";
            UpdateResource(Transid);
        }
        else if (DataAccess.AccessLevel == "faculty" || DataAccess.AccessLevel == "HostelWarden")
            q2 = "UPDATE Transaction_info SET FacultyApproval='Approved' WHERE TransID=@transid";
        SqlConnection conn = connection.GetConnectionCC();
        SqlCommand comm2 = new SqlCommand(q2, conn);
        comm2.Parameters.AddWithValue("@transid", Transid);
        comm2.CommandType = CommandType.Text;
        comm2.ExecuteNonQuery();
       // if (DataAccess.AccessLevel == "staff")
        //    UpdateResource(Transid);
        
        return Transid;
    }


    /*The following function rejects the request */

    public static void Reject(int transid)
    {
        string q2 = "UPDATE Transaction_info SET FacultyApproval='Rejected' WHERE TransID=@transid";
        SqlConnection conn = connection.GetConnectionCC();
        SqlCommand comm2 = new SqlCommand(q2, conn);
        comm2.Parameters.AddWithValue("@transid", transid);
        comm2.CommandType = CommandType.Text;
        comm2.ExecuteNonQuery();    
    }

    //public static SqlDataReader CurrentStatus(string usr)
    //{
        
    //    // make coorections to StudID = usr ;
    //    //string q1 = "SELECT Transaction_info.TransID,Transaction_info.StudentID,Transaction_info.Quantity,Resource_info.Name" +
    //    //            ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.FacultyApproval,Transaction_info.AdminApproval,Transaction_info.Purpose" +
    //    //           " FROM Transaction_info ,Resource_info" +
    //    //            "WHERE Resource_info.ID=Transaction_info.ID AND Transaction_info.StudentID=200701171";        

    //    string q1 = "SELECT Transaction_info.TransID,Transaction_info.StudentID,Transaction_info.Quantity,Resource_info.Name" +
    //               ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.FacultyApproval,Transaction_info.AdminApproval,Transaction_info.Purpose" +
    //              " FROM Transaction_info ,Resource_info" +
    //              " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.StudentID=200701171 AND Transaction_info.ReturnDate IS NULL";

    //    SqlConnection conn = connection.GetConnectionCC();
      
    //    SqlCommand comm = new SqlCommand(q1, conn);
    //    comm.CommandType = CommandType.Text;
    //    SqlDataReader reader1 = comm.ExecuteReader(CommandBehavior.CloseConnection);
    //    return reader1;

    //}



    /*
        functin for current status. 
    */
    
    public static DataSet cstatus(string usr)
    {

        string q1 = "SELECT Transaction_info.TransID,Transaction_info.Quantity,Resource_info.Name" +
                   ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.FacultyApproval,Transaction_info.AdminApproval,Transaction_info.Purpose,Transaction_info.Issued" +
                  " FROM Transaction_info ,Resource_info" +
                  " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.StudentID=@usr AND Transaction_info.ReturnDate IS NULL AND (FacultyApproval<>'Rejected' AND AdminApproval<>'Rejected')";

        SqlConnection conn = connection.GetConnectionCC();

        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@usr",(usr));
        DataSet ds=new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(comm);
        adaptor.Fill(ds,"current");
        conn.Close();
        return ds;
    
    }
    
    
    
    //Returns all the transaction which are completed.
    
   
    public static DataSet ShowMyActivity(string usr)
    {

        string q1 = "SELECT Transaction_info.TransID,Transaction_info.Quantity,Resource_info.Name" +
                       ",Transaction_info.IssueDate,Transaction_info.ReturnDate,Transaction_info.FacultyApproval,Transaction_info.AdminApproval,Transaction_info.Purpose" +
                      " FROM Transaction_info,Resource_info" +
                      " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.StudentID=@usr AND Transaction_info.ReturnDate IS NOT NULL OR (FacultyApproval='Rejected' OR AdminApproval='Rejected')";
        SqlConnection conn = connection.GetConnectionCC();

        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@usr", Convert.ToInt32(usr));
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds);
        return ds;
    }

    //Returns all the items that can be issued .... name s a bit ambigious
    public static DataSet GetIssuedItems(string usr)
    {

        string q1 = "SELECT Transaction_info.TransID,Transaction_info.StudentID,Transaction_info.Quantity,Resource_info.Name" +
                   ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.Purpose" +
                  " FROM Transaction_info ,Resource_info" +
                  " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.StudentID=@usr AND Transaction_info.ReturnDate IS NULL AND Transaction_info.Issued = 'NO' AND Transaction_info.FacultyApproval='Approved'"+
                  " AND Transaction_info.AdminApproval='Approved'";

        SqlConnection conn = connection.GetConnectionCC();

        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@usr", (usr));
        DataSet ds = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(comm);
        adaptor.Fill(ds, "current");
        conn.Close();
        return ds;

    }


    public static DataSet GetItemsToReturn(string usr)
    {

        string q1 = "SELECT Transaction_info.TransID,Transaction_info.StudentID,Transaction_info.Quantity,Resource_info.Name" +
                   ",Transaction_info.IssueDate,Transaction_info.TentativeReturnDate,Transaction_info.Purpose" +
                  " FROM Transaction_info ,Resource_info" +
                  " WHERE Resource_info.ID = Transaction_info.ID AND Transaction_info.StudentID=@usr AND Transaction_info.ReturnDate IS NULL AND Transaction_info.Issued = 'YES'";

        SqlConnection conn = connection.GetConnectionCC();

        SqlCommand comm = new SqlCommand(q1, conn);
        comm.CommandType = CommandType.Text;
        comm.Parameters.AddWithValue("@usr", usr);
        DataSet ds = new DataSet();
        SqlDataAdapter adaptor = new SqlDataAdapter(comm);
        adaptor.Fill(ds, "current");
        conn.Close();
        return ds;

    }


    public static void Issue(int transid)
    {
        string q1 = "UPDATE Transaction_info SET Issued='YES' WHERE TransID=@transid";
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@transid", transid);
            comm.ExecuteNonQuery();
        }
    
    }
    
    


    public static void ReturnResource(int transid)
    {
      
        string q1= "UPDATE Transaction_info SET ReturnDate=@date WHERE TransID=@transid";
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm = new SqlCommand(q1, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@transid", transid);
            DateTime date = System.DateTime.Now;
            comm.Parameters.AddWithValue("@date", date);
            comm.ExecuteNonQuery();

            string q2 = "SELECT ID, Quantity FROM Transaction_info WHERE TransID=@transid";
            SqlCommand comm2 = new SqlCommand(q1, conn);
            comm2.CommandType = CommandType.Text;
            comm2.Parameters.AddWithValue("@transid", transid);
            SqlDataReader reader = comm2.ExecuteReader();

            reader.Read();
            int id = reader.GetInt32(0);
            int quant = reader.GetInt32(1);


            string q3 = "SELECT Issued FROM Resource_info WHERE ID=@id";
            SqlCommand comm3 = new SqlCommand(q3, conn);
            comm3.CommandType = CommandType.Text;
            comm3.Parameters.AddWithValue("@id", id);
            object result = comm3.ExecuteScalar();
             int issued = Convert.ToInt32(result);
             issued = issued + quant;

             string q4 = "UPDATE Resource_info SET Issued=@issued WHERE ID=@id";
             SqlCommand comm4 = new SqlCommand(q4, conn);
             comm4.CommandType = CommandType.Text;
             comm4.Parameters.AddWithValue("@id", id);
             comm4.Parameters.AddWithValue("@issued", issued);
             comm4.ExecuteNonQuery(); 

        }
    
   
    
    }

    //public static SqlDataReader GetIssueUpdate(string user)
    //{
    //    string q1 = "SELECT TransID FROM Transanction_info WHERE ";
    
    //}



    /*
     search for a particular request
     */
    public static DataSet SearchResource(string s)
    {
        string q1 = "SELECT * FROM Resource_info WHERE Name = @s";
    DataSet ds = new DataSet();
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm4 = new SqlCommand(q1, conn);
            comm4.CommandType = CommandType.Text;
            comm4.Parameters.AddWithValue("@s", s);
            SqlDataAdapter adp = new SqlDataAdapter(comm4);
            adp.Fill(ds);
        }
        return ds;
    }

    public static DataSet SearchResource()
    {
        string q1 = "SELECT * FROM Resource_info";
        DataSet ds = new DataSet();
        using (SqlConnection conn = connection.GetConnectionCC())
        {
            SqlCommand comm4 = new SqlCommand(q1, conn);
            comm4.CommandType = CommandType.Text;
          
            SqlDataAdapter adp = new SqlDataAdapter(comm4);
            adp.Fill(ds);
        }
        return ds;
    }

}
