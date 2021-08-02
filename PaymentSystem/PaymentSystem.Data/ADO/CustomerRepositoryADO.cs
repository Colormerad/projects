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
    public class CustomerRepositoryADO : ICustomerRepository
    {
        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetbyId(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer customer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomerInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CustomerId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
                cmd.Parameters.AddWithValue("@IsActive", true);

                cn.Open();
                cmd.ExecuteNonQuery();
                customer.CustomerId = (int)param.Value;
            }
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
