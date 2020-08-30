using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactDesktopApplication.ContactClasses
{
    class Contact
    {
        //This will act as a Data carrier in this application
        //Getter and Setter properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        //static method to connect database to create a database connection
        static string myconnstring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        //creating a method to select data from database and display it in DataGridView
        public DataTable Select()
        {
            //Database connection
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                //SQL Query
                string sql = "SELECT * FROM tb_Contact";
                //Creating SQL command using sql and conn
                SqlCommand cmd = new SqlCommand(sql,conn);
                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Opening Database Connection
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return dt;
        }
        //Inserting Data in Database
        public bool Insert(Contact c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;
            //Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //Create a SQL Query to insert Data
                string sql = "INSERT tbl_Contact (FirstName, LastName, MobileNumber, Address, Gender) VALUES (@FirstName, @LastName, @MobileNumber, @Address, @Gender)";
                //Creating SQL command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName",c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@MobileNumber", c.MobileNumber);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                //Opening Database Connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess=false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return isSuccess;
        }

        //Method to Update Database in this application
        public bool Update(Contact c)
        {
            //Create a default return type and sets its default value to false
            bool isSuccess = false;
            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //SQL to update data in the database
                string sql = "UPDATE tbl_Contact SET FirstName=@FirstName, LastName=@LastName, MobileNumber=@MobileNumber, Address=@Address, Gender=@Gender WHERE ID=@ID";
                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameter to add value
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@MobileNumber", c.MobileNumber);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ID", c.ID);

                //Opening Database Connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return isSuccess;
        }
        //Method to Delete Data from Database
        public bool Delete(Contact c)
        {
            //Create a default return value and set its value to false
            bool isSuccess = false;
            //Creating SQL Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //SQL to delete data
                string sql = "DELETE FROM tb_Contact WHERE ID=@ID";
                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return isSuccess;
        }
    }
}
