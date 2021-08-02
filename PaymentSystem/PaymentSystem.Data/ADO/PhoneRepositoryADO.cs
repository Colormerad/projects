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
    public class PhoneRepositoryADO : IPhoneRepository
    {
        public void Delete(int PhoneId)
        {
            throw new NotImplementedException();
        }

        public List<Phone> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phone GetById(int PhoneId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Phone phone)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PhoneInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@PhoneId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CustomerId", phone.CustomerId);
                cmd.Parameters.AddWithValue("@PhoneNumber", phone.PhoneNumber);
                cmd.Parameters.AddWithValue("@PhoneDescription", phone.PhoneDescription);

                
                cn.Open();
                cmd.ExecuteNonQuery();
                phone.PhoneId = (int)param.Value;
            }
        }

        public void Update(Phone phone)
        {
            throw new NotImplementedException();
        }
    }
}
