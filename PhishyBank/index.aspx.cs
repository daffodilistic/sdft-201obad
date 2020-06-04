using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhishyBank
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDebugStatus.Text = "Debug status: " + (this.Context.IsDebuggingEnabled.ToString());
        }
    }
}