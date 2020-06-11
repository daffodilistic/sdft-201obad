using FintechAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Phishy
{
    public class PhishyHelper
    {
        // Sample URL:
        // https://apm.np.sandbox.fidor.com/oauth/authorize?client_id=062e071527f30139&redirect_uri=http%3A%2F%2Flocalhost%3A3000%2Fcallback.aspx&state=login&response_type=code

        internal static OAuth2 GetFidorOauth2Container(bool isDebug)
        {
            OAuth2 oauthContainer = new OAuth2();
            if (isDebug)
            {
                string redirectUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/callback.aspx";

                oauthContainer.client_id = "062e071527f30139";
                oauthContainer.client_secret = "aeae6e5fc945e322d821391418dac8f7";
                // NOTE: Must match!
                oauthContainer.redirect_uri = redirectUri;
            }
            else
            {
                string redirectUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/callback.aspx";
                if (HttpContext.Current.Request.Headers["X-Forwarded-Host"] != null)
                {
                    redirectUri = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Headers["X-Forwarded-Host"] + "/callback.aspx";
                }

                oauthContainer.client_id = "911de6ba62ca08d8";
                oauthContainer.client_secret = "bfc36cdf50727803bf8bf8677fd0d1ac";
                oauthContainer.redirect_uri = redirectUri;
            }

            return oauthContainer;
        }

        internal static String GetClientId(bool isDebug)
        {
            if (isDebug)
            {
                return "062e071527f30139";
            }
            else
            {
                return "911de6ba62ca08d8";
            }
        }

        internal static String GetClientSecret(bool isDebug)
        {
            if (isDebug)
            {
                return "aeae6e5fc945e322d821391418dac8f7";
            }
            else
            {
                return "bfc36cdf50727803bf8bf8677fd0d1ac";
            }
        }
    }
}