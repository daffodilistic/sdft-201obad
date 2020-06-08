using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

using FintechAPI;
using Newtonsoft.Json;
using PostmarkDotNet;
using PostmarkDotNet.Model;


namespace Phishy
{
    // TODO: ideally this would be a Singleton...
    public class PhishyAPI : APIAccess
    {
        internal static string accessToken { get; private set; } = null;
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

        internal async Task<InternalTransfer> SendMoneyInternally(String receiver, String subject, Double amount)
        {
            Accounts accounts = await GetAccounts();
            Customers customers = await GetCustomers();

            Guid g = Guid.NewGuid();
            string externalUid = g.ToString().Replace("-", string.Empty);
            string accountId = accounts.data[0].id.ToString();

            InternalTransfer xferObject = new InternalTransfer();
            xferObject.account_id = accountId;
            xferObject.external_uid = externalUid;
            xferObject.receiver = receiver;
            xferObject.amount = Convert.ToUInt64(amount * 100);
            xferObject.subject = subject;
            
            HttpResponseMessage response = new HttpResponseMessage();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.fidor.de; version=1, */*");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            string json = JsonConvert.SerializeObject(xferObject);
            StringContent xferContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            response = await httpClient.PostAsync("https://api.np.sandbox.fidor.com/internal_transfers",
                xferContent);
            
            string responseString = await response.Content.ReadAsStringAsync();
            InternalTransfer xferResponse = null;
            
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                xferResponse = JsonConvert.DeserializeObject<InternalTransfer>(responseString);
                string senderName = customers.data[0].first_name + " " + customers.data[0].last_name;
                SendNotificationEmail("nemo@phishybank.site", senderName, xferResponse.amount, xferResponse.subject);
            }

            return xferResponse;
        }

        internal async void SendNotificationEmail(
            string recipient="nemo@phishybank.site",
            string senderName="Phishy Bank",
            Double amount=188,
            string messageText="")
        {
            string formattedAmount = (amount / 100.0).ToString("C2", CultureInfo.CreateSpecificCulture("en-SG"));
            string formattedTime = DateTime.Now.ToString(new CultureInfo("en-SG"));

            Dictionary<string, string> templateModelData = new Dictionary<string, string>() {
                { "product_url", "https://www.phishybank.site" },
                { "product_name", "Phishy Bank" },
                { "sender_name", senderName },
                { "amount", formattedAmount },
                { "time", formattedTime },
                { "fidor_subject_text", messageText },
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