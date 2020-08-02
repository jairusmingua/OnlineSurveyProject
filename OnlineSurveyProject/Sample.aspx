<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample.aspx.cs" Inherits="OnlineSurveyProject.Sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container px-5 py-3">
        <div class="row mt-3">
            <div class="col-12 mt-0">
                <h1 class="mb-2">View Survey</h1>
            </div>
            <div class="col-12 text-left pt-lg-3">
                VCO Survey
            </div>
        </div>
        <div class="row viewBox mt-4 px-5">
            <div class="row viewheader mt-5 mb-5 pl-2">
                <h2>
                    San mo ginagamit ang VCO?
                </h2>
            </div>
            <div class="row viewresult mb-4">
                <div class="col-12 col-md-6 choicelist">
                    <div class="row choiceitem my-4">
                        <div class="col-6 choicetext">Pang-luto</div>
                        <div class="col-6 text-right choiceresult"><b>6</b></div>
                    </div>
                    <div class="row choiceitem my-4">
                        <div class="col-6 choicetext">Pang-luto</div>
                        <div class="col-6 text-right choiceresult"><b>6</b></div>
                    </div>
                    <div class="row choiceitem my-4">
                        <div class="col-6 choicetext">Pang-luto</div>
                        <div class="col-6 text-right choiceresult"><b>6</b></div>
                    </div>
                    <div class="row choiceitem my-4">
                        <div class="col-6 choicetext">Pang-luto</div>
                        <div class="col-6 text-right choiceresult"><b>6</b></div>
                    </div>
                    <div class="row choiceitem my-4">
                        <div class="col-6 choicetext">Pang-luto</div>
                        <div class="col-6 text-right choiceresult"><b>6</b></div>
                    </div>
                </div>
                <div class="col-12 col-md-6 viewgraph">
                    
                </div>
            </div>
            <div class="row viewfooter my-5">
                <div class="col-6 respondentcount">
                    Number of Respondents:
                    <b>12</b>
                </div>
                <div class="col-6 text-right viewbuttons">
                    <input class="ol-buttons-secondary-black" type="button" value="">
                    <input class="ol-buttons-secondary-black" type="button" value="">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
