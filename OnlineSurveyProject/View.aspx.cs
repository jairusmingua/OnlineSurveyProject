﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineSurveyProject
{
    public partial class View : System.Web.UI.Page
    {
        private string NumberOfQuestions
        {
            get
            {
                return Session["NumberOfQuestions_View"].ToString();
            }
            set
            {
                Session["NumberOfQuestions_View"] = value.ToString();
            }
        }
        private string CurrentQuestion
        {
            get
            {
                return Session["CurrentQuestion_View"].ToString();
            }
            set
            {
                Session["CurrentQuestion_View"] = value.ToString();
            }
        }
        private string SurveyID
        {
            get
            {
                return Session["SurveyID_View"].ToString();
            }
            set
            {
                Session["SurveyID_View"] = value.ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var surveyId = Request.QueryString;
            if (surveyId.Get("id") != null && surveyId.Get("q") != null)
            {
                validateUser(surveyId.Get("id"));
                SurveyID = surveyId.Get("id");
                errorPanel.Visible = false;
                try
                {
                    String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand("ViewQuestionResult", connection);
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("SurveyID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(surveyId.Get("id").ToString());
                    command.Parameters.Add("QuestionNumber", System.Data.SqlDbType.Int).Value = Convert.ToInt32(surveyId.Get("q"));
                    //connection.Open();
                    da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    if (da != null)
                    {








                        int totalrespondents = Convert.ToInt32(ds.Tables[1].Rows[0][0]);

                        foreach(DataRow row in ds.Tables[0].Rows)
                        {
                            if (row["ChoiceText"].ToString() == "")
                            {
                                break;
                            }
                            surveyName.InnerText = row["SurveyName"].ToString();
                            NumberOfQuestions = row["NumberOfQuestions"].ToString();
                            CurrentQuestion = row["QuestionRank"].ToString();
                            questionText.InnerText = row["Question"].ToString();
                            if (row["QuestionRank"].ToString() == "1")
                            {
                                
                                prevBtn.Enabled = false;
                            }
                            else
                            {
                                prevBtn.Enabled = true;
                            }
                            if (row["QuestionRank"].ToString() == row["NumberOfQuestions"].ToString())
                            {
                                nextBtn.Enabled = false;
                            }
                            else
                            {
                                nextBtn.Enabled = true;
                            }
                            Control t = Page.LoadControl("~/QuestionItem.ascx");
                            ((QuestionItem)t).ChoiceText = row["ChoiceText"].ToString();
                            ((QuestionItem)t).setChoiceResult(totalrespondents,Convert.ToInt32(row["ResponseCount"]));
                            respondentCount.InnerText = totalrespondents.ToString();
                            resultsPanel.Controls.Add(t);
                        }






                        //while (reply.Read())
                        //{
                        //    if (reply["ChoiceText"].ToString() == "")
                        //        break;
                        //    t = Page.LoadControl("~/QuestionItem.ascx");
                        //    ((QuestionItem)t).ChoiceText = reply["ChoiceText"].ToString();
                        //    ((QuestionItem)t).ChoiceResult += " " + reply["ResponseCount"].ToString();
                        //    totalRespondents += Convert.ToInt32(reply["ResponseCount"].ToString());
                        //    resultsPanel.Controls.Add(t);

                        //}
                        //t = new Label();
                        respondentCount.InnerText = totalrespondents.ToString();
                        //resultsPanel.Controls.Add(t);
                    }
                    connection.Close();

                }
                catch (Exception x)
                {

                }
            }
            else if (surveyId.Get("error") != null)
            {
                viewPanel.Visible = false;
                errorPanel.Visible = true;
            }
        }

        private void validateUser(string id)
        {
            string userid = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                userid = reqCookies["UserID"].ToString();

            }
            else
            {
                Response.Redirect("View?error=1");
            }

            try
            {
                String connectionString = ConfigurationManager.ConnectionStrings["OnlineSurvey"]?.ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT SurveyID,UserID FROM dbo.Surveys WHERE SurveyID=@SurveyId", connection);
                command.Parameters.AddWithValue("SurveyId", id);
                connection.Open();
                var reply = command.ExecuteReader();
                if (reply.HasRows)
                {
                    reply.Read();
                    if (reply["UserID"].ToString() != userid)
                        Response.Redirect("View?error=1");
                }
                else
                {
                    Response.Redirect("View?error=1");
                }
                connection.Close();


            }
            catch (Exception x)
            {
                
            }
        }

        protected void prevBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("View?id=" + SurveyID + "&q=" + (Convert.ToInt32(CurrentQuestion) - 1));
        }

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            int next = Convert.ToInt32(CurrentQuestion);
            Response.Redirect("View?id=" + SurveyID + "&q=" +(next+1));
        }
    }
}