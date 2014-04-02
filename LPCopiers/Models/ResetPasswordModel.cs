using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LPCopiers.Models
{
    public class ResetPasswordModel
    {
        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string ReturnToken { get; set; }
    }
}