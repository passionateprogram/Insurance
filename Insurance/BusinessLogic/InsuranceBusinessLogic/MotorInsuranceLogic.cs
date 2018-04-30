using System.Collections.Generic;

namespace InsuranceBusinessLogic
{
    public class MotorInsuranceLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public List<string> GetVehicleManufacturerList(string vehicleType)
        {
            if (vehicleType == "TwoWheeler")
                return new List<string>() { "Honda", "Bajaj", "TVS" };
            if (vehicleType == "FourWheeler")
                return new List<string>() { "Honda", "TATA", "Maruti", "Toyota", "Chevrolet" };
            return new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
        public List<string> GetVehicleModelList(string vehicleType, string manufacturer)
        {
            if (vehicleType == "TwoWheeler")
            {
                switch (manufacturer)
                {
                    case "Honda":
                        return new List<string>() { "Shine", "Unicorn", "Activa" };
                    case "Bajaj":
                        return new List<string>() { "Pulsar", "Discover" };
                    case "TVS":
                        return new List<string>() { "Apache", "Streak", "XL" };
                    default:
                        return null;
                }
            }
            if (vehicleType == "FourWheeler")
            {
                switch (manufacturer)
                {
                    case "Honda":
                        return new List<string>() { "City", "Amaze", "Civic" };
                    case "TATA":
                        return new List<string>() { "Indica", "Zest", "Nano" };
                    case "Maruti":
                        return new List<string>() { "Dzire", "Celerio", "Ciaz" };
                    case "Toyota":
                        return new List<string>() { "Etios", "Fortuner", "Innova" };
                    case "Chevrolet":
                        return new List<string>() { "Tavera", "Beat" };
                    default:
                        return null;
                }
            }
            return new List<string>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> GetManufacturingYear()
        {
            return new List<int>() { 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018 };
        }
    }
}
