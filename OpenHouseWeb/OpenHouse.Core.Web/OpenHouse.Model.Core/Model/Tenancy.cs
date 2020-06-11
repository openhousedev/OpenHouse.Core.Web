﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class tenancy
    {
        public tenancy()
        {
            action = new HashSet<action>();
            tenancyalert = new HashSet<tenancyalert>();
            tenancyhousehold = new HashSet<tenancyhousehold>();
            tenancynote = new HashSet<tenancynote>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int tenancyId { get; set; }
        [Column(TypeName = "int(11)")]
        public int? propertyId { get; set; }
        [Column(TypeName = "int(11)")]
        public int leadTenantPersonId { get; set; }
        [Column(TypeName = "int(11)")]
        public int? jointTenantPersonId { get; set; }
        [Column(TypeName = "int(11)")]
        public int tenureTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? startDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? terminationDate { get; set; }
        [Column(TypeName = "int(11)")]
        public int? terminationReasonId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string updatedByUserID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updatedDT { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string createdByUserID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime createdDT { get; set; }

        [ForeignKey(nameof(jointTenantPersonId))]
        [InverseProperty(nameof(person.tenancyjointTenantPerson))]
        public virtual person jointTenantPerson { get; set; }
        [ForeignKey(nameof(leadTenantPersonId))]
        [InverseProperty(nameof(person.tenancyleadTenantPerson))]
        public virtual person leadTenantPerson { get; set; }
        [ForeignKey(nameof(tenureTypeId))]
        [InverseProperty(nameof(tenuretype.tenancy))]
        public virtual tenuretype tenureType { get; set; }
        [ForeignKey(nameof(terminationReasonId))]
        [InverseProperty(nameof(tenancyterminationreason.tenancy))]
        public virtual tenancyterminationreason terminationReason { get; set; }
        [InverseProperty("tenancy")]
        public virtual ICollection<action> action { get; set; }
        [InverseProperty("tenancy")]
        public virtual ICollection<tenancyalert> tenancyalert { get; set; }
        [InverseProperty("tenancy")]
        public virtual ICollection<tenancyhousehold> tenancyhousehold { get; set; }
        [InverseProperty("tenancy")]
        public virtual ICollection<tenancynote> tenancynote { get; set; }
    }
}