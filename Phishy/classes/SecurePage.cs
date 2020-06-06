using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phishy.Classes
{
    public partial class SecurePage : System.Web.UI.Page
    {
        protected string accessToken;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Access Token"] != null)
            {
                accessToken = (string)Session["Access Token"];
            } else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}