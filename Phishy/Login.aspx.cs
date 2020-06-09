using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FintechAPI;
using Phishy;

namespace Phishy
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PhishyAPI fidorApi = null;
            if (Session["PhishyAPI"] != null)
            {
                fidorApi = (PhishyAPI) Session["PhishyAPI"];

                Session.Abandon();

                fidorApi.Logout();
            }

            fidorApi = new PhishyAPI();
            fidorApi.RedirectToFidor();
        }
    }
}