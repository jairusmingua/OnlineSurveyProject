using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Page_PreInit(object sender, EventArgs a)
        {
            try {
                List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("questionBox")).ToList();
            } catch(Exception e)
            {

            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Control c = Page.LoadControl("~/QuestionBox.ascx");
            c.ID = "questionBox" + NumberOfControls;
            NumberOfControls++;
            if (NumberOfControls > 0)
                ((QuestionBox)c).QuestionText = RecentQuestion;
            PlaceHolder1.Controls.Add(c);
        }
        private void createControls()
        {
            int count = this.NumberOfControls;

            for (int i = 0; i < count; i++)
            {
                Control c = Page.LoadControl("~/QuestionBox.ascx");
                c.ID = "txtData" + i.ToString();
                if (i == count - 1)
                {
                    ((QuestionBox)c).QuestionText = RecentQuestion;
                }
                //Add the Controls to the container of your choice
                PlaceHolder1.Controls.Add(c);
            }
        }
        
    }
}