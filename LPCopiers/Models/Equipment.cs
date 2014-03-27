using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class Equipment : UsersContext
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EquipmentID { get; set; }
        public string EngRef { get; set; }
        public string serialNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }

        public virtual UserProfile Engineer { get; set; }
    }

    public class RegisterEquipment
    {
        [Required]
        public string EngRef { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string serialNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        [Required]
        public string Company { get; set; }
        [Display(Name="Company Contact")]
        public string Contact { get; set; }
        [Display(Name="Location of equipment")]
        public string Location { get; set; }
    }
}