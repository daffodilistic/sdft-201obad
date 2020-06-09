using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Phishy
{
    /// <summary>
    /// Summary description for logout
    /// </summary>
    public class logout : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session.Abandon();
            context.Response.Redirect("/");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}