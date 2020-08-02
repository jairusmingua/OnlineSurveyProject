﻿<%--<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineSurveyProject.Dashboard" %>

<%@ MasterType VirtualPath="~/Dashboard.Master" %>--%>
<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineSurveyProject.Dashboard" %>
<%@ Register Src="~/SurveyItem.ascx" TagName="SurveyItem" TagPrefix="OnlineSurvey" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <div>
        <h1>Surveys</h1>

    </div>
    <div id="surveyList" runat="server"></div>
    <asp:Panel ID="surveyPanel" runat="server"></asp:Panel>
    <asp:Button runat="server" ID="createSurveyBtn" OnClick="createSurveyBtn_Click" Text="Create Survey" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="sharePanel" runat="server">
                <div class="modal" style="display:unset !important;" tabindex="-1" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="modalTitle" runat="server"></h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <p runat="server" id="modalDescription"></p>
                                <asp:TextBox ID="shareLink" runat="server"></asp:TextBox>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="closeBtn" runat="server" Text="Close" OnClick="closeBtn_Click" CssClass="btn btn-primary"/>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
         
        <div class="row mt-3">
            <h1 class="mb-2 col-6 mt-0">Survey</h1>
            <div class="col-6 text-right pt-xs-3">
                <asp:Button runat="server" ID="createSurveyBtn" OnClick="createSurveyBtn_Click" Text="Create Survey"  CssClass="ol-buttons"/>
            </div>
        </div>
        <div class="row surveyBox mt-4">
            <ul>
                <asp:Panel ID="surveyPanel" runat="server" ></asp:Panel>
            </ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <asp:Panel ID="sharePanel" runat="server">
                        <div class="modal" style="display: unset !important;" tabindex="-1" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="modalTitle" runat="server"></h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <p runat="server" id="modalDescription"></p>
                                        <asp:TextBox ID="shareLink" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="closeBtn" runat="server" Text="Close" OnClick="closeBtn_Click" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
              
            </ContentTemplate>
        </asp:UpdatePanel>
  

</asp:Content>
