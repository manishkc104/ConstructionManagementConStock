//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ADGroup4L3C3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductTypeSupplier
    {
        public int ProductTypeSupplierID { get; set; }
        public int ProductTypeID { get; set; }
        public int SupplierID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public int ModifiedBy { get; set; }
    
        public virtual ProductType ProductType { get; set; }
        public virtual UserAccounts UserAccounts { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}