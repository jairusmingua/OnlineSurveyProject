using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String connectionString =  ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("INSERT INTO dbo.Users (FirstName,LastName,UserName,Email,Password,UserID) VALUES(@FirstName,@LastName,@UserName,@Email,@Password,@UserID)",connection);
                command.Parameters.AddWithValue("FirstName", firstNameTxt.Value.ToString());
                command.Parameters.AddWithValue("LastName", lastNameTxt.Value.ToString());
                command.Parameters.AddWithValue("UserName", usernameTxt.Text.ToString());
                command.Parameters.AddWithValue("Email", emailTxt.Value.ToString());
                command.Parameters.AddWithValue("Password", passwordTxt.Value.ToString());
                command.Parameters.AddWithValue("UserID", Guid.NewGuid());

                connection.Open();
                var reply = command.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("/Default.aspx");
            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        protected void usernameTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT UserName FROM dbo.Users WHERE UserName=@UserName", connection);
                command.Parameters.AddWithValue("UserName", usernameTxt.Text.ToString());
                connection.Open();
                var reply = command.ExecuteReader();
                if (reply.HasRows)
                {
                    validationLbl.InnerText = "Username already exists!!!";
                }
                else
                {
                    validationLbl.InnerText="";
                }
                connection.Close();
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
    }
}