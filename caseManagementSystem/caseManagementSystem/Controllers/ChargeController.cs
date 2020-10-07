using caseManagementSystem.DAL;
using caseManagementSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caseManagementSystem.Controllers
{
    public class ChargeController : Controller
    {
        private CaseContext db = new CaseContext();

        [HttpGet]
        public ActionResult AddCaseDetailCharge(Guid CaseDetailId)
        {

            CaseCharge NewCaseCharge = new CaseCharge();
            NewCaseCharge.CaseDetailId = CaseDetailId;
            NewCaseCharge.ChargeDate = DateTime.Now;
            NewCaseCharge.DueDate = DateTime.Now;

            return View(NewCaseCharge);
        }
        [HttpPost]
        public ActionResult AddCaseDetailCharge(CaseCharge NewCaseCharge)
        {
            if (!ModelState.IsValid)
            {
                return View(NewCaseCharge);
            }
            NewCaseCharge.CreatedOn = DateTime.Now;
            db.CaseCharges.Add(NewCaseCharge);
            db.SaveChanges();

            CaseDetail Detail = db.CaseDetails.Where(x => x.Id == NewCaseCharge.CaseDetailId).FirstOrDefault();

            return RedirectToAction("ViewChargeDetails", "Charge", new { CaseDetailId = Detail.Id });
        }

        [HttpGet]
        public ActionResult DeleteCaseCharges(Guid CaseChargeId)
        {
            CaseCharge CaseDetailToRemove = db.CaseCharges.Where(x => x.Id == CaseChargeId).FirstOrDefault();

            return View(CaseDetailToRemove);

        }
        [HttpPost]
        public ActionResult DeleteCaseCharges(CaseCharge CaseChargeToRemove)
        {
            if (CaseChargeToRemove == null)
            {
                return RedirectToAction("Index", "Case");
            }

            CaseChargeToRemove = db.CaseCharges.Where(x => x.Id == CaseChargeToRemove.Id).FirstOrDefault();
            db.CaseCharges.Remove(CaseChargeToRemove);
            db.SaveChanges();


            return RedirectToAction("ViewChargeDetails", "Charge", new { CaseDetailId = CaseChargeToRemove.CaseDetailId });
        }

        [HttpGet]
        public ActionResult EditCaseDetailCharge(Guid CaseChargeId)
        {
            CaseCharge CurrentCaseCharge = db.CaseCharges.Where(x => x.Id == CaseChargeId).FirstOrDefault();

            return View(CurrentCaseCharge);
        }

        [HttpPost]
        public ActionResult EditCaseDetailCharge(CaseCharge CurrentCaseCharge)
        {

            if (!ModelState.IsValid)
            {
                return View(CurrentCaseCharge);
            }
            CaseCharge CaseChargeToEdit = db.CaseCharges.Where(x => x.Id == CurrentCaseCharge.Id).FirstOrDefault();
            CaseChargeToEdit.ChargeAmount = CurrentCaseCharge.ChargeAmount;
            CaseChargeToEdit.ChargeDate = CurrentCaseCharge.ChargeDate;
            CaseChargeToEdit.DueDate = CurrentCaseCharge.DueDate;
            db.SaveChanges();

            return RedirectToAction("ViewChargeDetails", "Charge", new { CaseDetailId = CurrentCaseCharge.CaseDetailId });
        }

        public ActionResult ViewChargeDetails(Guid CaseDetailId)
        {
            CaseDetail currentCase = db.CaseDetails.Include("CaseCharges").Where(x => x.Id == CaseDetailId).FirstOrDefault();


            return View(currentCase);
        }

    }
}