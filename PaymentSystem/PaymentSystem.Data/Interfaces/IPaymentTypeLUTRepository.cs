using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.Interfaces
{
    public interface IPaymentTypeLUTRepository
    {
        //Read
        List<PaymentTypeLUT> GetAll();
        PaymentTypeLUT GetById(int PaymentTypeId);
    }
}
