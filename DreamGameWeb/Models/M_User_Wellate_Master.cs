//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DreamGameWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_User_Wellate_Master
    {
        public int Wellate_Id { get; set; }
        public string User_id { get; set; }
        public Nullable<int> Total_Coins { get; set; }
        public Nullable<int> Net_Coins { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual M_UserMaster M_UserMaster { get; set; }
    }
}