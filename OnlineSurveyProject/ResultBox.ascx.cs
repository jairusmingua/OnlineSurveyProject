using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class ResultBox : System.Web.UI.UserControl
    {
        public string ChoiceText
        {
            get
            {
                return choicetext.InnerText;
            }
            set
            {
                choicetext.InnerText = value.ToString();
            }
        }
        public string ChoiceResult
        {
            get
            {
                return choiceresult.InnerText;
            }
            set
            {
                choiceresult.InnerText = value.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}