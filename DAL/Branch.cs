//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            this.OrdersFromBranches = new HashSet<OrdersFromBranch>();
            this.OrdersFromBranches1 = new HashSet<OrdersFromBranch>();
            this.Stocks = new HashSet<Stock>();
            this.OrdersFromStocks = new HashSet<OrdersFromStock>();
        }
    
        public int id_branch { get; set; }
        public int manager_id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public Nullable<int> house_number { get; set; }
        public string name_branch { get; set; }
        public string mapLink { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersFromBranch> OrdersFromBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersFromBranch> OrdersFromBranches1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersFromStock> OrdersFromStocks { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
