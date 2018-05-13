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
        public String VehicleBrand { get; set; }

        [Prompt("Please select your vechile model")]
        public String VehicleModel { get; set; }

        [Prompt("Please select your vechile manufacturing year")]
        public string ManufacturingYear { get; set; }

        [Prompt("Have you claimed in previous year")]
        public bool PreviousYearClaim { get; set; }

        [Prompt("Please select Insurance")]
        public string InsuranceAgent { get; set; }

        private decimal? vehicleAmount;

        public CustomerDetail Customer { get; set; }

        public static IForm<MotorInsuranceModel> BuildForm()
        {
            return new FormBuilder<MotorInsuranceModel>()

                .Message("You have selected Motor Insurance")

                //Vehicle Type
                .Field(nameof(VechileType))

                //Manufacturer
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(VehicleBrand))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.VehicleBrand); })
                .SetPrompt(new PromptAttribute("Please select your vehicle manufacturer: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    if (state.VechileType > 0)
                    {
                        var vehicleManufacturers = new MotorInsuranceLogic().GetVehicleBrands((int)state.VechileType);
                        foreach (var vehicleManufacturer in vehicleManufacturers)
                            field.AddDescription(vehicleManufacturer, vehicleManufacturer).AddTerms(vehicleManufacturer, vehicleManufacturer);
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }))

                //Vehicle Model
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(VehicleModel))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.VehicleModel); })
                .SetPrompt(new PromptAttribute("Please select your vehicle model: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    if (state.VechileType > 0 && !string.IsNullOrEmpty(state.VehicleBrand))
                    {
                        var vehicleModels = new MotorInsuranceLogic().GetVehicleModels((int)state.VechileType, state.VehicleBrand);
                        foreach (var vehicleModel in vehicleModels)
                            field.AddDescription(vehicleModel, vehicleModel).AddTerms(vehicleModel, vehicleModel);
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }))

                //Year of Purchase
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(ManufacturingYear))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.ManufacturingYear); })
                .SetPrompt(new PromptAttribute("Please select your vehicle manufacturing year: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    if (state.VechileType > 0 && !string.IsNullOrEmpty(state.VehicleBrand) && !string.IsNullOrEmpty(state.VehicleModel))
                    {
                        var manufactureringYears = new MotorInsuranceLogic().GetVehicleManufactureYear((int)state.VechileType, state.VehicleBrand, state.VehicleModel);
                        foreach (var manufacturerYear in manufactureringYears)
                        {
                            var year = manufacturerYear.ToString();
                            field.AddDescription(year, year).AddTerms(year, year);
                        }
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }))

                //Claim
                .Field(nameof(PreviousYearClaim))

                .Confirm(
                )
                //InsuranceAgent
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(InsuranceAgent))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.InsuranceAgent); })
                .SetPrompt(new PromptAttribute("Please select Insurance Company: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    var year = Convert.ToInt32(state.ManufacturingYear);
                    if (state.VechileType > 0 && !string.IsNullOrEmpty(state.VehicleBrand) && !string.IsNullOrEmpty(state.VehicleModel) && year != 0)
                    {
                        var vehicleAmount = new MotorInsuranceLogic().GetVehicleAmount((int)state.VechileType, state.VehicleBrand, state.VehicleModel, year);
                        var vendorDetails = new MotorInsuranceLogic().GetVendorDetails((int)state.VechileType);
                        foreach (var vendor in vendorDetails)
                        {
                            var vendorDetail = vendor.ToString(vehicleAmount, year);
                            field.AddDescription(vendorDetail, vendorDetail).AddTerms(vendorDetail, vendorDetail);
                        }
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }))

                .Build();
        }
    }
}