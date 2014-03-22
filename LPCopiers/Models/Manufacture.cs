using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class Manufacture
    {
        [Required(ErrorMessage="Please Select a Photocopier Manufacturer")]
        public string Photocopier {  get; set;}

        [Required(ErrorMessage="Please Select a Printer Manufacturer")]
        public string Printer { get; set; }

        [Required(ErrorMessage="Please Select a Fax Machine Manufacturer")]
        public string Fax { get; set; }

        public string CopierURL { get; set; }
        public string PrinterURL { get; set; }
        public string FaxURL { get; set; }

    }
}