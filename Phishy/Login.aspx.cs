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
            OAuth2 oauthContainer = PhishyHelper.getFidorOauth2Container(this.Context.IsDebuggingEnabled);
            APIAccess fidorApi = new APIAccess();
            fidorApi.GetAccessToken(oauthContainer, null);
        }
    }
}