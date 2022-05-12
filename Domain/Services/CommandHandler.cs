using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace telbot.Domain.Services
{
    public class CommandHandler
    {
        TelegramService service;

        public CommandHandler(TelegramService service)
        {
            this.service = service;
        }

        public async Task Execute(Update update){
            if(update.Message.Text.Contains(CommandNames.StartCommand))
                await service.Start(update);
            else if(update.Message.Text.Contains(CommandNames.RegDateCommand))
                await service.RegDate(update);
            else if(update.Message.Text.Contains(CommandNames.MyIdCommand))
                await service.MyId(update);
            else if(update.Message.Text.Contains(CommandNames.GetDateCommand))
                await service.GetDate(update);
            else if(update.Message.Text.Contains(CommandNames.GetDayCommand))
                await service.GetDay(update);
            else if(update.Message.Text.Contains(CommandNames.GetTimeCommand))
                await service.GetTime(update);
            else
                await service.SendError(update);
        }
        public async Task SendAll(string message){
            service.SendAll(message);
        }
    }
}