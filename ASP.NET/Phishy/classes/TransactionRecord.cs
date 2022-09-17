using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phishy
{
    public class TransactionRecord
    {
        public string id { get; set; }
        public string subject { get; set; }
        public string account_id { get; set; }
        public string user_id { get; set; }
        public string receiver { get; set; }
        public string recipient_name { get; set; }
        public uint amount { get; set; }
        public string state { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string currency { get; set; }
        public string transaction_id { get; set; }
        public string external_uid { get; set; }
    }
}