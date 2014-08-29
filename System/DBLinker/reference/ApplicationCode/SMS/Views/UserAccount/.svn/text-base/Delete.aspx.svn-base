<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SMS.Models.DomainModels.UserAccount>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div id="pageContent">
    <% Html.RenderPartial("UserNavigation", "Manage Users"); %>
        <% if (ViewData["Message"] != null && !ViewData["Message"].ToString().Equals(String.Empty))
           {%>
        <p id="StatusMessage" style="text-align: center">
            <%: ViewData["Message"].ToString()%></p>
        <%} %>
  
    <% using (Html.BeginForm())
       {
           if (Model != null)
           {%>
          <h1>Are you sure you want to delete user account '<%: Model.Person.FirstName + ", " + Model.Person.LastName %>'?</h1>
          
            <p>
                <input type="submit" value="Delete" />
            </p>

    <% }
       }%>

    <div>
        <%: Html.ActionLink("<< Go Back", "Create") %>
    </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>

