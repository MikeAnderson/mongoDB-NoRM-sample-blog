<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>mongoDB with NoRM</h2>
    <p>This app was created as a learning process for mongoDB and NoRM. There are also imcomplete references and examples using the <a href="http://github.com/samus/mongodb-csharp target="_blank">mongodb-csharp</a> driver. I created a very simple blog to learn how to work with CRUD operations in documents, as well as their nested documents in mongoDB.</p>

    <p>Other technologies/methodologies used:
        <ul>
            <li>ASP .NET MVC 2</li>
            <li>MVC validation with ComponentModel.DataAnnotations</li>
            <li>Dependency Injection with Castle</li>
            <li>Captcha validation with reCaptcha</li>
        </ul>
    </p>
    <p>I am in the process of learning al of these technologies, so there may be some questionable methodologies and implementations. I would greatly appreciate any feedback (be nice!): ma@atc.cx.</p>
    <p>
        A few quick notes:
        <ul>
            <li>In the upper right, there is an "Admin Mode" link. This is a toggle between "Admin Mode" and "User Mode". In "Admin Mode", there are links to add/edit/delete posts and comments, in "User Mode", there are not. Obviously, this is for develpment convenience.</li>
            <li>To use the reCaptcha validation, you will need to setup a reCaptcha account and add your private and public keys to the Mongo project web.config file.<br /><b>NOTE:</b> This is again for convenience! It is NEVER a good idea to store info like this, un-encrypted in config files. Also, be sure to uncomment the CaptchaValidator ActionFilterAttribute in the HomeController PostView HttpPost method.</li>
            <li>If you'd like to experiment with the mongodb-charp driver, change the connection string and Castle component string in the Mongo project web config file (These are both commented out). One of the many cool things about Castle and Interface programming, you can flip your repositories around and it won't break your app code (well, it shouldn't).</li>        
        </ul>
    </p>
    <p>
        TODOs:
        <ul>
            <li>Still learning TDD, needs to add some tests for the different repositories.</li>
            <li>I setup mongoDB to run as a service. For some reason, the application won't connect this way. When I run mongoDB in a command shell, it works fine. I need to figure this one out, probably port/security related.</li>
            <li>Fix routing to Home/PostView/aaaaaa (not Home/PostView?Id=aaaaaa)</li>
            <li>It would be cool to get the mongodb-csharp code working, I just ran into too many issues</li>
        </ul>
    </p>
    <p>
        To learn more about ASP.NET MVC visit <a href="http://asp.net/mvc" title="ASP.NET MVC Website">http://asp.net/mvc</a>.
    </p>
</asp:Content>
