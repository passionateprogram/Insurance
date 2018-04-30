using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InsuranceAgentBot.Modal;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace InsuranceAgentBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private const string MedicalInsurance = "Medical Insurance";
        private const string LifeInsurance = "Life Insurance";
        private const string MotorInsurance = "Motor Insurance";
        public enum Step { Welcome, Intro, SelectInsurance };

        public async Task StartAsync(IDialogContext context)
        {

            await context.PostAsync("Hi I'm Insurance Agent Bot");
            await Respond(context);
            context.Wait(MessageReceivedAsync);

        }

        private static async Task Respond(IDialogContext context)
        {
            var userName = String.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            Step mode = Step.Welcome;
            context.UserData.TryGetValue<Step>("mode", out mode);
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("What is your name?");
                context.UserData.SetValue<bool>("GetName", true);
                context.UserData.SetValue<Step>("mode", Step.SelectInsurance);
            }
            else
            {
                await context.PostAsync(String.Format("Hi {0}.  How can I help you today?", userName));
            }
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            ShowOptions(context, message.Text);
        }

        private void ShowOptions(IDialogContext context, string username)
        {
            PromptDialog.Choice(context, this.OnOptionSelected, new List<string>() { MedicalInsurance, LifeInsurance, MotorInsurance },
                string.Format("Hi {0}. \r\nAre you looking for a Medical Insurance, Life Insurance or a Motor Insurance?", username), "Not a valid option", 3);
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<string> result)
        {

            try
            {
                string optionSelected = await result;

                switch (optionSelected)
                {
                    case MedicalInsurance:
                        //context.Call(new FlightsDialog(), this.ResumeAfterOptionDialog);
                        break;

                    case LifeInsurance:
                        //context.Call(new HotelsDialog(), this.ResumeAfterOptionDialog);
                        break;
                    case MotorInsurance:
                        var motorDialog = FormDialog.FromForm<MotorInsuranceModel>(MotorInsuranceModel.BuildForm, FormOptions.PromptInStart);
                        context.Call(motorDialog, this.ResumeAfterOptionDialog);
                        break;
                }
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attempts :(. But don't worry, I'm handling that exception and you can try again!");

                context.Wait(this.MessageReceivedAsync);
            }
        }

        private Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            throw new NotImplementedException();
        }


    }
}