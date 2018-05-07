using InsuranceDataAccess.crud.reader;
using InsuranceDataAccess.model;
using System.Collections.Generic;
using System.Linq;
namespace InsuranceBusinessLogic
{
    public class MotorInsuranceLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public List<string> GetVehicleBrands(int vehicleType)
        {
            return new TblMotorDetailReader().GetVehicleBrands(vehicleType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<string> GetVehicleModels(int vehicleType, string brandName)
        {
            return new TblMotorDetailReader().GetVehicleModels(vehicleType, brandName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="brandName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<int> GetVehicleManufactureYear(int vehicleType, string brandName, string model)
        {
            return new TblMotorDetailReader().GetVehicleManufactureYear(vehicleType, brandName, model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="brandName"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public decimal? GetVehicleAmount(int vehicleType, string brandName, string model, int year)
        {
            return new TblMotorDetailReader().GetVehicleAmount(vehicleType, brandName, model, year);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public List<MotorVendorDetail> GetVendorDetails(int vehicleType)
        {
            var motorVendorDetails = new TblMotorDetailReader().GetVendorDetails(vehicleType);
            if (motorVendorDetails != null)
                return motorVendorDetails.Select(x => BusinessUtility.Copy<tblMotorVendorDetail, MotorVendorDetail>(x, new MotorVendorDetail())).ToList();
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="venderName"></param>
        /// <returns></returns>
        public List<string> GetVendorFeatures(int vehicleType, string venderName)
        {
            var feature = new TblMotorDetailReader().GetVendorFeatures(vehicleType, venderName);
            if (!string.IsNullOrEmpty(feature))
                feature.Split(';').ToList();
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobileNum"></param>
        /// <returns></returns>
        public CustomerDetail GetCustomerDetails(string mobileNum)
        {
            var customerDetails = new CustomerDetailsReader().GetCustomerDetails(mobileNum);
            if (customerDetails != null)
                return customerDetails.Select(x => BusinessUtility.Copy<tblCustomerDetail, CustomerDetail>(x, new CustomerDetail())).FirstOrDefault();
            return null;
        }

        #region Dummy Entries
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
        #endregion Dummy Entries
    }
}