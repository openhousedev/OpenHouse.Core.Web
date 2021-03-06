﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenHouse.Model.Core.Model
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
        }

        [Required]
        public int personId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Middle Name")]
        public string middleName { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "Title")]
        public int? titleId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? dateOfBirth { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string telephone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Nationality")]
        public int? nationalityId { get; set; }
        [Required]
        [Display(Name = "Next of Kin First Name")]
        public string nextOfKinFrstName { get; set; }
        [Required]
        [Display(Name = "Next of Kin Surname")]
        public string nextOfKinSurname { get; set; }
        [Required]
        [Display(Name = "Next of Kin Telephone")]
        public string nextOfKinTelephone { get; set; }
        public string updatedByUserID { get; set; }
        public string updatedByUsername { get; set; }
        public DateTime? updatedDT { get; set; }
        public string createdByUserID { get; set; }
        public string createdByUsername { get; set; }
        public DateTime? createdDT { get; set; }

        public virtual nationality nationality { get; set; }
        public virtual title title { get; set; }
    }
}