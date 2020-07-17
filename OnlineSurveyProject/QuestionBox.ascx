<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionBox.ascx.cs" Inherits="OnlineSurveyProject.QuestionBox" %>
<div class="questionPanel">
    Question<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnCreateChoice" runat="server" Text="Add Choice" OnClick="btnCreateChoice_Click"/>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="choicePanel">
                    </asp:Panel>
                </ContentTemplate>
    </asp:UpdatePanel>
                      
</div>
<style>
    
    .choicePanel{
        display:grid;
    }
</style>
