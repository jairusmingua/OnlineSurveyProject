using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = string.Empty;

            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                reqCookies.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(reqCookies);
                Response.Redirect("/Default.aspx");
            }
         

        }
    }
}