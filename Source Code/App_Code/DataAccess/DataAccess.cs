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
using System.Data.Sql;

public class DataAccess
{
    //Used to access the DA-IICT webmail database to login.
	public static SqlDataReader GetUserInfo(string Id)
	{
        string sql = string.Format("SELECT Password FROM Accounts WHERE UserID = {0}",Id);

        SqlConnection connect = connection.GetConnectionDA();
        
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
	}
    //public static bool UpdateProfile(string register)
    //{
    //    string sql = String.Format("INSERT INTO {0}",register)+
    //        "Notices()" + "VALUES ;

    //    SqlConnection connect = connection.GetConnectionDA();
    //    SqlCommand command = new SqlCommand(sql, connect);
    //    command.Parameters.AddWithValue();
    //    command.CommandType = CommandType.Text;
    //}    

    //public static SqlDataReader GetUserInfo()
    //{
    //    string sql = "UPDATE Products SET UnitPrice=UnitPrice + " + amount.ToString();
        
    //    SqlConnection connect = connection.GetConnectionDA();
    //    SqlCommand command = new SqlCommand(sql, connect);
    //    command.CommandType = CommandType.Text;

    //    SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
    //    return reader;
    //}

    public static DataSet GetEntryData(string register,DateTime Dt)
    {
        SqlConnection conn = connection.GetConnectionGE();
        DataSet ds = new DataSet();
        string sql = string.Empty;
        //DateTime.Compare(,Dt.Date);
        if (register == "Student_In_Out" || register == "Laptop_In_Out" || register == "Vehicle_In_Out")
        {            
            sql = String.Format("SELECT * FROM {0} WHERE In_Time <=", register);
            sql += "'" + Dt + "'";

            //sql = String.Format("SELECT * FROM {0} WHERE In_Time < /'{1}"/', register,Dt);
        }
        else if (register == "Staff_In_Out" || register == "Faculty_In_Out" || register == "Visitor_Entry")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Out_Time <=", register);
            sql += "'" + Dt + "'";
        }
        else if (register == "Complaint_Log")
        {
            //Complain Register.
            sql = String.Format("SELECT * FROM {0} WHERE Time <=", register, Dt);
            sql += "'" + Dt + "'";
        }
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.CommandType = CommandType.Text;
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds);
        conn.Close();
        return ds;
    }
    public static DataSet GetEntryData(string register,DateTime Df,DateTime Dt)
    {
        SqlConnection conn = connection.GetConnectionGE();
        DataSet ds = new DataSet();
        string sql = string.Empty;
        //DateTime.Compare(,Dt.Date);
        if (register == "Student_In_Out" || register == "Laptop_In_Out" || register == "Vehicle_In_Out")
        {
            sql = String.Format("SELECT * FROM {0} WHERE In_Time <=", register);
            sql += "'" + Dt + "'";
            sql += "AND Out_Time >=";
            sql += "'" + Df + "'";

            //sql = String.Format("SELECT * FROM {0} WHERE In_Time < /'{1}"/', register,Dt);
        }
        else if (register == "Staff_In_Out" || register == "Faculty_In_Out" || register == "Visitor_Entry")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Out_Time <=", register);
            sql += "'" + Dt + "'";
            sql += "AND In_Time >=";
            sql += "'" + Df + "'";            
        }
        else if (register == "Complaint_Log")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Time <=", register);
            sql += "'" + Dt + "'";
            //Complain Register.            
        }
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.CommandType = CommandType.Text;
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds);
        conn.Close();
        return ds;
    }
    public static DataSet GetEntryData(string register,string ID, DateTime Df, DateTime Dt)
    {
        SqlConnection conn = connection.GetConnectionGE();
        DataSet ds = new DataSet();
        string sql = string.Empty;
        //DateTime.Compare(,Dt.Date);
        if (register == "Student_In_Out" || register == "Laptop_In_Out" || register == "Vehicle_In_Out")
        {
            sql = String.Format("SELECT * FROM {0} WHERE In_Time <=", register);
            sql += "'" + Dt + "'";
            sql += "AND Out_Time >=";
            sql += "'" + Df + "'";
            sql += string.Format("AND Id = {0}", ID);

            //sql = String.Format("SELECT * FROM {0} WHERE In_Time < /'{1}"/', register,Dt);
        }
        else if (register == "Staff_In_Out" || register == "Faculty_In_Out" || register == "Visitor_Entry")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Out_Time <=", register);
            sql += "'" + Dt + "'";
            sql += "AND In_Time >=";
            sql += "'" + Df + "'";
            sql += string.Format("AND Id = {0}", ID);
        }
        else if (register == "Complaint_Log")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Time <=", register);
            sql += "'" + Dt + "'";
            sql += string.Format("AND Id = {0}", ID);
            //Complain Register.            
        }
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.CommandType = CommandType.Text;
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds);
        conn.Close();
        return ds;

    }
    public static DataSet GetEntryData(string register, string ID,DateTime Dt)
    {
        SqlConnection conn = connection.GetConnectionGE();
        DataSet ds = new DataSet();
        string sql = string.Empty;
        //DateTime.Compare(,Dt.Date);
        if (register == "Student_In_Out" || register == "Laptop_In_Out" || register == "Vehicle_In_Out")
        {
            sql = String.Format("SELECT * FROM {0} WHERE In_Time <=", register);
            sql += "'" + Dt + "'";            
            sql += string.Format("AND Id = {0}", ID);

            //sql = String.Format("SELECT * FROM {0} WHERE In_Time < /'{1}"/', register,Dt);
        }
        else if (register == "Staff_In_Out" || register == "Faculty_In_Out" || register == "Visitor_Entry")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Out_Time <=", register);
            sql += "'" + Dt + "'";            
            sql += string.Format("AND Id = {0}", ID);
        }
        else if (register == "Complaint_Log")
        {
            sql = String.Format("SELECT * FROM {0} WHERE Time <=", register);
            sql += "'" + Dt + "'";
            sql += string.Format("AND Id = {0}", ID);
            //Complain Register.
        }
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.CommandType = CommandType.Text;
        SqlDataAdapter adp = new SqlDataAdapter(comm);
        adp.Fill(ds);
        conn.Close();
        return ds;
    }
        
    public static SqlDataReader GetInfo(string reg)
    {
        string sql = string.Format("SELECT * FROM {0}",reg);

        SqlConnection connect = connection.GetConnectionGE();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }

    public static SqlDataReader GetIn(string reg)
    {
        string sql = string.Format("SELECT * FROM {0}", reg);

        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }

    // Set the access permission level for various type of users.
    private static string accessLevel;
    public static string AccessLevel
    {
        get { return accessLevel; }
        set { accessLevel = value; }
    }

    private static string userName;
    public static string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    
    private static string boardID;
    public static string BoardID
    {
        get { return boardID; }
        set { boardID = value; }
    }

    //Update the Vehicle Information.
    public static void EditVehicleInfo(string UserName, string number, string company)
    {
        string sql = "UPDATE Vehicle_Registration SET Number=@number, Company=@company WHERE Id=@username";
        using (SqlConnection connect = connection.GetConnectionGE())
        {
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@number", number);
            command.Parameters.AddWithValue("@company", company);
            command.Parameters.AddWithValue("@username", Convert.ToInt64(UserName));
            command.ExecuteNonQuery();
        }    
    }
    
    //Update the Laptop Information 
   public static void EditLaptopInfo(string UserName, string serial, string brand, string room)
    {
        string sql = "UPDATE Laptop_Registration SET Serial=@serial, Brand=@brand, Room=@room WHERE Id=@username";
        using (SqlConnection connect = connection.GetConnectionGE())
        {
            SqlCommand command = new SqlCommand(sql, connect);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@serial", serial);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@room", room);
            command.Parameters.AddWithValue("@username", Convert.ToInt64(UserName));
            command.ExecuteNonQuery();
        }
        
     }

    //Get the roles from the Roles Table from Campus Connect Database
    public static SqlDataReader GetRolesInfo(string IdHint)
    {
        string sql = String.Format("SELECT * FROM Roles WHERE IDHint = {0}",IdHint);

        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }

    public static SqlDataReader GetNoticeBoardInfo(string name)
    {
        string sql = String.Format("SELECT * FROM Notice_Board WHERE Name='{0}'", name);
                
        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }

    public static int GetNoticeBoardID(string id)
    {
        string sql = String.Format("SELECT NBID FROM Notice_Board WHERE Moderator = {0}", id);

        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        if (reader.Read())
            return reader.GetInt32(0);
        else
            return 0;
    }
    public static bool DeleteBoard(string name)
    {
        int row = 0;
        string sql = string.Format("DELETE FROM Notice_Board WHERE Name = '{0}'", name);

        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        row = command.ExecuteNonQuery();

        connect.Close();

        if (row > 0)
            return true;
        return false;
    }

    public static void DeleteNotice(int NBID, int NID)
    {
        int row = 0;
        string sql = string.Format("DELETE FROM Notices WHERE NBID = {0} AND NID = {1}", NBID, NID);

        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        row = command.ExecuteNonQuery();
        connect.Close();
    }

    public static SqlDataReader GetNotices(int id)
    {
        string sql = String.Format("SELECT * FROM Notices WHERE NBID = {0} ORDER BY DateTime DESC", id);

        SqlConnection connect = connection.GetConnectionCC();
        SqlCommand command = new SqlCommand(sql, connect);
        command.CommandType = CommandType.Text;

        SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
        return reader;
    }
    public static bool CreateBoard(string Mod,string Name)
        {
            try
            {
            string sql = "INSERT INTO Notice_Board(Moderator,Name)"
         + "VALUES(@mod,@name)";
            
            SqlConnection connect = connection.GetConnectionCC();    
            SqlCommand command = new SqlCommand(sql, connect);            
            command.Parameters.AddWithValue("@mod",Mod);
            command.Parameters.AddWithValue("@name",Name);            
            command.CommandType = CommandType.Text;
            
            command.ExecuteNonQuery();
            connect.Close();
            return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
    }
    public static bool InsertNotice(string Nbid,string Sub, string bo,
        DateTime dt)
    {
        try
        {
            string sql = "INSERT INTO Notices(NBID,Subject,Body,DateTime)"
         + "VALUES(@Nbid,@Sub,@bo,@dt)";

            SqlConnection connect = connection.GetConnectionCC();
            SqlCommand command = new SqlCommand(sql, connect);
            command.Parameters.AddWithValue("@Nbid", Nbid);            
            command.Parameters.AddWithValue("@Sub", Sub);
            command.Parameters.AddWithValue("@bo", bo);
            command.Parameters.AddWithValue("@dt", dt);
            command.CommandType = CommandType.Text;

            command.ExecuteNonQuery();

            connect.Close();
            return true;
        }
        catch (SqlException ex)
        {
            return false;
        }
    }

}