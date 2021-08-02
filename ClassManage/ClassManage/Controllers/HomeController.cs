using ClassManage.Factories;
using ClassManage.Models;
using ClassManage.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassManage.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ClassViewModel viewModel = new ClassViewModel();
            List<Class> classes = ClassRepositoryFactory.GetRepository().GetAll();
            viewModel.ClassList = viewModel.GenerateClassList(classes);

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult index(ClassViewModel viewModel)
        {
            Student student = new Student();
            student.StudentName = viewModel.StudentName;
            student.ClassId = viewModel.Id;

            StudentRepositoryFactory.GetRepository().Add(student);


            return RedirectToAction("Index", "Home");
        }

    }
}