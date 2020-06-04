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
        protected void Page_Load(object sender, EventArgs e)
        {
            OAuth2 oauthContainer = new OAuth2();
            oauthContainer.client_id = "911de6ba62ca08d8";
            oauthContainer.client_secret = "bfc36cdf50727803bf8bf8677fd0d1ac";
            oauthContainer.redirect_uri = new System.Uri(Page.Request.Url, "/callback.aspx").AbsoluteUri;

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