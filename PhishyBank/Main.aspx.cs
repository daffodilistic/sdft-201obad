using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhishyBank
{
    public partial class Main : System.Web.UI.Page
    {
        string accessToken;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Access Token"] != null)
            {
                accessToken = (string) Session["Access Token"];
                //string message = String.Format("<h4 style='font-family:verdana;'>Access Token: {0}</h4>", accessToken);
                //Response.Write(message);
            }
        }


        protected async void btnGetAccount_Click(object sender, EventArgs e)
        {
            HttpClient httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("Accept", "application/vnd.fidor.de; version=1, */*");
            httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            HttpResponseMessage response = new HttpResponseMessage();
            response = await httpclient.GetAsync("https://api.np.sandbox.fidor.com/accounts");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string s = await response.Content.ReadAsStringAsync();
                    
                Accounts accounts = JsonConvert.DeserializeObject<Accounts>(s);
                Session["Accounts"] = accounts;

                string output = string.Format(
                    "Account No.: {0} <br/>" +
                    "Account Balance: {1} <br/>",
                    accounts.data[0].id,
                    accounts.data[0].balance_available
                );

                lblValue.Text = output;
            }
        }

        protected async void btnGetCustomer_Click(object sender, EventArgs e)
        {
            HttpClient httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("Accept", "application/vnd.fidor.de; version=1, */*");
            httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            HttpResponseMessage response = new HttpResponseMessage();
            response = await httpclient.GetAsync("https://api.np.sandbox.fidor.com/customers");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string s = await response.Content.ReadAsStringAsync();

                Customers customers = JsonConvert.DeserializeObject<Customers>(s);

                string output = string.Format(
                    "Hello, {0} {1}. Welcome to your Fidor Account.",
                    customers.data[0].first_name,
                    customers.data[0].last_name
                );
                lblValue.Text = output;
            }
        }

        protected void btnTransferMoney_Click(object sender, EventArgs e)
        {
            Response.Redirect("FundTransfer.aspx");
        }
    }
}