<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.AuthorizationCodeView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", ""); %>
    <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
       {%>
    <p id="StatusMessage" style="text-align: center">
        <%: ViewData["Message"].ToString()%></p>
    <%} %>
    <div id="pageContent">
        <h1>
            Registration - New Organization</h1>
        <% using (Html.BeginForm())
           {%>
        <%: Html.ValidationSummary(true) %>
        <div id="PlayerPanel" style="height: 400px;">
            <h3>
                Generate Authorization Code</h3>
            <p>
                    <input type="submit" value="Generate" />
            </p>  
            <p>
                <%: Html.TextBoxFor(model => model.AuthorizationCode)%>
            </p>
        </div> 
        <% } %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
<script type="text/javascript">
    $(function () {
        $('#Register').attr("id", "currentPage");
        $('#GuardianPanel').hide('fast', null);
        $('#TempPanel').hide('fast', null);


        $('#lnkAdvanceToGuardian').click(function () {
            $('#PlayerPanel').hide('fast', null);
            $('#GuardianPanel').show("fast", null);
        });


        $('#lnkBackToPlayer').click(function () {
            $('#GuardianPanel').hide("fast", null);
            $('#PlayerPanel').show('fast', null);
        });

    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
