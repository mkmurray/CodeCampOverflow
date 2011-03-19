<%@ Page Inherits="CodeCampOverflow.Views.Question.Question" Title="Code Camp Overflow | Question" Language="C#" MasterPageFile="~/Views/Shared/Site.master" %>
<%@ Import Namespace="CodeCampOverflow.Models.Domain" %>
<asp:Content ContentPlaceHolderID="HeadTitlePlaceHolder" runat="server"><%= Model.Title %></asp:Content>
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<%= this.DisplayFor(model => model.Body) %>
<h2>
    <% if (Model.Answers.Any()) { %>
        <%= Model.Answers.Count %> Answer<%= Model.Answers.Count == 1 ? "" : "s" %>
    <% } %>
</h2>
<% foreach (var answer in Model.Answers) { %>
    <%= this.DisplayFor(answer, a => a.Body).AddClass("answer") %>
<% } %>
<h2 id="your-answer-title" class="no-bar">Your Answer</h2>
<%= this.FormFor(new AnswerInputModel { QuestionId = Model.Id }) %>
    <%= this.InputFor<AnswerInputModel>(answer => answer.Body) %>
    <input type="submit" value="Post Your Answer"/>
<%= this.EndForm() %>
</asp:Content>
