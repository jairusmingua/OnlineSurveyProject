<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineSurveyProject.Dashboard" %>

<%@ MasterType VirtualPath="~/Dashboard.Master" %>
<%@ Register Src="~/SurveyItem.ascx" TagName="SurveyItem" TagPrefix="OnlineSurvey" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="row mt-3">
        <div class="col-6 mt-0">
            <h1 class="mb-2">Surveys</h1>
        </div>
        <div class="col-6 text-right pt-lg-3">
            <asp:Button runat="server" ID="createSurveyBtn" OnClick="createSurveyBtn_Click" Text="Create Survey" CssClass="ol-buttons" />
        </div>
    </div>
    <div class="row surveyBox mt-4">
        <ul>
            <asp:Panel ID="surveyPanel" runat="server"></asp:Panel>
        </ul>
    </div>
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
                                <div class="row">
                                    <div class="col-1"><button></button></div>
                                    <div class="col-10"><asp:TextBox ID="shareLink" runat="server" CssClass="sharelink"></asp:TextBox></div>
                                </div>
                                
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="closeBtn" runat="server" Text="Close" OnClick="closeBtn_Click" CssClass="btn btn-primary"/>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
