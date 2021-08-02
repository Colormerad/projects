using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManage.Models.Interfaces;
using ClassManage.Models.Tables;

namespace ClassManage.Data.ADO
{
    public class StudentRepositoryADO : IStudentRepository
    {
        public void Add(Student student)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                cmd.Parameters.AddWithValue("@ClassId", student.ClassId);
                cn.Open();
                cmd.ExecuteReader();

            }
        }

        public List<Student> GetAllByClass(int ClassId)
        {
            List<Student> students = new List<Student>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsByClass", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClassId", ClassId);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Student currentRow = new Student();
                        currentRow.Id = (int)dr["Id"];
                        currentRow.StudentName = dr["StudentName"].ToString();
                        currentRow.ClassId = (int)dr["ClassId"];
                        students.Add(currentRow);
                    }
                }
            }
            return students;
        }
    }
}
