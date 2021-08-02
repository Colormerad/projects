using PaymentSystem.Data.Interfaces;
using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem.Data.ADO
{
    public class AddressRepositoryADO : IAddressRepository
    {
        public Address GetById(int AddressId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Address address)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddressInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@AddressId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CustomerId", address.CustomerId);
                cmd.Parameters.AddWithValue("@City", address.City);
                cmd.Parameters.AddWithValue("@Street1", address.Street1);
                if (address.Street2 == string.Empty)
                {
                    cmd.Parameters.AddWithValue("@Street2", string.Empty);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Street2", address.Street2);
                }
                cmd.Parameters.AddWithValue("@State", address.State);
                cmd.Parameters.AddWithValue("@Zipcode", address.Zipcode);

                cn.Open();
                cmd.ExecuteNonQuery();
                address.AddressId = (int)param.Value;
            }
        }

        public void Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
