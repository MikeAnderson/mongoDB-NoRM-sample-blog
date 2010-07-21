using System;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.IO;
using System.Configuration;

namespace Mongo.HtmlHelpers
{
    public static class RecaptchaHelpers
    {
        public static string GenerateCaptcha(this HtmlHelper helper)  
        {                    
            var captchaControl = new Recaptcha.RecaptchaControl  
            {  
                ID = "recaptcha",
                Theme = "white",
                PublicKey = ConfigurationManager.AppSettings["reCaptcha-PublicKey"],
                PrivateKey = ConfigurationManager.AppSettings["reCaptcha-PrivateKey"]
            };  
          
            var htmlWriter = new HtmlTextWriter( new StringWriter() );  
          
            captchaControl.RenderControl(htmlWriter);  
          
            return htmlWriter.InnerWriter.ToString();  
        }
    }
}