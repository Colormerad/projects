using ClassManage.Models.Interfaces;
using ClassManage.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManage.Data.ADO
{
    public class ClassRepositoryADO : IClassRepository
    {
        public List<Class> GetAll()
        {
            List<Class> classes = new List<Class>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetClasses", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Class currentRow = new Class();
                        currentRow.Id = (int)dr["Id"];
                        currentRow.ClassName = dr["ClassName"].ToString();
                        currentRow.Teacher = dr["Teacher"].ToString();
                        classes.Add(currentRow);
                    }
                }
            }
            return classes;
        }
    }
}
