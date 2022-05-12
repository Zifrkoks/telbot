using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace telbot.Domain.Services
{
    public class TelegramBotHandler
    {
        private TelegramBotClient client;
        private IConfiguration configuration;

        public TelegramBotHandler(IConfiguration configuration){
            this.configuration = configuration;
            client = new TelegramBotClient(configuration["Token"]);
        }
        public TelegramBotClient GetBot(){
            if(client != null)
            return client;
            client = new TelegramBotClient(configuration["Token"]);
            return client;
        }
        public async Task SetWebHook(){
            if(client != null)
            client = new TelegramBotClient(configuration["Token"]);
            var hook = $"{configuration["Url"]}/api/message/update";
            await client.SetWebhookAsync(hook);
            
        }
    }
}