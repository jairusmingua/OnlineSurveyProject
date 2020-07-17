<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionBox.ascx.cs" Inherits="OnlineSurveyProject.QuestionBox" %>
<div>
    Question<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnCreateChoice" runat="server" Text="Add Question" OnClick="btnCreateChoice_Click"/>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
    </asp:UpdatePanel>
</div>
