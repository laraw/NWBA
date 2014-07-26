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
        public virtual ICollection<transaction> transactions { get; set; }    
        public SelectList accountTypes { get; set; }

        public double balance { get; set; }
        public StatementView()
        {
            setAccountTypes();
            this.balance = 0.00;
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