using Microsoft.AspNetCore.Components;

namespace PhishyBank
{
    public class PhishyLayoutComponentBase : LayoutComponentBase
    {
        public static string getPageTitle(string? title = null)
        {
            if (title == null)
            {
                return "PhishyBank";
            }
            else
            {
                return "PhishyBank - " + title;
            }
        }
    }
}