﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class rentaccount
    {
        public rentaccount()
        {
            propertycharge = new HashSet<propertycharge>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int rentAccountId { get; set; }
        [Column("rentAccount", TypeName = "varchar(100)")]
        public string rentAccount1 { get; set; }

        [InverseProperty("rentAccount")]
        public virtual ICollection<propertycharge> propertycharge { get; set; }
    }
}