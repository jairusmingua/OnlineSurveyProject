<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="OnlineSurveyProject.Survey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="surveyPanel" runat="server">
                <div id="surveyBoard" runat="server">
                    <div class="jumbotron" setfocusonerror="True">
                        <h3 class="display-4">You will be taking</h3>
                        <h2 class="display-4" id="surveyName" runat="server"></h2>
                        <p class="lead">Before taking up this test, you must agree to our terms and conditions.</p>
                        <p>The following information will be collected:</p>
                        <hr class="my-4">
                        <ul>
                            <li><div>
                                <p>Name</p>
                                <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
                                </div>
                            </li>
                             <li><div>
                                <p>Age</p>
                                 <asp:TextBox ID="ageTxt" runat="server"></asp:TextBox>
                                </div>
                            </li>
                             <li><div>
                                <p>Gender</p>
                                 <asp:DropDownList ID="genderList" runat="server"  ></asp:DropDownList>
                                </div>
                            </li>
                        </ul>
                        <asp:CheckBox ID="agreeCheckBox" runat="server" OnCheckedChanged="agreeCheckBox_CheckedChanged" AutoPostBack="true" />
                        I agree to the terms and conditions 
                        <br />
                        <br />
                        <asp:Button ID="takeSurveyBtn" runat="server" Text="Take Survey" CssClass="btn btn-primary btn-lg" OnClick="takeSurveyBtn_Click" />
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
            <asp:PlaceHolder ID="filloutPanel" runat="server">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="respondPanel" runat="server">

                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="nextBtn" runat="server" Text="Next Question"   OnClick="nextBtn_Click" />
            </asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
