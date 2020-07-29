<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OnlineSurveyProject.View" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="viewPanel" runat="server">
        <div>
            <h1 runat="server" id="surveyName"></h1>
        </div>
        <asp:Panel ID="resultsPanel" runat="server">

        </asp:Panel>
        <asp:Button ID="prevBtn" runat="server" Text="<" OnClick="prevBtn_Click"/>
        <asp:Button ID="nextBtn" runat="server" Text=">"  OnClick="nextBtn_Click"/>
    </asp:Panel>
    <asp:PlaceHolder ID="errorPanel" runat="server">
                <div id="errorBoard">
                    <div class="jumbotron">
                        <h3 class="display-4">Inavlid Survey</h3>
                        <p class="lead">Please take a look at the link and try again.</p>
                    </div>
                </div>
    </asp:PlaceHolder>
</asp:Content>
