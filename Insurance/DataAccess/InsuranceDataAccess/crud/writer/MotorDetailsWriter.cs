using InsuranceDataAccess.model;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceDataAccess.crud.writer
{
    public class MotorDetailsWriter
    {
        public void AddInsuranceTransacationData(tblMotorPaymentDetail objMotorPaymentDetails)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                tblMotorPaymentDetail objMotPayDetails = new tblMotorPaymentDetail();
                db.SaveChanges();              
            }
        }
    }
}
