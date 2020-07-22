<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineSurveyProject.Dashboard" %>
<%@ MasterType VirtualPath="~/Dashboard.Master" %>
<%@ Register Src="~/SurveyItem.ascx" TagName="SurveyItem" TagPrefix="OnlineSurvey" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h1>Surveys</h1>
            
        </div>
        <div id="surveyList" runat="server"></div>
        <asp:Button runat="server" id="createSurveyBtn" OnClick="createSurveyBtn_Click" Text="Create Survey"/>

        <asp:Panel ID="sharePanel" runat="server">

       
        <Onlin
</asp:Content>