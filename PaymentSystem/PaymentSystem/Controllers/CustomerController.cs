using PaymentSystem.Data.Interfaces;
using PaymentSystem.Factories;
using PaymentSystem.Models;
using PaymentSystem.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            CustomerViewModel viewModel = new CustomerViewModel();
            viewModel.customer = new Customer();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel viewModel)
        {
            ICustomerRepository custRepository = CustomerRepositoryFactory.GetRepository();
            IAddressRepository addressRepository = AddressRepositoryFactory.GetRepository();
            IPhoneRepository phoneRepository = PhoneRepositoryFactory.GetRepository();

            custRepository.Insert(viewModel.customer);
            viewModel.address.CustomerId = viewModel.customer.CustomerId;
            addressRepository.Insert(viewModel.address);
            viewModel.phone.CustomerId = viewModel.customer.CustomerId;
            phoneRepository.Insert(viewModel.phone);


            CustomerViewModel viewModel2 = new CustomerViewModel();
            viewModel.customer = new Customer();
            return View(viewModel2);
        }

        public ActionResult EditCustomer(int id)
        {
            return View();
        }

        public ActionResult CustomerInvoice(int id)
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }

    }
}