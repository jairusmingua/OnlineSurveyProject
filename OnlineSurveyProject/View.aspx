<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="OnlineSurveyProject.View" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:Panel ID="viewPanel" runat="server">
        <div>
            <h1 runat="server" id="surveyName"></h1>
        </div>
        <asp:Panel ID="resultsPanel" runat="server">

        </asp:Panel>
        <asp:Button ID="prevBtn" runat="server" Text="<" OnClick="prevBtn_Click"/>
        <asp:Button ID="nextBtn" runat="server" Text=">"  OnClick="nextBtn_Click"/>
    </asp:Panel>--%>
    <asp:Panel ID="viewPanel" runat="server" CssClass="container">
    <div class="row mt-3">
        <div class="col-12 mt-0">
            <h1 class="mb-2">View Survey</h1>
        </div>
        <div class="col-12 text-left pt-lg-3" runat="server" id="surveyName">
           
        </div>
    </div>
    <div class="row viewBox mt-4 px-5">
        <div class="row viewheader mt-5 mb-5 pl-2">
            <h2 runat="server" id="surveyQuestion"></h2>
        </div>
        <div class="row viewresult mb-4">
            <asp:Panel ID="resultsPanel" runat="server" CssClass="col-12 col-md-6 choicelist">
            </asp:Panel>
            <div class="col-12 col-md-6 viewgraph">
            </div>
        </div>
        <div class="row viewfooter my-5">
            <div class="col-6 respondentcount">
                Number of Respondents:
                    <b runat="server" id="respondentNumber"></b>
            </div>
            <div class="col-6 text-right viewbuttons">
                <asp:Button ID="prevBtn" runat="server" Text="<" OnClick="prevBtn_Click" CssClass="ol-buttons-secondary-black" />
                <asp:Button ID="nextBtn" runat="server" Text=">" OnClick="nextBtn_Click" CssClass="ol-buttons-secondary-black" />
            </div>
        </div>
    </div>
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
