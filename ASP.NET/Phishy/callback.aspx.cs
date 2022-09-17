using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FintechAPI;

namespace Phishy
{
    public partial class callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only allow page to be loaded if code is in query string
            string responseCode = Request.QueryString["code"];
            if (responseCode != null)
            {
                PhishyAPI fidorApi = new PhishyAPI();
                fidorApi.InitializeSession(responseCode);
                
                if (PhishyAPI.isLoggedIn)
                {
                    Session["PhishyAPI"] = fidorApi;
                    Response.Redirect("dashboard/");
                }
            }
            Response.Redirect("~/default.aspx");
        }
    }
}