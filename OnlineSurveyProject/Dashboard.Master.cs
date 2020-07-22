using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class Dashboard1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void setDashboardIdentity(string name)
        {
            username.InnerText = name;
        }
    }
}