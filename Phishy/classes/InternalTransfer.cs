using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phishy
{
    public class InternalTransfer
    {
        public string account_id { get; set; }
        public string receiver { get; set; }
        public string external_uid { get; set; }
        public ulong amount { get; set; }
        public string subject { get; set; }
        public string transaction_id { get; set; }
    }
}