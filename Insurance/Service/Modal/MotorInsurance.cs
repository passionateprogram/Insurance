using InsuranceBusinessLogic;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using System;
using System.Threading.Tasks;

namespace InsuranceAgentBot.Modal
{
    public enum MotorType
    {
        [Describe("Two Wheeler")]
        TwoWheeler = 1,
        [Describe("Four Wheeler")]
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

        [Prompt("Please select your vechile manufacturing year")]
        public DateTime ManufacturingYear { get; set; }

        [Prompt("Have you claimed in previous year")]
        public bool PreviousYearClaim { get; set; }

        public static IForm<MotorInsuranceModel> BuildForm()
        {
            return new FormBuilder<MotorInsuranceModel>()

                .Message("You have selected Motor Insurance")

                //Vehicle Type
                .Field(nameof(VechileType))

                //Manufacturer
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(Manufacturer))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.Manufacturer); })
                .SetPrompt(new PromptAttribute("Please select your vehicle manufacturer: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    var vehicleManufacturers = new MotorInsuranceLogic().GetVehicleManufacturerList(state.VechileType.ToString());
                    foreach (var vehicleManufacturer in vehicleManufacturers)
                        field.AddDescription(vehicleManufacturer, vehicleManufacturer).AddTerms(vehicleManufacturer, vehicleManufacturer);
                    return await Task.FromResult(true);
                }))

                //Vehicle Model
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(Model))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.Model); })
                .SetPrompt(new PromptAttribute("Please select your vehicle model: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    var vehicleModels = new MotorInsuranceLogic().GetVehicleModelList(state.VechileType.ToString(), state.Manufacturer);
                    foreach (var vehicleModel in vehicleModels)
                        field.AddDescription(vehicleModel, vehicleModel).AddTerms(vehicleModel, vehicleModel);
                    return await Task.FromResult(true);
                }))

                //Year of Purchase
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(ManufacturingYear))
                .SetType(null)
                .SetActive(x => { return x.ManufacturingYear == DateTime.MinValue; })
                .SetPrompt(new PromptAttribute("Please select your vehicle manufacturing year: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    var manufactureringYears = new MotorInsuranceLogic().GetManufacturingYear();
                    foreach (var manufacturerYear in manufactureringYears)
                        field.AddDescription(manufacturerYear, manufacturerYear.ToString()).AddTerms(manufacturerYear, manufacturerYear.ToString());
                    return await Task.FromResult(true);
                }))

                //Claim
                .Field(nameof(PreviousYearClaim))

                .Build();
        }
    }
}