<%@ Page Title="" validateRequest="false" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<DomainModel.Entities.Post>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Mongo Blog
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% if (Convert.ToBoolean(Session["AdminMode"]))
       { %>
            <div style="float: right; padding-right: 5px;"><%= Html.ActionLink("New Post", "PostCreate")%></div>
    <% } %>

    <h2>Mongo Blog</h2>

    <br />
            <% foreach (var post in Model)
            { %>
                    <fieldset>

                        <% if (Convert.ToBoolean(Session["AdminMode"]))
                           { %>
            
                            <div style="float: right;">
                                <table cellspacing="5" cellpadding="2">
                                    <td style="font-size: 7pt;" width="25"><%= Html.ActionLink("Edit", "PostEdit", new { Id = post.Id }) %></td>
                                    <td style="font-size: 7pt;" width="40"><%= Html.ActionLink("Delete", "PostDelete", new { Id = post.Id }) %></td>                            
                                </table>
                            </div>
                        <% } %>

                        <div class="display-field"><h2><%= Html.ActionLink(Html.Encode(post.Title), "PostView", new { Id = post.Id }) %></h2></div>
                       
                        <div class="display-field"><b>PostDate: </b><%: Html.Encode(String.Format("{0:g}", post.PostDate)) %></div>
                                
                        <br /><div class="display-field"><%: Convert.ToString((post.Body.Length) > 50 ? post.Body.Substring(0, 50) : post.Body) %>...</div>

                        <div style="float: right;">[Post Size: <%: post.CharCount %>] [Comments: <%: post.CommentCount %>]</div>

                    </fieldset>

            <% } %>

</asp:Content>
