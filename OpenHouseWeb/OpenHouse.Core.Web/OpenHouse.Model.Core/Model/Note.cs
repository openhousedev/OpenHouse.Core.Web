﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class note
    {
        public note()
        {
            propertynote = new HashSet<propertynote>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int noteId { get; set; }
        [Column("note", TypeName = "text")]
        public string note1 { get; set; }
        [Column(TypeName = "int(11)")]
        public int? updatedByUserID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? updatedDT { get; set; }
        [Column(TypeName = "int(11)")]
        public int? createdByUserID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? createdDT { get; set; }

        [InverseProperty("note")]
        public virtual ICollection<propertynote> propertynote { get; set; }
    }
}