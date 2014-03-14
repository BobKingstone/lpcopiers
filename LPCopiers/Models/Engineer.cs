using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPCopiers.Models
{        
    [Table("Engineers")]
    public class Engineer
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public int UserId {get; set;}
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Area { get; set; }
        public string Contact { get; set; }
    }


}