using LPCopiers.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPCopiers.Models
{
    public class ContactForm
    {
        //private string DateInSevenDays = DateTime.Now.AddDays(7).ToString();
        //private string DateInNinetyDays = DateTime.Now.AddDays(90).ToString();
        [Required(ErrorMessage="Company Name Required")]
        [DisplayName("Company Name")]
        public string CName { get; set; }

        [Required(ErrorMessage = "Are you an existing customer?")]
        [DisplayName("Existing Customer")]
        public bool Customer { get; set; }

        [DisplayName("Account No.")]
        public string AccountNo { get; set; }

        [DisplayName("Company Website")]
        public string CompanyURL { get; set; }

        [Required(ErrorMessage = "Number of units on site required")]
        [DisplayName("Number of units on premises")]
        [Range(5,300, ErrorMessage = "Value for {0} must be greater than {1}.")]
        public int NoOfUnits { get; set; }

        [Required(ErrorMessage = "Job title required")]
        [DisplayName("Contact Title")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "Contact name required")]
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Street required")]
        public string Street { get; set; }

        [Required(ErrorMessage="Town Required")]
        public string Town { get; set;}

        //Post code regex taken from http://stackoverflow.com/questions/164979/uk-postcode-regex-comprehensive
        [Required(ErrorMessage = "Post Code Required")]
        [RegularExpression(@"^(GIR ?0AA|[A-PR-UWYZ]([0-9]{1,2}|([A-HK-Y][0-9]([0-9ABEHMNPRV-Y])?)|[0-9][A-HJKPS-UW]) ?[0-9][ABD-HJLNP-UW-Z]{2})$",
            ErrorMessage="Please enter a valid postcode")]
        public string PostCode { get; set; }

        //regex taken from http://thedailywtf.com/Articles/Validating_Email_Addresses.aspx
        [RegularExpression(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$"
            ,ErrorMessage="Please enter a valid email address")]
        public string Email { get; set; }

        [RegularExpression(@"^\s*\(?(020[7,8]{1}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{4})|(0[1-8]{1}[0-9]{3}\)?[ ]?[1-9]{1}[0-9]{2}[ ]?[0-9]{3})\s*$",ErrorMessage="Please enter a valid phone number")]
        [Required(ErrorMessage = "Contact Number required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Select type of visit")]
        [DisplayName("Type of visit requested")]
        public string VisitType { get; set; }

        [Required(ErrorMessage = "Visit date required")]
        [DisplayName("Visit Date")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DateRange(ErrorMessage="Date must be more than 1 days and less than 90 days from today")]
        public DateTime VisitDate { get; set; }
    }
}