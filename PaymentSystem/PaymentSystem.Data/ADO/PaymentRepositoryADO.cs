using PaymentSystem.Data.Interfaces;
using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.ADO
{
    public class PaymentRepositoryADO : IPaymentRepository
    {
        public List<Payment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Payment GetById(int PaymentId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
