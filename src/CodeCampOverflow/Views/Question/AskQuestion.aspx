<%@ Page Inherits="CodeCampOverflow.Views.Question.AskQuestion" Title="Code Camp Overflow | Ask a Question" Language="C#" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<%= this.FormFor<AskInputModel>() %>
    <div id="question-title">
        <%= this.LabelFor<AskInputModel>(question => question.Title) %>
        <%= this.InputFor<AskInputModel>(question => question.Title) %>
    </div>
    <%= this.InputFor<AskInputModel>(question => question.Body) %>
    <input type="submit" value="Post Your Question" />
<%= this.EndForm() %>
</asp:Content>
