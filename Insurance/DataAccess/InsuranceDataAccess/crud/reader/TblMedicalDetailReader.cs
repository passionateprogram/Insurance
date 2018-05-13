using InsuranceDataAccess.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDataAccess.crud.reader
{
    public class TblMedicalDetailReader
    {
        public List<string> GetAllInsuranceTypes()
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblInsuranceTypes.Select(i => i.InsuranceType).ToList();
            }
        }

        public List<tblMediPolicyDetail> GetMedicalPolicyDetailsByPolicyName(string policyName)
        {           
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMediPolicyDetails.Where(i => i.PolicyName.ToLower() == policyName.ToLower()).ToList();
            }          
        }

        public List<tblMediPolicyDetail> GetMedicalPolicyDetailsByPolicyCode(string policyCode)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMediPolicyDetails.Where(i => i.PolicyCode.ToLower() == policyCode.ToLower()).ToList();
            }
        }

        public tblMedTransactionDetail GetMedicalTransactionDetails(int id)
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMedTransactionDetails.FirstOrDefault(i => i.PolicyId == id);
            }
        }

        public List<string> GetPolicyNames()
        {
            using (var db = new hackathonteam289_dbEntities1())
            {
                return db.tblMediPolicyDetails.Select(i => i.PolicyName).Distinct().ToList();
            }
        }
    }
}
