using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class WageCalculator
    {
        [Required]
        public bool Beng { get; set; }
        [Required]
        [Range(1,80.0,ErrorMessage="Hours must be between 1 and 80")]
        public double hours { get; set; }
        [Required]
        [DisplayName("Job Title")]
        public double rate { get; set; }
        public double wage { get; set; }
    }
}