using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.Interfaces
{
    public interface IAddressRepository
    {

        //Create
        void Insert(Address address);
        //Read
        Address GetById(int AddressId);
        //Update
        void Update(Address address);
    }
}
