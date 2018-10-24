using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Member
/// </summary>
public class Member
{
    public string UserName {get;set;}
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public DateTime? DateofBirth { get; set; }

    public void AddMember()
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();
        //Prepare SQL Command with parameter
        string sql = "Insert into Member values(@username,@pwd, @role,@fname,@lname,@gender,@email,@dob)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("username", this.UserName);
        cmd.Parameters.AddWithValue("pwd", this.Password);
        cmd.Parameters.AddWithValue("role", this.Role);
        cmd.Parameters.AddWithValue("fname", this.FirstName);
        cmd.Parameters.AddWithValue("lname", this.LastName);
        cmd.Parameters.AddWithValue("email", this.Email);
       
        //handling null values for gender and date of birth column
        if (this.Gender != null)
        {
            cmd.Parameters.AddWithValue("gender", this.Gender);
        }
        else
        {
            cmd.Parameters.AddWithValue("gender", DBNull.Value);
        }

        if (this.DateofBirth != null)
        {
            cmd.Parameters.AddWithValue("dob", this.DateofBirth);
        }
        else
        {
            cmd.Parameters.AddWithValue("dob", DBNull.Value);
        }
       
        //Execute Command
        cmd.ExecuteNonQuery();
    }

    public void UpdateMember()
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();
        //Prepare SQL Command with parameter
        string sql = "Update Member set firstname= @fname,lastname=@lname,gender=@gender,email=@email,dateofbirth=@dob where username=@username";
        SqlCommand cmd = new SqlCommand(sql, conn);


        cmd.Parameters.AddWithValue("@username", this.UserName);
        cmd.Parameters.AddWithValue("fname", this.FirstName);
        cmd.Parameters.AddWithValue("lname", this.LastName);
        cmd.Parameters.AddWithValue("email", this.Email);

        //handling null values for gender and date of birth column
        if (this.Gender != null)
        {
            cmd.Parameters.AddWithValue("gender", this.Gender);
        }
        else
        {
            cmd.Parameters.AddWithValue("gender", DBNull.Value);
        }

        if (this.DateofBirth != null)
        {
            cmd.Parameters.AddWithValue("dob", this.DateofBirth);
        }
        else
        {
            cmd.Parameters.AddWithValue("dob", DBNull.Value);
        }

        //Execute Command
        cmd.ExecuteNonQuery();
    }
    public static DataTable LoginUser(string UserName)
    {
        //Open Database connection
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Config.GetConnectionStr();
        conn.Open();

        //Prepare SQL Command with parameter
        // Get all users with provided the UserName provided in the parameter
        string sql = "Select * from Member Where UserName = @username";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("username", UserName); 

        // Create data adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //Create a DataTable that will store the result of the query
        DataTable dt = new DataTable();
        // this will query your database and return the result to your datatable
        da.Fill(dt);

        //Close connection and release the data adapter
        conn.Close();
        da.Dispose();

        //return the Datatable
        return dt;
    }
	public Member()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}