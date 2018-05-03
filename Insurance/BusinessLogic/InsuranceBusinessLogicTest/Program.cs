using InsuranceBusinessLogic;

namespace InsuranceBusinessLogicTest
{
    class Program
    {
        static void Main(string[] args)
        {
           var s = new MotorInsuranceLogic().GetVendorDetails(4);
        }
    }
}
