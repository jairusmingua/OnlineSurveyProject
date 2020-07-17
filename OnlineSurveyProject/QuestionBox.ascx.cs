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
            get { return Convert.ToInt32(Session[PlaceHolder1.ClientID]); }
            set { Session[PlaceHolder1.ClientID] = value.ToString(); }
        }
        protected string RecentChoice
        {
            get { return Session[PlaceHolder1.ClientID+"choice"].ToString(); }
            set { Session[PlaceHolder1.ClientID+"choice"] = value; }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.NumberOfChoices = 1;
                this.RecentChoice = "";
                this.createChoice();
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
            PlaceHolder1.Controls.Add(c);
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
                PlaceHolder1.Controls.Add(c);
            }
        }
    }
}