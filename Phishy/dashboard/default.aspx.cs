using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FintechAPI;
using System.Threading.Tasks;
using System.Globalization;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace Phishy
{
    public partial class Main : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            PhishyAPI fidorApi = (PhishyAPI) Session["PhishyAPI"];
            if (fidorApi != null)
            {
                Accounts accounts = await fidorApi.GetAccounts();
                Customers customers = await fidorApi.GetCustomers();

                string formattedAccountBalance = (accounts.data[0].balance_available / 100.0).ToString("C2", CultureInfo.CreateSpecificCulture("en-SG"));

                lblUserName.Text = customers.data[0].first_name + ", " + customers.data[0].last_name;
                lblUserFirstName.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(customers.data[0].first_name.ToLower());
                lblAccountId.Text = accounts.data[0].id;
                lblAccountBalance.Text = formattedAccountBalance;

                string output = "INSERT TRANSACTIONS HERE";
                lblValue.Text = output;
            }
            else
            {
                Response.Redirect("~/default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}