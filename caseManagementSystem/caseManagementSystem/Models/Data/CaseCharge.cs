using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace caseManagementSystem.Models.Data
{
    public class CaseCharge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CaseDetailId { get; set; }
        [Required]
        public decimal ChargeAmount { get; set; }
        [Required]
        public DateTime ChargeDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        
        public virtual CaseDetail CaseDetail { get; set; }

    }
}