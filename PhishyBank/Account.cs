using System;

namespace Project5
{
    public class Account
    {
        public string id { get; set; }
        public string account_number { get; set; }
        public object iban { get; set; }
        public double balance { get; set; }
        public double balance_available { get; set; }
        public string bic { get; set; }
        public int preauth_amount { get; set; }
        public bool is_locked { get; set; }
        public string currency { get; set; }
        public DateTime updated_at { get; set; }
        
        public Account()
        {
            // default constructor
        }
    }
}