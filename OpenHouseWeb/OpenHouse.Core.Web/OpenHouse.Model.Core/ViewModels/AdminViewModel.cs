using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenHouse.Model.Core.ViewModels
{
    public class AdminViewModel
    {
        public string userId { get; set; }
        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string username { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string firstName { get; set; }
        [Display(Name = "Surname")]
        [Required]
        public string surname { get; set; }
        [Display(Name = "Telephone")]
        [Required]
        public string telephone { get; set; }
        [Display(Name ="Admin User")]
        public bool isAdmin { get; set; }
        [Display(Name = "Read Only")]
        public bool isReadonly { get; set; }
        [Display(Name = "Housing User")]
        public bool isHousingUser { get; set; }
        [Display(Name = "Housing Manager")]
        public bool isHousingManager { get; set; }
    }
}
