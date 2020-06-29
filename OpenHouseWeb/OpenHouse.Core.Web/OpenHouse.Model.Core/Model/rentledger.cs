﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class rentledger
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int rentLedgerId { get; set; }
        [Column(TypeName = "int(11)")]
        public int tenancyId { get; set; }
        [Column(TypeName = "int(11)")]
        public int propertyChargeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime periodStartDT { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime periodEndDT { get; set; }
        [Column(TypeName = "int(11)")]
        public int? paymentId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime updatedDT { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime createdDT { get; set; }

        [ForeignKey(nameof(paymentId))]
        [InverseProperty("rentledger")]
        public virtual payment payment { get; set; }
        [ForeignKey(nameof(tenancyId))]
        [InverseProperty("rentledger")]
        public virtual tenancy tenancy { get; set; }
    }
}