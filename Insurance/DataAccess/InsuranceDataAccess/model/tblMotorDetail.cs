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
    
    public partial class tblMotorDetail
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int VehicleType { get; set; }
        public int Make { get; set; }
        public int InsuranceType { get; set; }
        public int ReleaseVersion { get; set; }
        public Nullable<decimal> BaselineAmount { get; set; }
    }
}