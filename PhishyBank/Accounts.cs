using FintechAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhishyBank
{
    public class Accounts
    {
        public Account[] data { get; set; }
        public AccountCollection collection { get; set; }
    }
}