using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class Dashboard : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = string.Empty;

            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                userid = reqCookies["UserID"].ToString();
          
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT FirstName,LastName FROM dbo.Users WHERE UserID=@UserId", connection);
                command.Parameters.AddWithValue("UserID",userid);
                connection.Open();
                var reply = command.ExecuteReader();
                if (reply.HasRows)
                {
                    reply.Read();
                    string name ="Hello "+ reply["FirstName"].ToString() +" "+reply["LastName"].ToString()+"!";
                    this.Master.setDashboardIdentity(name);
                }
                connection.Close();
                
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            getSurveyList(userid);
        }
        private void getSurveyList(String userid)
        {
            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("GetSurveyOfUserList", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("UserID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(userid);
                connection.Open();
                var reply = command.ExecuteReader();
                convertSurveyList(reply);
                connection.Close();
            }
            catch (Exception x)
            {

            }
        }
        private void convertSurveyList(SqlDataReader response)
        {
            StringBuilder surveyHtml = new StringBuilder();
            surveyHtml.Append("<ul>");
            while (response.Read())
            {
                surveyHtml.AppendFormat("<li><div>{0}</div>" +
                    "<div>{1}</div>" +
                    "<div>{2}</div></li>", 
                    response["SurveyName"].ToString(), 
                    response["DateCreated"].ToString(), 
                    response["NumberOfQuestions"].ToString());

            }
            surveyHtml.Append("</ul>");
            surveyList.InnerHtml = surveyHtml.ToString();
        }
        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Logout.aspx");
        }

        protected void createSurveyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Create.aspx");
        }
    }
}