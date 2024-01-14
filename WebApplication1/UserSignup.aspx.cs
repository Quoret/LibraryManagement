using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(userExists())
            {
                Response.Write("<script>alert('Member with id "+TextBox5.Text.Trim()+" already exists. Try again with new member Id');</script>");
            }
            else
            {
                signUpNewMember();
            }
            
 
        }
        bool userExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open(); 
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + TextBox5.Text.Trim() + "';",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt=new DataTable(); // temporarily stores number of records while selected from the select query
                da.Fill(dt);                  
                if(dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
                return false;
            }
        }
            
        void signUpNewMember()
        {
            try
            {
                //using a inbuilt class of SQL connections
                SqlConnection con = new SqlConnection(strcon); //creating a object "con" of SqlConnections type
                //to check either the connection is open with the database or not
                if (con.State == ConnectionState.Closed)
                {
                    con.Open(); // edi close cha bhane esle database sanga connection open gardincha
                }
                // con is a valid SqlConnection object
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl (full_name, dob, contact_no, email, state, city, pincode, full_address, member_id, password, account_status) VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status)", con);

                // i have parameters defined for the values to be inserted
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "Pending");

                //  con is opened somewhere before this code
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign up successful. Go to user login to login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}