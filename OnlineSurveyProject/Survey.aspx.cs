using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class Survey : System.Web.UI.Page
    {
        protected int SurveyID(string name)
        {
            get { return Convert.ToInt32(Session[]); }
            set { Session[] = value.ToString(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            errorPanel.Visible = false;
            surveyPanel.Visible = false;
            var surveyId = Request.QueryString;
            if (surveyId != null && surveyId.Count > 0)
            {
                string id = surveyId.Get("id");
                if (id != null)
                {
                    validateSurvey(id);
                }
            }
            else
            {
                errorSurvey();
            }
        }
        private void errorSurvey()
        {
            errorPanel.Visible = true;
            surveyPanel.Visible = false;
        }
        private void validateSurvey(string id)
        {
            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("GetSurveyFromID", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("SurveyID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(id);
                connection.Open();
                var reply = command.ExecuteReader();
                if (reply != null)
                {
                    reply.Read();
                    showSurveyIntro(reply);
                }
                connection.Close();
            }
            catch (Exception x)
            {
                
            }
        }
        private void showSurveyIntro(SqlDataReader id)
        {
            surveyName.InnerText = id["SurveyName"].ToString();
            errorPanel.Visible = false;
            surveyPanel.Visible = true;
        }
    }
}