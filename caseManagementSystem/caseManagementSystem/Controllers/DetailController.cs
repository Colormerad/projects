using caseManagementSystem.DAL;
using caseManagementSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caseManagementSystem.Controllers
{
    public class DetailController : Controller
    {
        private CaseContext db = new CaseContext();

        [HttpGet]
        public ActionResult AddCaseDetail(Guid CaseId)

        {
            CaseMaster currentCase = db.CaseMasters.Include("CaseDetails").Where(x => x.Id == CaseId).FirstOrDefault();
            CaseDetail NewCaseDetails = new CaseDetail();
            NewCaseDetails.CaseMasterId = CaseId;
            NewCaseDetails.DetailDate = DateTime.Now;


            return View(NewCaseDetails);
        }

        [HttpPost]
        public ActionResult AddCaseDetail(CaseDetail NewCaseDetails)

        {
            if (!ModelState.IsValid)
            {
                return View(NewCaseDetails);
            }
            NewCaseDetails.CreatedOn = DateTime.Now;
            db.CaseDetails.Add(NewCaseDetails);
            db.SaveChanges();


            return RedirectToAction("AddCaseDetailCharge", "Charge", new { CaseDetailId = NewCaseDetails.Id });
        }

        [HttpGet]
        public ActionResult DeleteCaseDetail(Guid CaseDetailId)
        {
            CaseDetail CaseDetailToRemove = db.CaseDetails.Include("CaseCharges").Where(x => x.Id == CaseDetailId).FirstOrDefault();

            return View(CaseDetailToRemove);

        }
        [HttpPost]
        public ActionResult DeleteCaseDetail(CaseDetail CaseDetailToRemove)
        {
            if (CaseDetailToRemove == null)
            {
                return RedirectToAction("Index", "Case");
            }
            CaseDetailToRemove = db.CaseDetails.Where(x => x.Id == CaseDetailToRemove.Id).FirstOrDefault();

            foreach (var charge in CaseDetailToRemove.CaseCharges.ToList())
            {
                CaseCharge currentCharge = db.CaseCharges.Where(x => x.Id == charge.Id).FirstOrDefault();
                db.CaseCharges.Remove(charge);
            }

            CaseDetailToRemove = db.CaseDetails.Where(x => x.Id == CaseDetailToRemove.Id).FirstOrDefault();
            db.CaseDetails.Remove(CaseDetailToRemove);
            db.SaveChanges();


            return RedirectToAction("ViewCaseDetails", "Detail", new { CaseId = CaseDetailToRemove.CaseMasterId });
        }

        [HttpGet]
        public ActionResult EditCaseDetail(Guid CaseDetailId)
        {
            CaseDetail CurrentCaseDetails = db.CaseDetails.Where(x => x.Id == CaseDetailId).FirstOrDefault();

            return View(CurrentCaseDetails);
        }

        [HttpPost]
        public ActionResult EditCaseDetail(CaseDetail CurrentCaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return View(CurrentCaseDetail);
            }
            CaseDetail CaseDetailToEdit = db.CaseDetails.Where(x => x.Id == CurrentCaseDetail.Id).FirstOrDefault();
            CaseDetailToEdit.DetailDate = CurrentCaseDetail.DetailDate;
            CaseDetailToEdit.FirstName = CurrentCaseDetail.FirstName;
            CaseDetailToEdit.LastName = CurrentCaseDetail.LastName;
            CaseDetailToEdit.StreetA = CurrentCaseDetail.StreetA;
            CaseDetailToEdit.StreetB = CurrentCaseDetail.StreetB;
            CaseDetailToEdit.City = CurrentCaseDetail.City;
            CaseDetailToEdit.State = CurrentCaseDetail.State;
            CaseDetailToEdit.PostalCode = CurrentCaseDetail.PostalCode;
            CaseDetailToEdit.Notes = CurrentCaseDetail.Notes;
            db.SaveChanges();


            return RedirectToAction("ViewCaseDetails", "Detail", new { CaseId = CurrentCaseDetail.CaseMasterId });
        }

        public ActionResult ViewCaseDetails(Guid CaseId)
        {

            CaseMaster currentCase = db.CaseMasters.Include("CaseDetails").Where(x => x.Id == CaseId).FirstOrDefault();

            return View(currentCase);
        }

    }
}