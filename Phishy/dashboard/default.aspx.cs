using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FintechAPI;

namespace Phishy
{
    public partial class Main : System.Web.UI.Page
    {
        string accessToken;
        APIAccess fidorApi;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (Session["Access Token"] != null)
            {
                accessToken = (string)Session["Access Token"];
                fidorApi = (APIAccess)Session["APIAccess"];

                Accounts accounts = await fidorApi.GetAccounts(accessToken);
                Customers customers = await fidorApi.GetCustomers(accessToken);

                string output = string.Format(
                    "Hello, {0}. Welcome to your Fidor Account.<br>" +
                    "Account No.: {1} <br/>" +
                    "Account Balance: {2} <br/>",
                    customers.data[0].first_name + " " + customers.data[0].last_name,
                    accounts.data[0].id,
                    accounts.data[0].balance_available
                );

                lblValue.Text = output;
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
        }

        protected void btnTransferMoney_Click(object sender, EventArgs e)
        {
            Response.Redirect("FundTransfer.aspx");
        }
    }
}