using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Models.Tables
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDescription { get; set; }
        public string InvoiceTotalCost { get; set; }
        public int CustomerId { get; set; }

    }
}
