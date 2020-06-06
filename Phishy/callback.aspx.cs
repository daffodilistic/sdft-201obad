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
        protected async void Page_Load(object sender, EventArgs e)
        {
            string responseCode = Request.QueryString["code"];
            OAuth2 oauthContainer = PhishyHelper.getFidorOauth2Container(this.Context.IsDebuggingEnabled);
            APIAccess fidorApi = new APIAccess();
            APIAccess.Result status = new APIAccess.Result();
            
            status.result = -1;
            status.value = "";
            status = fidorApi.GetAccessToken(oauthContainer, responseCode);
            if (status.result == 0)
            {
                Session["Access Token"] = status.value;
                FintechAPI.Accounts accts = await fidorApi.GetAccounts(status.value);
                Response.Redirect("Home.aspx");
            }
        }
    }
}