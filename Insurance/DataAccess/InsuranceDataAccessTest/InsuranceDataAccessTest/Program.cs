using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDataAccessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            new InsuranceDataAccess.crud.reader.TblMotorDetailReader().ReadALLBrands();
        }
    }
}
