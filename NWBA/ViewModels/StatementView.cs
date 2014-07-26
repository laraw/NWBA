using NWBA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NWBA.ViewModels
{
    public class StatementView
    {
        public int custID { get; set; }
        public virtual ICollection<transaction> transactions { get; set; }
        public virtual ICollection<account> accounts { get; set; }        
        public SelectList accountTypes { get; set; }
        public double savingsBalance { get; set; }
        public double chequeBalance { get; set; }
        public double currentBalance { get; set; }
        public StatementView()
        {
            setAccountTypes();
        }
       

        public void setAccountTypes()
        {

           List<SelectListItem> accountTypes = new List<SelectListItem>() {
                new SelectListItem(){Text="Cheque", Value="C"},
                new SelectListItem(){Text="Savings", Value="S"},
                
            };
            this.accountTypes = new SelectList(accountTypes, "Text", "Value", "C");


        }
    }


}