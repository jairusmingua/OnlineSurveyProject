<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineSurveyProject.Dashboard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div>
            <h1 id="userTxt" runat="server"></h1>
            <asp:Button runat="server" id="logoutBtn" OnClick="logoutBtn_Click" Text="Logout"/>
            <asp:Button runat="server" id="createSurveyBtn" OnClick="createSurveyBtn_Click" Text="Create Survey"/>
            
        </div>
        <div id="surveyList" runat="server"></div>


</asp:Content>