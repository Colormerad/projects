using caseManagementSystem.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace caseManagementSystem.DAL
{
    public class CaseContext: DbContext
    {
        public CaseContext()  : base("CaseContext")
        {

        }

        public DbSet<CaseMaster> CaseMasters { get; set; }
        public DbSet<CaseDetail> CaseDetails { get; set; }
        public DbSet <CaseCharge> CaseCharges { get; set; }
    }
}