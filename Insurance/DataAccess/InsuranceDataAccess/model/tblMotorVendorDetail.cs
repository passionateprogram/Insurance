//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceDataAccess.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMotorVendorDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMotorVendorDetail()
        {
            this.tblMotorPaymentDetails = new HashSet<tblMotorPaymentDetail>();
        }
    
        public int ID { get; set; }
        public string VendorName { get; set; }
        public decimal Rate { get; set; }
        public string Features { get; set; }
        public Nullable<int> VehicleType { get; set; }
        public string ImageUrl { get; set; }
    
        public virtual tblMotorVehicleType tblMotorVehicleType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMotorPaymentDetail> tblMotorPaymentDetails { get; set; }
    }
}
