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
    
    public partial class M_Contest_Master
    {
        public int Contest_ID { get; set; }
        public int Contest__Code { get; set; }
        public string Contest_Desc { get; set; }
        public byte[] Banner_Image_Path { get; set; }
        public Nullable<int> Bit_Amount { get; set; }
        public Nullable<int> Max_People { get; set; }
        public string Promo_Code { get; set; }
        public string Promo_Code_Values { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual T_User_Contest T_User_Contest { get; set; }
    }
}