﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class nationality
    {
        public nationality()
        {
            person = new HashSet<person>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int nationalityId { get; set; }
        [Column("nationality", TypeName = "varchar(100)")]
        public string nationality1 { get; set; }

        [InverseProperty("nationality")]
        public virtual ICollection<person> person { get; set; }
    }
}