using FintechAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phishy
{
    public class PhishyHelper
    {
        // Sample URL:
        // https://apm.np.sandbox.fidor.com/oauth/authorize?client_id=062e071527f30139&redirect_uri=http%3A%2F%2Flocalhost%3A3000%2Fcallback.aspx&state=login&response_type=code

        internal static OAuth2 getFidorOauth2Container(bool isDebug)
        {
            OAuth2 oauthContainer = new OAuth2();
            if (isDebug)
            {
                oauthContainer.client_id = "062e071527f30139";
                oauthContainer.client_secret = "aeae6e5fc945e322d821391418dac8f7";
                // NOTE: Must match!
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
    }
}