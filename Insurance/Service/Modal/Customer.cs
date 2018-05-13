using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAgentBot.Modal
{
    [Serializable]
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerRefID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string Country { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SeccondaryContactNumber { get; set; }
        public string EmailID { get; set; }
        public System.DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string SSN { get; set; }
        public string DrivingLicenseNo { get; set; }
        public Nullable<System.DateTime> DrivingLicenseExpiry { get; set; }
        public string MaritalStatus { get; set; }

        public static IForm<CustomerModel> BuildForm()
        {
            return new FormBuilder<CustomerModel>().Message("Please enter your details").Build();
        }
    }
}