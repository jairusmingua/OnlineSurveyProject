<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RespondBox.ascx.cs" Inherits="OnlineSurveyProject.RespondBox" %>
<div>
    <p runat="server" id="questionTxt"></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
