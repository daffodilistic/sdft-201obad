using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

using FintechAPI;
using System.Globalization;

namespace Phishy.Dashboard
{
    public partial class FundTransfer : System.Web.UI.Page
    {
        PhishyAPI fidorApi;

        protected void Page_Load(object sender, EventArgs e)
        {
            fidorApi = (PhishyAPI)Session["PhishyAPI"];
            if (fidorApi != null)
            {
                // Do something
            }
            else
            {
                Response.Redirect("~/default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected async void btnTransfer_Click(object sender, EventArgs e)
        {
            InternalTransfer xferResponse = await fidorApi.SendMoneyInternally(txtTransferEmail.Text,txtSubject.Text,Convert.ToDouble(txtAmount.Text));

            if (xferResponse != null)
            {
                string formattedAmount = (xferResponse.amount / 100.0).ToString("C2", CultureInfo.CreateSpecificCulture("en-SG"));

                lblSender.Text = xferResponse.account_id;
                lblReciever.Text = xferResponse.receiver;
                lblSubject.Text = xferResponse.subject;
                lblAmount.Text = formattedAmount;
                lblState.Text = "Success";
            } else
            {
                lblState.Text = "FAILED";
            }

            transferResultContainer.Visible = true;
            transferContainer.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}