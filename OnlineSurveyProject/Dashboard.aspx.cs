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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = string.Empty;

            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                username = reqCookies["UserName"].ToString();
          
            }

            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT FirstName,LastName FROM dbo.Users WHERE UserName=@UserName", connection);
                command.Parameters.AddWithValue("UserName",username);
                connection.Open();
                var reply = command.ExecuteReader();
                if (reply.HasRows)
                {
                    reply.Read();
                    string name ="Hello "+ reply["FirstName"].ToString() +" "+reply["LastName"].ToString()+"!";
                    userTxt.InnerText = name;
                }
                connection.Close();
    
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Logout.aspx");
        }
    }
}