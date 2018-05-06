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

        [Prompt("Please select Insurance")]
        public string InsuranceAgent { get; set; }

        private decimal? vehicleAmount;

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
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(Model))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.Model); })
                .SetPrompt(new PromptAttribute("Please select your vehicle model: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    if (state.VechileType > 0 && !string.IsNullOrEmpty(state.Manufacturer))
                    {
                        var vehicleModels = new MotorInsuranceLogic().GetVehicleModels((int)state.VechileType, state.Manufacturer);
                        foreach (var vehicleModel in vehicleModels)
                            field.AddDescription(vehicleModel, vehicleModel).AddTerms(vehicleModel, vehicleModel);
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }))

                //Year of Purchase
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(ManufacturingYear))
                .SetType(null)
                .SetActive(x => { return x.ManufacturingYear == DateTime.MinValue; })
                .SetPrompt(new PromptAttribute("Please select your vehicle manufacturing year: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    if (state.VechileType > 0 && !string.IsNullOrEmpty(state.Manufacturer) && !string.IsNullOrEmpty(state.Model))
                    {
                        var manufactureringYears = new MotorInsuranceLogic().GetVehicleManufactureYear((int)state.VechileType, state.Manufacturer, state.Model);
                        foreach (var manufacturerYear in manufactureringYears)
                            field.AddDescription(manufacturerYear, manufacturerYear.ToString()).AddTerms(manufacturerYear, manufacturerYear.ToString());
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }))

                //Claim
                .Field(nameof(PreviousYearClaim))

                //Year of Purchase
                .Field(new FieldReflector<MotorInsuranceModel>(nameof(InsuranceAgent))
                .SetType(null)
                .SetActive(x => { return string.IsNullOrEmpty(x.InsuranceAgent); })
                .SetPrompt(new PromptAttribute("Please select your vehicle manufacturing year: {||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
                .SetDefine(async (state, field) =>
                {
                    if (state.VechileType > 0 && !string.IsNullOrEmpty(state.Manufacturer) && !string.IsNullOrEmpty(state.Model) && state.ManufacturingYear != DateTime.MinValue)
                    {
                        var vehicleAmount = new MotorInsuranceLogic().GetVehicleAmount((int)state.VechileType, state.Manufacturer, state.Model, state.ManufacturingYear.Year);
                        var vendorDetails = new MotorInsuranceLogic().GetVendorDetails((int)state.VechileType);
                        foreach (var vendor in vendorDetails)
                        {
                            var vendorDetail = vendor.ToString(vehicleAmount, state.ManufacturingYear.Year);
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