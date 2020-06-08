using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

using FintechAPI;
using PostmarkDotNet;
using PostmarkDotNet.Model;


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

        internal async void SendNotificationEmail(
            String recipient="nemo@phishybank.site",
            String senderName="Phishy Bank",
            Double amount=1.88)
        {
            String formattedAmount = amount.ToString("C2", CultureInfo.CreateSpecificCulture("en-SG"));
            String formattedTime = DateTime.Now.ToString(new CultureInfo("en-SG"));

            Dictionary<string, string> templateModelData = new Dictionary<string, string>() {
                { "product_url", "https://www.phishybank.site" },
                { "product_name", "Phishy Bank" },
                { "sender_name", senderName },
                { "amount", formattedAmount },
                { "time", formattedTime },
                { "action_url", "https://www.phishybank.site" },
                { "company_name", "Phishy Bank" },
                { "company_address", "123 Sesame Street" }
            };

            // Send an email asynchronously:
            var message = new TemplatedPostmarkMessage()
            {
                TemplateId = 18352791,
                TemplateModel = templateModelData,
                InlineCss = true,
                From = "noreply@phishybank.site",
                To = recipient,
                Bcc = "nemo@phishybank.site",
                TrackOpens = true
            };

            //var imageContent = File.ReadAllBytes("test.jpg");
            //message.AddAttachment(imageContent, "test.jpg", "image/jpg", "cid:embed_name.jpg");

            var client = new PostmarkClient("e8603c27-0841-47fe-8cc6-daf4163de446");
            var sendResult = await client.SendEmailWithTemplateAsync(message);

            if (sendResult.Status == PostmarkStatus.Success)
            {
                // Do something
            }
            else
            {
                // Do something
            }
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