using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{        
    [Table("Customers")]
    public class CustomerModel
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("UserId")]
        public int LoginId { get; set; }
        public virtual UserProfile UserId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
    }

}