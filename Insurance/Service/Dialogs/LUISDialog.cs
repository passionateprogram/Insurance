using InsuranceAgentBot.Modal;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace InsuranceAgentBot.Dialogs
{
    [LuisModel("7aff903d-6646-4571-adcc-1a4994801bad", "4fadd08786544c78ba03e790f2dfb487")]
    [Serializable]
    public class LUISDialog : LuisDialog<MotorInsuranceModel>
    {

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("GreetingIntent")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            context.Call(new RootDialog(), Callback);
        }

        [LuisIntent("InsurancePurchase")]
        public async Task InsurancePurchase(IDialogContext context, LuisResult result)
        {
            var entities = new List<EntityRecommendation>();
            String insuranceType = String.Empty;
            MotorInsuranceModel motorInsurance = new MotorInsuranceModel();
            foreach (var entity in result.Entities)
            {
                if (entity.Type == "InsuranceType")
                {
                    insuranceType = entity.Entity.ToLower();
                }
                else if (entity.Type == "VechileType")
                {
                    var e = new EntityRecommendation(entity.Type);
                    entities.Add(e);
                    var a = entity.Resolution["values"];
                    var value = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)a).First).Value.ToString().ToLower();
                    if (value == "two wheeler")
                    {
                        e.Entity = "two wheeler";
                        motorInsurance.VechileType = MotorType.TwoWheeler;
                    }
                    else if(value == "four wheeler")
                    {
                        e.Entity = "four wheeler";
                        motorInsurance.VechileType = MotorType.FourWheeler;
                    }
                }
                
            }

            if (insuranceType == "motor")
            {
                //var motorDialog = FormDialog.FromForm<MotorInsuranceModel>(MotorInsuranceModel.BuildForm, FormOptions.PromptInStart);
                //context.Call(motorDialog, this.ResumeAfterOptionDialog);
                //context.Forward(motorDialog, this.ResumeAfterOptionDialog, motorInsurance, CancellationToken.None); 
                

                var motorDialog = new FormDialog<MotorInsuranceModel>(new MotorInsuranceModel(), MotorInsuranceModel.BuildForm, FormOptions.PromptInStart, entities.Count == 0 ? null : entities);
                  //context.Call<MotorInsuranceModel>(motorDialog, ResumeAfterOptionDialog);
                  context.Forward(motorDialog, this.ResumeAfterOptionDialog, motorInsurance, CancellationToken.None);

                  /*var motorDialog = FormDialog.FromForm<MotorInsuranceModel>(MotorInsuranceModel.BuildForm, FormOptions.PromptInStart);
                  //context.Call(motorDialog, this.ResumeAfterOptionDialog);
                  context.Forward(motorDialog, this.ResumeAfterOptionDialog, motorInsurance, CancellationToken.None);*/
                  context.Wait(MessageReceived);
            }

        }

        private Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<MotorInsuranceModel> result)
        {
            //Need to Respond with different options of Motor insurance
            throw new NotImplementedException();
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }


    }
}