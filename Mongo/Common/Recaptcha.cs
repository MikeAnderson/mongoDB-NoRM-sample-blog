using System;
using System.Web.Mvc;
using System.Configuration;

namespace Mongo.Common
{
    public class CaptchaValidatorAttribute : ActionFilterAttribute   
    {  
        private const string CHALLENGE_FIELD_KEY = "recaptcha_challenge_field";  
        private const string RESPONSE_FIELD_KEY = "recaptcha_response_field";  
            
        public override void OnActionExecuting(ActionExecutingContext filterContext)  
        {  
            var captchaChallengeValue = filterContext.HttpContext.Request.Form[CHALLENGE_FIELD_KEY];  
            var captchaResponseValue = filterContext.HttpContext.Request.Form[RESPONSE_FIELD_KEY];  
            var captchaValidator = new Recaptcha.RecaptchaValidator  
                                        {
                                            PrivateKey = ConfigurationManager.AppSettings["reCaptcha-PrivateKey"],
                                            RemoteIP = filterContext.HttpContext.Request.UserHostAddress,  
                                            Challenge = captchaChallengeValue,  
                                            Response = captchaResponseValue  
                                        };  
    
            var recaptchaResponse = captchaValidator.Validate();  
    
            // this will push the result value into a parameter in our Action  
            filterContext.ActionParameters["captchaValid"] = recaptchaResponse.IsValid;  
    
            base.OnActionExecuting(filterContext);  
        }  
    }  
}