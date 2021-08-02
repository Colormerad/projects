using ClassManage.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManage.Models.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllByClass(int ClassId);
        void Add(Student student);
    }
}
