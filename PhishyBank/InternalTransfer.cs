using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhishyBank
{
    public class InternalTransfer
    {
        public string account_id { get; set; }
        public string receiver { get; set; }
        public string external_uid { get; set; }
        public string amount { get; set; }
        public string subject { get; set; }
    }
}