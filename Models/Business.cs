//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Money_Wave_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Business
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Business()
        {
            this.BuyShares = new HashSet<BuyShare>();
            this.SellShares = new HashSet<SellShare>();
            this.Shares = new HashSet<Share>();
        }
    
        public int business_id { get; set; }
        public string business_name { get; set; }
        public string acronym { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> remember_me { get; set; }
        public Nullable<decimal> net_worth { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<int> region_id { get; set; }
        public string logo { get; set; }
    
        public virtual Region Region { get; set; }
        public virtual Role Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuyShare> BuyShares { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellShare> SellShares { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Share> Shares { get; set; }
    }
}
