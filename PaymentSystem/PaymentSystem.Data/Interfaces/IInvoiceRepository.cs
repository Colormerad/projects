using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.Interfaces
{
    public interface IInvoiceRepository
    {
        //Create

        void Insert(Invoice invoice);

        //Read
        List<Invoice> GetAll();
        Invoice GetbyId(int InvoiceId);

    }
}
