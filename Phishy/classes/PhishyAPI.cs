using FintechAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Phishy
{
    // TODO: ideally this would be a Singleton...
    public class PhishyAPI : APIAccess
    {
        internal static String accessToken { get; private set; } = null;
        internal static bool isLoggedIn { get; private set; } = false;

        internal void RedirectToFidor()
        {
            OAuth2 oauthContainer = PhishyHelper.GetFidorOauth2Container(HttpContext.Current.IsDebuggingEnabled);
            // Start OAuth2 process by requesting for an access token without a "code" (session)
            base.GetAccessToken(oauthContainer, null);
        }

        internal Result InitializeSession(String code)
        {
            OAuth2 oauthContainer = PhishyHelper.GetFidorOauth2Container(HttpContext.Current.IsDebuggingEnabled);
            // Start OAuth2 process by requesting for an access token without a "code" (session)
            Result authResult = new Result();
            authResult.result = -1;
            authResult.value = null;

            authResult = base.GetAccessToken(oauthContainer, code);

            if (authResult.result == 0)
            {
                accessToken = authResult.value;
                isLoggedIn = true;
            }
            else
            {
                accessToken = null;
                isLoggedIn = false;
            }

            return authResult;
        }
        internal Task<Customers> GetTransferHistory()
        {
            return base.GetCustomers(PhishyAPI.accessToken);
        }

        internal Task<Customers> GetCustomers()
        {
            return base.GetCustomers(PhishyAPI.accessToken);
        }

        internal Task<Accounts> GetAccounts()
        {
            return base.GetAccounts(PhishyAPI.accessToken);
        }
    }
}