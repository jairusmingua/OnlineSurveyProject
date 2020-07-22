using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineSurveyProject
{
    public partial class Create : System.Web.UI.Page
    {
        protected int NumberOfControls
        {
            get { return Convert.ToInt32(Session["noCon"]); }
            set { Session["noCon"] = value.ToString(); }
        }
        protected string RecentQuestion
        {
            get { return Session[PlaceHolder1.ClientID + "question"].ToString(); }
            set { Session[PlaceHolder1.ClientID + "question"] = value; }
        }
   
        protected void Page_Init(object sender, EventArgs e)
        {

           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Initiate the counter of dynamically added controls
                this.NumberOfControls = 1;
                this.RecentQuestion = "";
                this.createControls();
            }
            else
            {
                //Controls must be repeatedly be created on postback
                var x = PlaceHolder1.Controls;
                this.createControls();
            }
        }
        protected void Page_PreInit(object sender, EventArgs a)
        {
            try {
                var x = PlaceHolder1.Controls;    
            } catch(Exception e)
            {

            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Control c = Page.LoadControl("~/QuestionBox.ascx");
            c.ID = "questionBox" + NumberOfControls;
            NumberOfControls++;
            PlaceHolder1.Controls.Add(c);
        }
        private void createControls()
        {
            int count = this.NumberOfControls;

            for (int i = 0; i < count; i++)
            {
                Control c = Page.LoadControl("~/QuestionBox.ascx");
                c.ID = "txtData" + i.ToString();
                //Add the Controls to the container of your choice
                PlaceHolder1.Controls.Add(c);
            }
        }

        protected void submitQuestionnaire_Click(object sender, EventArgs e)
        {
            List<QuestionBox> questions = PlaceHolder1.Controls.OfType<QuestionBox>().ToList();

            XElement survey = new XElement("Survey");

            foreach (QuestionBox question in questions)
            {
                var q = question.QuestionText;
                var c = question.GetChoices();
                XElement qs = new XElement("Question");
                qs.SetAttributeValue("ChoiceCount", c.Count().ToString());
                qs.SetAttributeValue("QuestionText", q);
                qs.SetAttributeValue("QuestionID", Guid.NewGuid());
                foreach(string c_ in c)
                {
                    XElement x = new XElement("Choice");
                    x.SetAttributeValue("ChoiceText", c_);
                    x.SetAttributeValue("ChoiceID", Guid.NewGuid());
                    qs.Add(x);
                }
                survey.Add(qs);


            }
            try
            {
                string userid = string.Empty;

                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if (reqCookies != null)
                {
                    userid = reqCookies["UserID"].ToString();
                    submitSurvey(userid,surveyNameTxt.Value,survey,questions.Count);
                }
                else
                {
                    Response.Redirect("/Logout.aspx");
                }

            }
            catch (Exception x)
            {

                throw;
            }
        }
        private void submitSurvey(string userid,string surveyName,XElement surveyXml,int numberOfQuestions)
        {
            
            try
            {
               
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("CreateSurveyXML", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = Guid.Parse(userid);
                command.Parameters.Add("SurveyName", SqlDbType.VarChar).Value = surveyName;
                command.Parameters.Add("NumberOfQuestions", SqlDbType.Int).Value = numberOfQuestions.ToString();
                command.Parameters.Add("SurveyXML", SqlDbType.Xml).Value = surveyXml.ToString();

                connection.Open();
                var reply = command.ExecuteReader();
                connection.Close();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}