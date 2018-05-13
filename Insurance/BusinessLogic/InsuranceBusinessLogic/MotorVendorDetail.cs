using System;

namespace InsuranceBusinessLogic
{
    public class MotorVendorDetail
    {
        public int ID { get; set; }
        public string VendorName { get; set; }
        public decimal Rate { get; set; }
        public string Features { get; set; }
        public int? VehicleType { get; set; }

        public decimal Premium { get; set; }

        public string ToString(decimal? vehicleAmount, int manufacturingYear)
        {
            if (vehicleAmount.HasValue)
            {
                var depreciation = vehicleAmount.Value;
                for (var i = manufacturingYear; i >= DateTime.Now.Year; i--)
                {
                    depreciation = depreciation * (decimal)0.05;
                }
                Premium = depreciation * (Rate / 100);
                return string.Format("{0} offers the premuim of INR {1}/-", VendorName, Premium);
            }
            return null;
        }
    }
}
