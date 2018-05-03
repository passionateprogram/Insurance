using System;

namespace InsuranceBusinessLogic
{
    public class MotorVendorDetail
    {
        public int ID { get; set; }
        public string VendorName { get; set; }
        public decimal Rate { get; set; }
        public string Features { get; set; }
        public Nullable<int> VehicleType { get; set; }
    }
}
