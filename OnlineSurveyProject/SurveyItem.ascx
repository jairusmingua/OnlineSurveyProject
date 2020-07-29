<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyItem.ascx.cs" Inherits="OnlineSurveyProject.SurveyItem" %>

<div id="surveyItem" runat="server">
    <div style="display:inline-flex;">
        <div id="surveyBody">
            <div runat="server" id="surveyName">Name</div>
            <div runat="server" id="surveyDate">Date</div>
            <div runat="server" id="numberOfQuestions">5</div>
        </div>
        <div id="surveyButtons">
            <asp:Button ID="shareBtn" runat="server" Text="Share"  OnClick="shareBtn_Click"/>
            <asp:Button ID="viewBtn" runat="server" Text="View Results" OnClick="viewBtn_Click" />
        </div>
    </div>

</div>
