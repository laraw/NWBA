//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NWBA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public account()
        {
            this.transactions = new HashSet<transaction>();
            this.transactions1 = new HashSet<transaction>();
        }
    
        public int accountNumber { get; set; }
        public string accountTypeCode { get; set; }
        public int custID { get; set; }
        public System.DateTime modifyDate { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual accountTypeLookup accountTypeLookup { get; set; }
        public virtual ICollection<transaction> transactions { get; set; }
        public virtual ICollection<transaction> transactions1 { get; set; }
    }
}