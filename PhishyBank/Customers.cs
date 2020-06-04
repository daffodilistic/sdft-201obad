using FintechAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhishyBank
{
    public class Customers
    {
        public Customer[] data { get; set; }
        public CustomerCollection collection { get; set; }
    }

    public class CustomerCollection : AccountCollection {
    }

    public class Customer
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object additional_first_name { get; set; }
        public object title { get; set; }
    }
}