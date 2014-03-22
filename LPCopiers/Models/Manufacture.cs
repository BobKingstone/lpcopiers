using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class Manufacture
    {
        [Required(ErrorMessage="Please Select a Photocopier")]
        public string Photocopier {  get; set;}

        public string Printer { get; set; }

        public string Fax { get; set; }
    }
}