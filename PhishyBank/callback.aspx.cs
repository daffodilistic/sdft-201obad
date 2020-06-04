using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FintechAPI;

namespace PhishyBank
{
    public partial class callback : System.Web.UI.Page
    {
        OAuth2 getFidorOauth2Container()
        {
            OAuth2 oauthContainer = new OAuth2();
            if (this.Context.IsDebuggingEnabled)
            {
                oauthContainer.client_id = "062e071527f30139";
                oauthContainer.client_secret = "aeae6e5fc945e322d821391418dac8f7";
                oauthContainer.redirect_uri = "http://localhost:3000/callback.aspx";
            }
            else
            {
                oauthContainer.client_id = "911de6ba62ca08d8";
                oauthContainer.client_secret = "bfc36cdf50727803bf8bf8677fd0d1ac";
                oauthContainer.redirect_uri = "https://phishybank.site/callback.aspx";
            }

            return oauthContainer;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            OAuth2 oauthContainer = getFidorOauth2Container();

            string responseCode = Request.QueryString["code"];
            APIAccess fidorApi = new APIAccess();

            APIAccess.Result status = new APIAccess.Result();
            status.result = -1;
            status.value = "";
            status = fidorApi.GetAccessToken(oauthContainer, responseCode);

            if (status.result == 0)
            {
                Session["Access Token"] = status.value;
                Response.Redirect("Main.aspx");
            }
        }
    }
}