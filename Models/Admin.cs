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
    
    public partial class Admin
    {
        public string admin_name { get; set; }
        public Nullable<int> role_id { get; set; }
        public Nullable<System.DateTime> last_login { get; set; }
        public Nullable<bool> remember_me { get; set; }
        public string password { get; set; }
        public string email_id { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public int admin_id { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
