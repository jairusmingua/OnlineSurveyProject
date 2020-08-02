using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace OnlineSurveyProject
{
    public class Choice
    {
        private string ChoiceID_;
        private string ChoiceText_;
        private int ChoiceRank_;

  
        public string ChoiceID
        {
            get
            {
                return ChoiceID_;
            }
            set
            {
                ChoiceID_ = value;
            }
        }
        public int ChoiceRank
        {
            get
            {
                return this.ChoiceRank_;
            }
            set
            {
                ChoiceRank_ = value;
            }
        }
        public string ChoiceText
        {
            get
            {
                return ChoiceText_;
            }
            set
            {
                ChoiceText_ = value;
            }
        }
    }
    public partial class RespondBox : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Panel1.Controls.Clear();
                reloadResponse();
            }
            catch
            {

            }
        }
        public void reloadResponse()
        {
            clearResponseBox();
            string surveyId = Session["SurveyID"].ToString();
            int questionNumber = Convert.ToInt32(Session["QuestionNumber"]);
            if (surveyId != null)
            {
                if (questionNumber <= Convert.ToInt32(Session["MaxQuestion"]))
                {
                    getQuestion(surveyId, questionNumber);

                }
                else
                {
                    Response.Redirect("/Done.aspx");
                }
            }
        }
        private void getQuestion(string surveyId, int questionNumber)
        {
            try
            {

                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("GetQuestionFromSurvey", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("SurveyID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(surveyId);
                command.Parameters.Add("QuestionRank", SqlDbType.Int).Value = questionNumber;
   

                connection.Open();
                System.Xml.XmlReader r = command.ExecuteXmlReader();
                XmlDocument document = new XmlDocument();
                document.Load(r);
                connection.Close();
                formatXML(document);
            

            }
            catch (Exception e)
            {
                Response.Redirect("/Default.aspx");
                throw;
            }
        }
        public void submitResponse()
        {
            try
            {
            string choiceId ="";
            foreach(RadioButton x in Panel1.Controls.OfType<RadioButton>().ToArray())
            {
                if (x.Checked)
                {
                    choiceId = x.Attributes["ChoiceID"];
                    break;
                }
            }
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("IncrementChoice", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("ChoiceID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(choiceId);


                connection.Open();
                command.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                throw;
            }

        }
        public void clearResponseBox()
        {
            questionTxt.InnerText = "";

            Panel1.Controls.Clear();
        }
        private void formatXML(XmlDocument document)
        {
            string question = document.FirstChild.FirstChild.Attributes["Question"].Value.ToString();
            List<Choice> choices = new List<Choice>();
            foreach (XmlNode c in document.FirstChild.FirstChild.ChildNodes)
            {
                Choice _c = new Choice();
                _c.ChoiceID = c.Attributes["ChoiceID"].Value.ToString();
                _c.ChoiceRank = Convert.ToInt32(c.Attributes["ChoiceRank"].Value);
                _c.ChoiceText = c.Attributes["ChoiceText"].Value.ToString();
                choices.Add(_c);
            }
            for(int i = 1; i <= choices.Count; i++)
            {
                Choice x = choices.Where(c_ => c_.ChoiceRank == i).ToArray()[0];
                if(x.ChoiceText != "")
                {
                    RadioButton rb = new RadioButton();
                    rb.Attributes["ChoiceID"] = x.ChoiceID;
                    rb.Text = x.ChoiceText;
                    rb.AutoPostBack = true;
                    rb.GroupName = "Choices";
                    Panel1.Controls.Add(rb);
                    Panel1.Controls.Add(new LiteralControl("<br/>"));

                }
            }
            questionTxt.InnerText = question;
        }
    }
}