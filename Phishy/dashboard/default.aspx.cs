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
        protected void Page_Load(object sender, EventArgs e)
        {
            PhishyAPI fidorApi = (PhishyAPI) Session["PhishyAPI"];
            if (fidorApi != null)
            {
                GetUserData(fidorApi);
            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
        }

        private async void GetUserData(PhishyAPI fidorApi)
        {
            Accounts accounts = await fidorApi.GetAccounts();
            Customers customers = await fidorApi.GetCustomers();

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

        protected void btnTransferMoney_Click(object sender, EventArgs e)
        {
            Response.Redirect("FundTransfer.aspx");
        }
    }
}