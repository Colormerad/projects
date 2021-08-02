using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.Interfaces
{
    public interface IPaymentRepository
    {
        //Create
        void Insert(Payment payment);

        //Read
        List<Payment> GetAll();
        Payment GetById(int PaymentId);
    }
}
