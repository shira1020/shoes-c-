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
    
    public partial class OrdersFromStock
    {
        public int id_order { get; set; }
        public int id_shoe { get; set; }
        public string color { get; set; }
        public Nullable<int> size { get; set; }
        public Nullable<System.TimeSpan> time_order { get; set; }
        public string customer_name { get; set; }
        public Nullable<int> status { get; set; }
        public int id_branch { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Sho Sho { get; set; }
    }
}
