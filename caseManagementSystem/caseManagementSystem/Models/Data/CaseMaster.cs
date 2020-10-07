using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace caseManagementSystem.Models.Data
{
    public class CaseMaster
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string CaseNumber { get; set; }
        [Required]
        public string CaseName { get; set; }
        [Required]
        public DateTime FilingDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Agency { get; set; }
        [Required]
        [MaxLength(50)]
        public string Judge { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<CaseDetail> CaseDetails { get; set; }

    }
} 