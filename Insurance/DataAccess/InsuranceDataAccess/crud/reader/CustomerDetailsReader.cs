using InsuranceDataAccess.model;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceDataAccess.crud.reader
{
    public class CustomerDetailsReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mobileNo"></param>
        /// <returns></returns>
        public List<tblCustomerDetail> GetCustomerDetails(string mobileNo)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblCustomerDetails.Where(i => i.PrimaryContactNumber == mobileNo).ToList();
            }
        }
    }
}
