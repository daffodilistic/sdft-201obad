using FintechAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phishy
{
    public class TransactionCollection : AccountCollection { }
    public class TransactionRecordContainer
    {
        public TransactionRecordContainer() { }

        public TransactionRecord[] data { get; set; }
        public TransactionCollection collection { get; set; }
    }
}