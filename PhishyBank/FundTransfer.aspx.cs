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

namespace PhishyBank
{
    public partial class FundTransfer : System.Web.UI.Page
    {
        string accessToken;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                accessToken = (string)Session["Access Token"];
            }
        }

        protected async void btnTransfer_Click(object sender, EventArgs e)
        {
            accessToken = (string)Session["Access Token"];
            Accounts accounts = (Accounts)Session["Accounts"];

            Guid g = Guid.NewGuid();
            string externalUid = g.ToString().Replace("-", string.Empty);
            string accountId = accounts.data[0].id.ToString();

            InternalTransfer xferObject = new InternalTransfer();
            xferObject.account_id = accountId;
            xferObject.external_uid = externalUid;
            xferObject.amount = (Convert.ToDouble(txtAmount.Text) * 100).ToString();
            xferObject.receiver = txtTransferEmail.Text;
            xferObject.subject = txtSubject.Text;

            HttpResponseMessage response = new HttpResponseMessage();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.fidor.de; version=1, */*");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            string json = JsonConvert.SerializeObject(xferObject);
            StringContent xferContent =
                new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            response = await httpClient.PostAsync("https://api.np.sandbox.fidor.com/internal_transfers",
                xferContent);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                lblState.Text = "Successful";
            }

            tblTxnSummary.Visible = true;
            tblTxnDetail.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}