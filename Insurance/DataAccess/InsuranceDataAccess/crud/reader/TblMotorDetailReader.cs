using InsuranceDataAccess.model;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceDataAccess.crud.reader
{
    public class TblMotorDetailReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public List<string> GetVehicleBrands(int vehicleType)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMotorDetails.Where(i => i.VehicleType == vehicleType).Select(i => i.Brand).Distinct().ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<string> GetVehicleModels(int vehicleType, string brandName)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMotorDetails.Where(i => i.VehicleType == vehicleType && i.Brand.ToLower() == brandName.ToLower()).Select(i => i.Model).Distinct().ToList();
            }
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
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMotorDetails.Where(i => i.VehicleType == vehicleType && i.Brand.ToLower() == brandName.ToLower() && i.Model.ToLower() == model.ToLower()).Select(i => i.Make).Distinct().ToList();
            }
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
            using (var db = new hackathonteam289_dbEntities1())
            {
                var vehicle = db.tblMotorDetails.FirstOrDefault(i => i.VehicleType == vehicleType && i.Brand.ToLower() == brandName.ToLower() && i.Model.ToLower() == model.ToLower() && i.Make == year);
                if (vehicle != null)
                    return vehicle.BaselineAmount;
                else
                    return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        public List<tblMotorVendorDetail> GetVendorDetails(int vehicleType)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMotorVendorDetails.Where(i => i.VehicleType == vehicleType).ToList();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <param name="venderName"></param>
        /// <returns></returns>
        public string GetVendorFeatures(int vehicleType, string venderName)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                var vendor = db.tblMotorVendorDetails.FirstOrDefault(i => i.VehicleType == vehicleType && i.VendorName.ToLower() == venderName.ToLower());
                if (vendor != null)
                    return vendor.Features;
                else
                    return null;
            }
        }
    }
}