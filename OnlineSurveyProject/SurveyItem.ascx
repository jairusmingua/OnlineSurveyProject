<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyItem.ascx.cs" Inherits="OnlineSurveyProject.SurveyItem" %>

<%--<div id="surveyItem" runat="server">
    <div style="display: inline-flex;">
        <div id="surveyBody">
            <div runat="server" id="surveyName">Name</div>
            <div runat="server" id="surveyDate">Date</div>
            <div runat="server" id="numberOfQuestions">5</div>
        </div>
        <div id="surveyButtons">
            <asp:Button ID="shareBtn" runat="server" Text="Share" OnClick="shareBtn_Click" />
            <asp:Button ID="viewBtn" runat="server" Text="View Results" OnClick="viewBtn_Click" />
        </div>
    </div>

</div>
--%>

<li>
    <div class="row surveyItem" runat="server" id="surveyItem">
        <div class="col-lg-3 col-md-3 surveyName" runat="server" id="surveyName">VCO Survey</div>
        <div class="col-lg-3 col-md-3 surveyQuestions" runat="server" id="numberOfQuestions">5 Questions</div>
        <div class="col-lg-4 col-md-3 d-none d-md-block surveyCreated" runat="server" id="surveyDate">Date Created: July 20,2020</div>
        <div class="col-lg-2 col-md-3 text-right surveyButtonGroup">
            <asp:Button ID="Button1" runat="server" Text="" OnClick="shareBtn_Click" CssClass="ol-buttons-secondary-black"/>
            <asp:Button ID="Button2" runat="server" Text="" OnClick="viewBtn_Click" CssClass="ol-buttons-secondary-green"/>
        </div>
    </div>
</li>
