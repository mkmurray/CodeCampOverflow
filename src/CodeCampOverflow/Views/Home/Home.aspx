<%@ Page Inherits="CodeCampOverflow.Views.Home.Home" Title="Code Camp Overflow | Home" Language="C#" MasterPageFile="~/Views/Shared/Master.master" %>
<asp:Content ContentPlaceHolderID="HeadTitlePlaceHolder" runat="server">Top Questions</asp:Content>
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<% if (Model.Questions.Any()) { %>
    <ul>
        <% foreach (var question in Model.Questions) { %>
            <li>
                <div class="answer-status <%= question.Answers.Count > 0 ? "answered" : "unanswered" %>">
                    <div class="answer-count"><%= question.Answers.Count %></div>
                    <div>answer<%= question.Answers.Count == 1 ? "" : "s" %></div>
                </div>
                <h3><a href="question/<%= question.Id %>"><%= question.Title %></a></h3>
            </li>
        <% } %>
    </ul>
<% } else { %>
    <span>No questions.</span>
<% } %>
</asp:Content>