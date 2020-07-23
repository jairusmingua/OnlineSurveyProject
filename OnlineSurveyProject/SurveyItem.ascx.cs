using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class SurveyItem : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
            
        }

        public string SurveyID
        {
            set
            {
                surveyItem.Attributes.Add("sid",value.ToString());
            }
        }
        public string SurveyName
        {
            set
            {
                surveyName.InnerText = value.ToString();
           
            }
            
        }
        public string SurveyDate
        {
            set
            {
                surveyDate.InnerText = value.ToString();
            }
        }
        public string NumberOfQuestions
        {
            set
            {
                numberOfQuestions.InnerText = value.ToString();
            }
        }

        protected void shareBtn_Click(object sender, EventArgs e)
        {
            if(Page is Dashboard)
            {
                ((Dashboard)Page).showShareLink(surveyItem.Attributes["sid"],surveyName.InnerText.ToString());
            }
        }
    }
}