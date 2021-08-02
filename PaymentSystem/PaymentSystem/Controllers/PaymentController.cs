using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentSystem.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPayment(int id)
        {
            return View();
        }

        public ActionResult EditPayment(int id)
        {
            return View();
        }
    }
}