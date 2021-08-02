using ClassManage.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassManage.Models
{
    public class ClassViewModel
    {
        public List<Class> classes { get; set; }

        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string Teacher { get; set; }
        public int Id { get; set; }

        public List<SelectListItem> ClassList { get; set; }

        public List<SelectListItem> GenerateClassList(List<Class> classes)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in classes)
            {
                SelectListItem item = new SelectListItem();
                item.Value = c.Id.ToString();
                item.Text = c.ClassName;
                items.Add(item);
            }
            return items;
        }
        public List<SelectListItem> StudentsList { get; set; }

        public List<SelectListItem> GenerateStudentsList(List<Student> students)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var s in students)
            {
                SelectListItem item = new SelectListItem();
                item.Value = s.Id.ToString();
                item.Text = s.StudentName;
                items.Add(item);

            }

            return items;
        }
    }
}