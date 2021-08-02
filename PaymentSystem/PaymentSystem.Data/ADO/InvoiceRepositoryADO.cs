using PaymentSystem.Data.Interfaces;
using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.ADO
{
    public class InvoiceRepositoryADO : IInvoiceRepository
    {
        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public Invoice GetbyId(int InvoiceId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
