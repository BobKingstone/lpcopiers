using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class LostPasswordModel
    {
        [Required(ErrorMessage = "We need your email to send you a reset link")]
        [Display(Name = "Your registered email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

    }
}