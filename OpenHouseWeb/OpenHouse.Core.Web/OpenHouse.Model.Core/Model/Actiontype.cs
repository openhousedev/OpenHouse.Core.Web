﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class actiontype
    {
        public actiontype()
        {
            action = new HashSet<action>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int actionTypeId { get; set; }
        [Column("actionType", TypeName = "varchar(100)")]
        public string actionType1 { get; set; }

        [InverseProperty("actionType")]
        public virtual ICollection<action> action { get; set; }
    }
}