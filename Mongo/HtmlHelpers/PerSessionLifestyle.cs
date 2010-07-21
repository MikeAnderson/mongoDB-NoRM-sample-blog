using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;

namespace Mongo
{
    public class PerSessionLifestyle : AbstractLifestyleManager
    {
        string uniqueKey = Guid.NewGuid().ToString();

        public override object Resolve(CreationContext context)
        {
            // Retrieve from Session, or if not found, resolve via container.
            object result = HttpContext.Current.Session[uniqueKey];
            
            if (result == null)
                result = HttpContext.Current.Session[uniqueKey] = base.Resolve(context);
            
            return result;
        }

        public override void Dispose() { }
    }
}
