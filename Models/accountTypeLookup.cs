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
    
    public partial class accountTypeLookup
    {
        public accountTypeLookup()
        {
            this.accounts = new HashSet<account>();
        }
    
        public string accountTypeCode { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<account> accounts { get; set; }
    }
}
