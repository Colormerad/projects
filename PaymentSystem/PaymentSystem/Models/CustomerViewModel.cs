using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.Models
{
    public class CustomerViewModel
    {
        public List<Customer> customers {get; set;}
        public Customer customer { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }


    }
}