using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace GitHubRepositoryApp.Api.Controllers
{
    abstract public class BaseSessionController : ApiController
    {
        protected HttpSessionState GetSession(string sessionId)
        {
            var context = HttpContext.Current;

            // Ensure the session ID is correctly set in the context
            if (context.Session == null || context.Session.SessionID != sessionId)
            {
                var sessionContainer = new HttpSessionStateContainer(
                    sessionId, 
                    new SessionStateItemCollection(), 
                    new HttpStaticObjectsCollection(), 
                    10, 
                    true, 
                    HttpCookieMode.UseUri, 
                    SessionStateMode.InProc, 
                    false
                    );
                SessionStateUtility.AddHttpSessionStateToContext(context, sessionContainer);
            }

            return context.Session;
        }
    }
}
