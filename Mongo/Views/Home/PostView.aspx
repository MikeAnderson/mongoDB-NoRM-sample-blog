<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DomainModel.Entities.Comment>" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Post
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="float: right; padding-right: 5px;"><%: Html.ActionLink("Back to List", "MongoBlog")%></div>

    <br />

        <fieldset>

            <% Html.RenderPartial("PostPartial", ViewData["Post"]); %>

            <div>
                <div id="comment_div">
                <% using (Html.BeginForm())
                   {%>
                    <%: Html.ValidationSummary(true)%>


                        <%= Html.TextBox("PostId", Html.Encode(ViewData["Id"]), new { type = "hidden" })%>

                        <table>
                            <tr>
                                <td><%: Html.LabelFor(model => model.Name) %>: </td>
                                <td>
                                    <%: Html.TextBoxFor(model => model.Name, new { @class = "comment_textbox" })%>
                                    <%: Html.ValidationMessageFor(model => model.Name)%>
                                </td>
                            </tr>
                            <tr>
                                <td><%: Html.LabelFor(model => model.Email)%>:</td>
                                <td>
                                    <%: Html.TextBoxFor(model => model.Email, new { @class = "comment_textbox" })%>
                                    <%: Html.ValidationMessageFor(model => model.Email)%>                    
                                </td>
                                <td></td>
                            </tr>
                            <tr><td></td><td align="center"><%: Html.ValidationMessageFor(model => model.Body)%> </td></tr>
                            <tr>
                                <td valign="top"><%: Html.LabelFor(model => model.Body)%>:</td>
                                <td>
                                    <%: Html.TextAreaFor(model => model.Body, new { @class = "comment_textarea" })%>
                                                       
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <%= Html.ValidationMessage("Captcha")%> <br />
                                    <%= Html.GenerateCaptcha() %>                                
                                <br /></td>
                            </tr>                      

                            <tr>
                                <td></td>
                                <td align="center"><input type="submit" class="button" value="submit comment" /></td>
                            </tr>
                        </table>
                    
                <% } %>
            </div>
        
        </div>
    </fieldset>
</asp:Content>

