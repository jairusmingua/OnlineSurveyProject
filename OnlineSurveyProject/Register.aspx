
<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OnlineSurveyProject.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1>Register Now</h1>

        <div style="display:flex;margin-top:20px;">
            <div class="col" style="margin-right:10px;">
                <input type="text" class="form-control" placeholder="First name" ID="firstNameTxt" runat="server"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Firstname required" ControlToValidate="firstNameTxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                <input  type="text" class="form-control" placeholder="Last name" ID ="lastNameTxt" runat="server">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Lastname required" ControlToValidate="lastNameTxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="form-group" style="margin-top:10px;">
            <label for="exampleInputEmail1">Username</label>
            <%--<input runat="server" type="text" class="form-control" ID="usernameTxt" aria-describedby="emailHelp" placeholder="Enter desired username">--%>
            <asp:TextBox ID="usernameTxt" runat="server" CssClass="form-control" OnTextChanged="usernameTxt_TextChanged" AutoPostBack="true"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username required" ControlToValidate="usernameTxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

            <small id="validationLbl" style="color:red;" runat="server"></small>
        </div>
        <div class="form-group">
            <label for="exampleInputEmail1">Email</label>
            <input runat="server" type="email" class="form-control" ID="emailTxt" aria-describedby="emailHelp" placeholder="Enter valid email">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email required" ControlToValidate="emailTxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword1">Password</label>
            <input runat="server" type="password" class="form-control" ID="passwordTxt" placeholder="Password">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Password is required" ControlToValidate="passwordTxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="exampleInputPassword2">Retype Password</label>
            <input runat="server" type="password" class="form-control" ID="retypepassTxt" placeholder="Password">
        </div>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="passwordTxt" ControlToValidate="retypepassTxt" ErrorMessage="Password don't match!!!" Display="Dynamic"></asp:CompareValidator>
        <br />
        <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass='btn btn-primary' OnClick="registerBtn_Click"/>    
</asp:Content>

