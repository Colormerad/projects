using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models.Tables
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDetails { get; set; }
        public string Amount { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
