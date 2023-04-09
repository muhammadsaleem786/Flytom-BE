using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel
{
    public class ShopifyRequest
    {
        public string id { get; set; }
        public string gid { get; set; }
        public string group { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public bool test { get; set; }
        public string merchant_locale { get; set; }
        public Payment_Method payment_method { get; set; }
        public DateTime proposed_at { get; set; }
        public Customer customer { get; set; }
        public string kind { get; set; }
        public Guid MerchantId { get; set; }
    }

    public class Payment_Method
    {
        public string type { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string cancel_url { get; set; }
    }

    public class Customer
    {
        public Billing_Address billing_address { get; set; }
        public Shipping_Address shipping_address { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string locale { get; set; }
    }

    public class Billing_Address
    {
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string province { get; set; }
        public string country_code { get; set; }
        public string company { get; set; }
    }

    public class Shipping_Address
    {
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string province { get; set; }
        public string country_code { get; set; }
        public string company { get; set; }
    }

}

