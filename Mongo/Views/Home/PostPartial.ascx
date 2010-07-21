<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DomainModel.Entities.Post>" %>

            <% if (Convert.ToBoolean(Session["AdminMode"]))
            { %>

                <div style="float: right;">
                    <table cellspacing="5" cellpadding="2">
                        <td style="font-size: 7pt;" width="25"><%= Html.ActionLink("Edit", "PostEdit", new { Id = Model.Id }) %></td>
                        <td style="font-size: 7pt;" width="40"><%= Html.ActionLink("Delete", "PostDelete", new { Id = Model.Id })%></td>                            
                    </table>
                </div>
            <% } %>

            <div class="display-field"><h2><%: Model.Title %></h2></div>
                       
            <div class="display-field"><b>PostDate: </b><%: String.Format("{0:g}", Model.PostDate) %></div>
        
            <br /><div class="display-field"><%: Model.Body %></div>

            <div>
                <h3>Comments (<%: Model.CommentCount %>)</h3>

                <% if (Model.CommentCount > 0) { %>
                    <% foreach (var comment in Model.Comments)
                       { %>
                    
                        <div id="comments">
                            <% if (Convert.ToBoolean(Session["AdminMode"]))
                               { %>
                                <div style="float: right;">
                                    <table cellspacing="5" cellpadding="2">
                                        <td style="font-size: 7pt;" width="25"><%= Html.ActionLink("Edit", "CommentEdit", new { Id = Model.Id, CommentId = comment._CommentId }) %></td>
                                        <td style="font-size: 7pt;" width="40"><%= Html.ActionLink("Delete", "CommentDelete", new { Id = Model.Id, CommentId = comment._CommentId })%></td>                            
                                    </table>
                                </div>
                            <% } %>

                            <b><%: comment.Name %> Says:</b><br />
                            <span style="font-size: 7pt;"><%: String.Format("{0:g}", comment.TimePosted) %></span><br /><br />
                            <%: comment.Body %><br />&nbsp;

                        </div>
                    <% } %>
                <% } %>
            </div>


