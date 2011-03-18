<%@ Page Inherits="CodeCampOverflow.Views.Question.AskQuestion" Title="Code Camp Overflow | Ask a Question" Language="C#" MasterPageFile="~/Views/Shared/Master.master" %>
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
<form action="/question/ask" method="post">
    <div id="question-title">
        <label for="title">Title</label>
        <input type="text" id="title" name="title" />
    </div>
    <textarea rows="5" id="body" name="body" ></textarea>
    <input type="submit" value="Post Your Question" />
</form>
</asp:Content>