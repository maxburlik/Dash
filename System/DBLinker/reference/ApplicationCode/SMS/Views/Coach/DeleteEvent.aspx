<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.DomainModels.Event>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageContent">
    <% Html.RenderPartial("UserNavigation", "Manage Team Events"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
        
        <% using (Html.BeginForm())
           {
               if (Model != null)
               {%>

           <h1>
            Are you sure you want to delete following event?</h1>
        <div class="display-field">
            <b>Name:</b><br />
            <%: Model.Name%></div>
        <br />
        <div class="display-field">
            <b>Scheduled Date/Time:</b><br />
            <%: String.Format("{0:g}", Model.ScheduledDate)%></div>
        <br />
        <div class="display-field">
            <b>Location:</b><br />
            <%: Model.Location%></div>
            <br />
        <div class="display-field">
            <b>Description</b><br />
            <%: Model.Description%></div>
        
        <p>
            <input type="submit" value="Delete" /><br />
            
        </p>
        <% }
           } %>

           <br />
            <%: Html.ActionLink("<< Go Back", "ManageTeamEvents")%>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JavascriptContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
