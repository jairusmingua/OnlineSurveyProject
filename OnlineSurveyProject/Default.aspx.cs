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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            
             try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT UserName FROM dbo.Users WHERE UserName =@UserName AND Password =@Password", connection);
                command.Parameters.AddWithValue("UserName", usernameTxt.Value.ToString());
                command.Parameters.AddWithValue("Password", passwordTxt.Value.ToString());
 
                connection.Open();
                var reply = command.ExecuteReader();
                if (reply.HasRows)
                {
                    reply.Read();
                    loginpromptLbl.InnerText = "";
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserName"] = reply["UserName"].ToString();
                    userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                    Response.Cookies.Add(userInfo);
                    Response.Redirect("/Dashboard.aspx");
                }
                else
                {
                    loginpromptLbl.InnerText = "Username or password is incorrect";
                   
                }
                connection.Close();
            }
            catch (Exception x)
            {
                loginpromptLbl.InnerText = "Username or password is incorrect";
            }
        }
    }
}