using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace caseManagementSystem.Models.Data
{
    public class CaseDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CaseMasterId { get; set; }
        [Required]
        public DateTime DetailDate { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string StreetA { get; set; }
       
        public string StreetB { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }
        
        public string Notes { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual CaseMaster CaseMaster { get; set; }
        public virtual ICollection<CaseCharge> CaseCharges { get; set; }

    }
}