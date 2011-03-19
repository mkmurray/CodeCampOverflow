<%@ Page Inherits="CodeCampOverflow.Views.Question.Question" Title="Code Camp Overflow | Question" Language="C#" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="HeadTitlePlaceHolder" runat="server"><%= Model.Title %></asp:Content>
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<p><%= Model.Body %></p>
<h2>
    <% if (Model.Answers.Any()) { %>
        <%= Model.Answers.Count %> Answer<%= Model.Answers.Count == 1 ? "" : "s" %>
    <% } %>
</h2>
<% foreach (var answer in Model.Answers) { %>
    <p class="answer"><%= answer.Body %></p>
<% } %>
<h2 id="your-answer-title" class="no-bar">Your Answer</h2>
<%= this.FormFor(new AnswerInputModel { QuestionId = Model.Id }) %>
    <textarea rows="5" id="answer" name="answer"></textarea>
    <input type="submit" value="Post Your Answer"/>
<%= this.EndForm() %>
</asp:Content>