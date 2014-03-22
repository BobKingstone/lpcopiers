using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class Manufacture
    {
        [Required]
        public string Photocopier {  get; set;}
        [Required]
        public string Printer { get; set; }
        [Required]
        public string Fax { get; set; }
    }
}