using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace NWBA.ViewModels
{
    public class TransactionView
    {
        public int transactionID { get; set; }
        public string transactionType { get; set; }
        public int accountNum { get; set; }
        public Nullable<int> destAccoutNum { get; set; }
        public double amount { get; set; }
        public string comment { get; set; }
        public System.DateTime modifyDate { get; set; }
        public int transactionTypeCode { get; set; }

      

       
    }
}