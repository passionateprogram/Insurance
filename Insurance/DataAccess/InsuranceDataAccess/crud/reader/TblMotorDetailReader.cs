using InsuranceDataAccess.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDataAccess.crud.reader
{
    public class TblMotorDetailReader
    {
        public TblMotorDetailReader()
        {

        }

        public List<string> ReadALLBrands()
        {
            var result = new List<string>();

            using (var db = new hackathonteam289_dbEntities1())
            {
                result = db.tblMotorDetails.Select(i=>i.Brand).Distinct().ToList();                
            }

            return result;
        }
    }
}
