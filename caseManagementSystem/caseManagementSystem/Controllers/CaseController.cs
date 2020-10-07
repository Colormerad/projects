using caseManagementSystem.DAL;
using caseManagementSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace caseManagementSystem.Controllers
{
    public class CaseController : Controller
    {
        private CaseContext db = new CaseContext();
        [HttpGet]
        public ActionResult Index()
        {
            List<CaseMaster> cases = db.CaseMasters.ToList();

            return View(cases);
        }

        [HttpGet]
        public ActionResult AddCase()
        {
            CaseMaster NewCase = new CaseMaster();
            NewCase.FilingDate = DateTime.Now;
           
            return View(NewCase);
        }

        [HttpPost]
        public ActionResult AddCase(CaseMaster NewCase)
        {
            if (!ModelState.IsValid)
            {
                return View(NewCase);
            }
            NewCase.CreatedOn = DateTime.Now;
            db.CaseMasters.Add(NewCase);
            db.SaveChanges();

            return RedirectToAction("AddCaseDetail", "Detail", new { CaseId = NewCase.Id });
        }
        
        
        [HttpGet]
        public ActionResult DeleteCase(Guid CaseId)
        {
           
            CaseMaster CaseToRemove = db.CaseMasters.Include("CaseDetails").Where(x => x.Id == CaseId).FirstOrDefault();

            
            return View(CaseToRemove);
        }

        [HttpPost]
        public ActionResult DeleteCase(CaseMaster CaseToRemove)
        {
            if (CaseToRemove == null)
            {
                return RedirectToAction("Index", "Case");
            }

            CaseToRemove = db.CaseMasters.Include("CaseDetails").Where(x => x.Id == CaseToRemove.Id).FirstOrDefault();

            foreach (var detail in CaseToRemove.CaseDetails.ToList())
            {
                CaseDetail currentDetail = db.CaseDetails.Include("CaseCharges").Where(x => x.Id == detail.Id).FirstOrDefault();
                
                foreach (var charge in currentDetail.CaseCharges.ToList())
                {
                    CaseCharge currentCharge = db.CaseCharges.Where(x => x.Id == charge.Id).FirstOrDefault();
                    db.CaseCharges.Remove(currentCharge);
                }
                db.CaseDetails.Where(x => x.Id == detail.Id).FirstOrDefault();
                db.CaseDetails.Remove(detail);
            }

            CaseToRemove = db.CaseMasters.Where(x => x.Id == CaseToRemove.Id).FirstOrDefault();
            db.CaseMasters.Remove(CaseToRemove);

            db.SaveChanges();


            return RedirectToAction("Index", "Case");
        }
        
       

        [HttpGet]
        public ActionResult EditCase(Guid CaseId)
        {
            CaseMaster CurrentCase = db.CaseMasters.Where(x => x.Id == CaseId).FirstOrDefault();
            return View(CurrentCase);
        }
        [HttpPost]
        public ActionResult EditCase(CaseMaster CurrentCase)
        {
            if (!ModelState.IsValid)
            {
                return View(CurrentCase);
            }
            CaseMaster CaseToEdit = db.CaseMasters.Where(x => x.Id == CurrentCase.Id).FirstOrDefault();
            CaseToEdit.CaseNumber = CurrentCase.CaseNumber;
            CaseToEdit.CaseName = CurrentCase.CaseName;
            CaseToEdit.FilingDate = CurrentCase.FilingDate;
            CaseToEdit.Agency = CurrentCase.Agency;
            CaseToEdit.Judge = CurrentCase.Judge;
            db.SaveChanges();

            return RedirectToAction("ViewCaseDetails", "Detail", new { CaseId = CurrentCase.Id });
        }
        
    }
}