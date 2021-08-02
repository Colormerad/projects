using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentSystem.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddInvoice()
        {
            return View();
        }
        public ActionResult EditInvoice(int id)
        {
            return View();
        }
    }
}