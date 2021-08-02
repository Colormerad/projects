using ClassManage.Factories;
using ClassManage.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ClassManage.Controllers
{
    public class ClassAPIController : ApiController
    {

        [Route("ClassRoster/All")]
        [AcceptVerbs("POST")]
        public IHttpActionResult classForm(int Id)
        {
            List<Student> result = new List<Student>();

            var ClassRepository = ClassRepositoryFactory.GetRepository();
            var StudentRepo = StudentRepositoryFactory.GetRepository();

            result = StudentRepo.GetAllByClass(Id);
            return Ok(result);
        }
    }
}