<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineSurveyProject.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 id="userTxt" runat="server"></h1>
            <asp:Button runat="server" id="logoutBtn" OnClick="logoutBtn_Click" Text="Logout"/>
        </div>
    </form>
</body>
</html>
