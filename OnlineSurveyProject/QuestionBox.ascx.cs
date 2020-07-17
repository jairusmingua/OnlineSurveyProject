using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class QuestionBox : System.Web.UI.UserControl
    {
        protected int NumberOfChoices
        {
            get { return Convert.ToInt32(Session[Panel1.ClientID]); }
            set { Session[Panel1.ClientID] = value.ToString(); }
        }
        protected string RecentChoice
        {
            get { return Session[Panel1.ClientID+"choice"].ToString(); }
            set { Session[Panel1.ClientID+"choice"] = value; }
        }
        public string QuestionText
        {
            set
            {
                TextBox1.Text = value;
            }
            get
            {
                return TextBox1.Text.ToString();
            }
        }
        public string [] GetChoices()
        {
            return Panel1.Controls.OfType<TextBox>().Select(x => x.Text).ToArray(); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.NumberOfChoices = 0;

    
            }
                //Initiate the counter of dynamically added controls

            else
                //Controls must be repeatedly be created on postback
                this.createChoice();
        }

        protected void btnCreateChoice_Click(object sender, EventArgs e)
        {
            TextBox c = new TextBox();
            c.ID = "questionChoice" + NumberOfChoices;
            //List<TextBox> recentTextBox = PlaceHolder1.Controls.OfType<TextBox>().ToList();
            //if(NumberOfChoices!=0)
            //    RecentChoice=recentTextBox[NumberOfChoices-1].Text;
            NumberOfChoices++;
            Panel1.Controls.Add(c);
            
        }

        private void createChoice()
        {
            int count = this.NumberOfChoices;

            for (int i = 0; i < count; i++)
            {
                TextBox c = new TextBox();
                c.ID = "txtData" + i.ToString();
                //if (i == count - 1)
                //{
                //    c.Text = RecentChoice;
                //}
                //Add the Controls to the container of your choice
                Panel1.Controls.Add(c);
                
            }
        }
    }
}