using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class QuestionItem : System.Web.UI.UserControl
    {
        public string  ChoiceText
        {
            get
            {
                return choicetext.InnerText.ToString();
            }
            set
            {
                choicetext.InnerText = value.ToString();
            }
        }
        public void setChoiceResult(int total,int result)
        {
            choiceresult.InnerText = result.ToString();
            double percent = ((double)result / (double)total) *(double)100;
            choicegraph.InnerHtml = "<div style='height:100%; width: "+((int)percent).ToString()+ "%; background-color: #048E68;'></div>";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}