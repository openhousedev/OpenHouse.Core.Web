using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenHouse.Model.Core.Model
{
    public class TenancyViewModel
    {
        public TenancyViewModel()
        {
            tenancyhousehold = new HashSet<tenancyhousehold>();
            tenancynote = new HashSet<tenancynote>();
        }

        public int tenancyId { get; set; }
        [Required]
        [Display(Name ="Property ID")]
        public int? propertyId { get; set; }
        [Required]
        [Display(Name = "Lead Tenant Person ID")]
        public int leadTenantPersonId { get; set; }
        [Display(Name = "Joint Tenant Person ID")]
        public int? jointTenantPersonId { get; set; }
        [Required]
        public int tenureTypeId { get; set; }
        [Required]
        [Display(Name ="Start Date")]
        [DataType(DataType.Date)]
        public DateTime? startDate { get; set; }
        [Display(Name = "Termination Date")]
        [DataType(DataType.Date)]
        public DateTime? terminationDate { get; set; }
        [Display(Name = "Termination Reason")]
        public string terminationReasonId { get; set; }
        public string updatedByUserID { get; set; }
        public string updatedByUsername { get; set; }
        public DateTime updatedDT { get; set; }
        public string createdByUserID { get; set; }
        public string createdByUsername { get; set; }
        public DateTime createdDT { get; set; }

        public vwproperty property { get; set; }
        public person jointTenantPerson { get; set; }
        public person leadTenantPerson { get; set; }
        public tenuretype tenureType { get; set; }
        public tenancyterminationreason terminationReason { get; set; }
        public ICollection<vwaction> actions { get; set; }
        public ICollection<vwalert> alerts { get; set; }
        public ICollection<tenancyhousehold> tenancyhousehold { get; set; }
        public ICollection<tenancynote> tenancynote { get; set; }
        public ICollection<vwrentledger> rentLedger { get; set; }
    }
}
