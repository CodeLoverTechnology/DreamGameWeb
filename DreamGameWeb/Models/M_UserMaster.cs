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
    
    public partial class M_UserMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_UserMaster()
        {
            this.M_User_Wellate_Master = new HashSet<M_User_Wellate_Master>();
        }
    
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public Nullable<int> Gender { get; set; }
        public string IdentityProf { get; set; }
        public string EmailID { get; set; }
        public string ContactNo { get; set; }
        public string PWD { get; set; }
        public string ProfilePicPath { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual M_MasterTable M_MasterTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<M_User_Wellate_Master> M_User_Wellate_Master { get; set; }
    }
}
