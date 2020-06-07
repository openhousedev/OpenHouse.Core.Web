﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public partial class propertynote
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int propertyNoteId { get; set; }
        [Column(TypeName = "int(11)")]
        public int noteId { get; set; }
        [Column(TypeName = "int(11)")]
        public int propertyId { get; set; }

        [ForeignKey(nameof(noteId))]
        [InverseProperty("propertynote")]
        public virtual note note { get; set; }
        [ForeignKey(nameof(propertyId))]
        [InverseProperty("propertynote")]
        public virtual property property { get; set; }
    }
}