<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineSurveyProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
            <div style="display:block;padding-right:50px;">
                <h1 class="display-4">Try Free Online Survey</h1>
                <p class="lead">Get survey answers by just sharing a link to your respondents</p>
            </div>
            <div id="LoginForm">
                <div class="form-group">
                    <label for="exampleInputEmail1">Username</label>
                    <input runat="server" type="text" class="form-control" id="usernameTxt" aria-describedby="emailHelp" placeholder="Enter username">
                    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">Password</label>
                    <input runat="server" type="password" class="form-control" id="passwordTxt" placeholder="Password">
                </div>
                <small ID="loginpromptLbl" runat="server" style="color:red;"></small>
                <br />
                <asp:Button ID="loginBtn" runat="server" Text="Login" CssClass='btn btn-primary' OnClick="loginBtn_Click"/>
                <label>Not yet Registered?&nbsp;</label><a href="Register.aspx">Click Here</a>
            </div>
              

        </div>
</asp:Content>
