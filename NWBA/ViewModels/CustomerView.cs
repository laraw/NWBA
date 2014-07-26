using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NWBA.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

// references:
//http://www.etl-tools.com/regular-expressions/is-australian-post-code.html regular expression for postal code
// http://bighow.net/4239685-Regex_to_validate_Australian_mobile_numbers.html regular expression for australian phone numbers


namespace NWBA.ViewModels
{
    public class CustomerView
    {
        public CustomerView()
        {
            this.accounts = new HashSet<account>();
            setStates();
            
        }


        [Display(Name="Customer Number")]
        public int custID { get; set; }

        [Required]
        [Display(Name="Customer Name")]
        public string custName { get; set; }

        [Display(Name="Tax File Number")]
        public string TFN { get; set; }
        public System.DateTime dateCreated { get; set; }

        [Required]
        [Display(Name="Address Line 1")]
        public string addressLine1 { get; set; }

        [Display(Name="Address Line 2")]
        public string addressLine2 { get; set; }

        [Required]
        [Display(Name="Suburb")]
        public string suburb { get; set; }

        [Display(Name="State")]
        public string state { get; set; }

        [Display(Name="Postal Code")]
        [Required]
        [RegularExpression("^(0[289][0-9]{2})|([1345689][0-9]{3})|(2[0-8][0-9]{2})|(290[0-9])|(291[0-4])|(7[0-4][0-9]{2})|(7[8-9][0-9]{2})$", 
            ErrorMessage="Postcode Is Not Valid")]
        public string postalCode { get; set; }

        [Display(Name="Home Phone")]
        //[RegularExpression("", ErrorMessage="Phone Number must be in the following format: (61)-XXXX-XXXX")]
        public string phoneNumber { get; set; }

        [Display(Name="Mobile")]
        public string mobile { get; set; }

        [Required]
        [Display(Name="Email Address")]
        [EmailAddress(ErrorMessage="Email is not valid")]
        public string email { get; set; }

        public virtual ICollection<account> accounts { get; set; }

        public SelectList states { get; private set; }

        private void setStates()
        {
            List<SelectListItem> states = new List<SelectListItem>() {
                new SelectListItem(){Text="QLD", Value="QLD"},
                new SelectListItem(){Text="NSW", Value="NSW"},
                new SelectListItem(){Text="SA", Value="SA"},
                new SelectListItem(){Text="WA",Value="WA"},
                new SelectListItem(){Text="TAS", Value="TAS"},
                new SelectListItem(){Text="NT", Value="NT"},
                new SelectListItem(){Text="ACT",Value="ACT"},
            };
             this.states = new SelectList(states, "Text", "Value", this.state);
        }
    }
}