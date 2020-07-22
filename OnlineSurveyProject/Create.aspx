<%@ Page Title="Create" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="OnlineSurveyProject.Create" %>

<%@ Register Src="~/QuestionBox.ascx" TagName="QuestionBox" TagPrefix="OnlineSurvey" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="form-group">
            <label for="exampleInputEmail1">Survey Name</label>
            <input type="text" class="form-control" id="surveyNameTxt" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click"/>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:Button ID="submitQuestionnaire" runat="server" Text="Create" OnClick="submitQuestionnaire_Click"/>
    
</asp:Content>


