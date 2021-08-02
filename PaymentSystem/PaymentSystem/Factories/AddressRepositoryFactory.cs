using PaymentSystem.Data;
using PaymentSystem.Data.ADO;
using PaymentSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentSystem.Factories
{
    public class AddressRepositoryFactory
    {
        public static IAddressRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new AddressRepositoryADO();
                default:
                    throw new Exception("Could not find valid Repository Type configuration value");
            }
        }
    }
}