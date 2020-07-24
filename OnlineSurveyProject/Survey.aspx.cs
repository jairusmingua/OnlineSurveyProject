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
        private string SurveyState
        {
            set
            {
                Session["SurveyState"] = value.ToString();
            }
            get
            {
                return Session["SurveyState"].ToString();
            }
            
        }
        private int QuestionNumber
        {
            set
            {
                Session["QuestionNumber"] = value.ToString();
            }
            get
            {
                return Convert.ToInt32(Session["QuestionNumber"]);
            }

        }
        private int MaxQuestion
        {
            set
            {
                Session["MaxQuestion"] = value.ToString();
            }
            get
            {
                return Convert.ToInt32(Session["MaxQuestion"]);
            }

        }

        private string SurveyID
        {
            set
            {
                Session["SurveyID"] = value.ToString();
            }
            get
            {
                return Session["SurveyID"].ToString();

            }
        }
        private string RespondentName
        {
            set
            {
                Session["RespondentName"] = value.ToString();
            }
            get
            {
                return Session["RespondentName"].ToString();
            }
        }
        private string RespondentAge
        {
            set
            {
                Session["RespondentAge"] = value.ToString();
            }
            get
            {
                return Session["RespondentAge"].ToString();
            }
        }
        private string RespondentGender
        {
            set
            {
                Session["RespondentGender"] = value.ToString();
            }
            get
            {
                return Session["RespondentGender"].ToString();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
           

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var surveyId = Request.QueryString;
          
            if (!Page.IsPostBack)
            {
                errorPanel.Visible = false;
                surveyPanel.Visible = false;
                filloutPanel.Visible = false;
                List<String> gender = new List<String>();
                gender.Add("Male");
                gender.Add("Female");
                genderList.DataSource = gender;
                genderList.DataBind();
                SurveyState = "surveyPanel";
                QuestionNumber = 1;
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
            else
            {
                if (SurveyState == "filloutPanel")
                {
                    filloutPanel.Visible = true;
                    surveyPanel.Visible = false;
                    errorPanel.Visible = false;
                    
                    loadQuestion();
                }
            }
            
        }

        private void loadQuestion()
        {
            Control respondBox = Page.LoadControl("~/RespondBox.ascx");
            respondPanel.Controls.Add(respondBox);
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
                SurveyID = id;
            }
            catch (Exception x)
            {
                
            }
        }
        private void showSurveyIntro(SqlDataReader id)
        {
            surveyName.InnerText = id["SurveyName"].ToString();
            MaxQuestion = Convert.ToInt32(id["NumberOfQuestions"]);
            errorPanel.Visible = false;
            surveyPanel.Visible = true;
            takeSurveyBtn.Enabled = false;
        }

        protected void agreeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (agreeCheckBox.Checked == true)
            {
                takeSurveyBtn.Enabled = true;
            }
            else
            {
                takeSurveyBtn.Enabled = false;
            }
        }

        protected void takeSurveyBtn_Click(object sender, EventArgs e)
        {
            SurveyState = "filloutPanel";
            filloutPanel.Visible = true;
            surveyPanel.Visible = false;
            errorPanel.Visible = false;
            
            RespondentName = nameTxt.Text.ToString();
            RespondentAge = ageTxt.Text.ToString();
            RespondentGender = genderList.SelectedValue;

            loadQuestion();
        }

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            QuestionNumber++;
            RespondBox c = respondPanel.Controls.OfType<RespondBox>().ToArray()[0];
            ((RespondBox)c).submitResponse();
            ((RespondBox)c).reloadResponse();
        }
    }
}