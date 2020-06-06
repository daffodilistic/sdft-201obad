using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PostmarkDotNet;
using PostmarkDotNet.Model;

namespace Phishy
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Context.IsDebuggingEnabled)
            {
                lblDebugStatus.Visible = true;
            }
        }

        protected async void btnTestPostmark_Click(object sender, EventArgs e)
        {
            // Send an email asynchronously:
            var message = new PostmarkMessage()
            {
                To = "nemo@phishybank.site",
                From = "noreply@phishybank.site",
                TrackOpens = true,
                Subject = "Forgot Password",
                TextBody = "Forgot Password?",
                HtmlBody = "<html><body>Forgot Password?</body></html>",
                Tag = "Password Reset"
            };

            //var imageContent = File.ReadAllBytes("test.jpg");
            //message.AddAttachment(imageContent, "test.jpg", "image/jpg", "cid:embed_name.jpg");

            var client = new PostmarkClient("e8603c27-0841-47fe-8cc6-daf4163de446");
            var sendResult = await client.SendMessageAsync(message);

            if (sendResult.Status == PostmarkStatus.Success) { Response.Write("OK"); }
            else { /* Resolve issue.*/ }
        }
    }
}