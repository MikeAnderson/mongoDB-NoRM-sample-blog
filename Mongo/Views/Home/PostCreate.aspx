<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Entities.Post>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create Post
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="float: right; padding-right: 5px;"><%: Html.ActionLink("Back to List", "MongoBlog") %></div>

    <br />
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Create New Post</legend>
                       
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Body) %>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%: Html.ValidationMessageFor(model => model.Body) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Body) %>
            </div>                                    
            <p>
                <br /><input type="submit" class="button" value="create post" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

