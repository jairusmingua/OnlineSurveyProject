<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyItem.ascx.cs" Inherits="OnlineSurveyProject.SurveyItem" %>


<li>
    <div class="row surveyItem" runat="server" id="surveyItem">
        <div class="col-lg-3 col-md-3 surveyName" id="surveyName" runat="server"></div>
        <div class="col-lg-3 col-md-3 surveyQuestions" id="numberOfQuestions" runat="server"></div>
        <div class="col-lg-4 col-md-3 d-none d-md-block surveyCreated" id="surveyDate" runat="server"></div>
        <div class="col-lg-2 col-md-3 text-right surveyButtonGroup">
            <asp:Button ID="Button1" runat="server" Text="Share"  OnClick="shareBtn_Click" CssClass="ol-buttons-secondary-green"/>
            <asp:Button ID="Button2" runat="server" Text="View Results" OnClick="viewBtn_Click" CssClass="ol-buttons-secondary-black" />
        </div>
    </div>
</li>
