<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.ViewModels.ThirdPartyTeamApplicationInfoView>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.RenderPartial("UserNavigation", "Manage Team Applications"); %>
    <div id="pageContent">
        <h1>
            Edit Team Application</h1>
        <br />
        <% using (Html.BeginForm())
           {%>
        <%: Html.ValidationSummary(true) %>
        <%: Html.HiddenFor(m => m.ApplicationID) %>
        <%: Html.HiddenFor(m => m.TournamentID) %>
        <div class="editor-label">
            Team Name
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.TeamApplication.TeamName) %>
            <%: Html.ValidationMessageFor(model => model.TeamApplication.TeamName)%>
        </div>
        <div class="editor-label">
            Category
        </div>
        <div class="editor-field">
            <select id="Category" style="width: 150px;" name="Category">
                <option value="">Please select...</option>
                <% for (int i = 5; i < 25; i++)
                   { %>
                <option value="U<%: i %>">U<%: i %></option>
                <% } %>
            </select>
            <%: Html.HiddenFor(model => model.TeamApplication.Category)%>
            <%: Html.ValidationMessageFor(model => model.TeamApplication.Category)%>
        </div>
        <div class="editor-label">
            Coach Name
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.TeamApplication.CoachName)%>
            <%: Html.ValidationMessageFor(model => model.TeamApplication.CoachName)%>
        </div>
        <p>
            <input type="submit" value="Save" />
        </p>
        <br />
        <% } %>
        <div>
            <%: Html.ActionLink("<< Back to List", "ManageTeamApplications", new { TournamentID = Model.TournamentID, message = "" })%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var category = $("#TeamApplication_Category").val();
            $("#Category").find("option:contains('" + category + "')").each(function () {
                $(this).attr("selected", "selected");

            });
            $('#Category').change(function () {
                new_val = $("#Category option:selected").val();
                $("#TeamApplication_Category").val(new_val);

            });

        });
  
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
