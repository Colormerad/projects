using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.Interfaces
{
    public interface IPhoneRepository
    {
        //Create
        void Insert(Phone phone);

        //Read
        List<Phone> GetAll();
        Phone GetById(int PhoneId);

        //Edit
        void Update(Phone phone);

        //Delete
        void Delete(int PhoneId);
    }
}
