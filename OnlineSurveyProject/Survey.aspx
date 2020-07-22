<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="OnlineSurveyProject.Survey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="surveyPanel" runat="server">
        <div id="surveyBoard"  runat="server">
            <div class="jumbotron">
                <h3 class="display-4">You will be taking</h3>
                <h2 class="display-4" id="surveyName" runat="server"></h2>
                <p class="lead">Before taking up this test, you must agree to our terms and conditions.</p>
                <p>The following information will be collected:</p>
                <hr class="my-4">
                <ul>
                    <li>Name</li>
                    <li>Birthday</li>
                    <li>Gender</li>
                </ul>
                <input type="checkbox" />
                I agree to the terms and conditions 
            <br />
                <br />
                <a class="btn btn-primary btn-lg" href="#" role="button">Take the Survey!</a>
            </div>
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="errorPanel" runat="server">
        <div id="errorBoard">
            <div class="jumbotron">
                <h3 class="display-4">Inavlid Survey</h3>
                <p class="lead">Please take a look at the link and try again.</p>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
