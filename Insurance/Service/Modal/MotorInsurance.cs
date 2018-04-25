using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAgentBot.Modal
{
    public enum MotorType
    {
        TwoWheeler = 1,
        FourWheeler
    };
    [Serializable]
    public class MotorInsuranceModel
    {
        
        //[Prompt("Please select your Vechile type")]
        public MotorType VechileType { get; set; }
        [Prompt("Please select your vechile manufacturer")]
        public String Manufacturer { get; set; }

        [Prompt("Please select your vechile model")]
        public String Model { get; set; }

        [Prompt("Please select your vechile manufacturing date")]
        public DateTime ManufacturerYear { get; set; }
        [Prompt("Have you claimed in previous year")]
        public bool PreviousYearClaim { get; set; }

        public static IForm<MotorInsuranceModel> BuildForm()
        {
            return new FormBuilder<MotorInsuranceModel>()
                .Message("You have selected Motor Insurance")
                .Build();
        }
    }
}