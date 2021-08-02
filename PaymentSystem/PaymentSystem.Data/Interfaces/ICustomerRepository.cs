using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.Interfaces
{
    public interface ICustomerRepository
    {
        //Create
        void Insert(Customer customer);

        //Read
        Customer GetbyId(int CustomerId);
        List<Customer> GetAll();

        //Update
        void Update(Customer customer);
    }
}
