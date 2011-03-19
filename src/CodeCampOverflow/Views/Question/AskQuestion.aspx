<%@ Page Inherits="CodeCampOverflow.Views.Question.AskQuestion" Title="Code Camp Overflow | Ask a Question" Language="C#" MasterPageFile="~/Views/Shared/Site.master" %>
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<%= this.FormFor<AskInputModel>() %>
    <div id="question-title">
        <label for="title">Title</label>
        <input type="text" id="title" name="title" />
    </div>
    <textarea rows="5" id="body" name="body" ></textarea>
    <input type="submit" value="Post Your Question" />
<%= this.EndForm() %>
</asp:Content>
