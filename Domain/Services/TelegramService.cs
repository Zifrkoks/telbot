using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using telbot.Domain.Database.Models;
using telbot.Domain.Repositories;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telbot.Domain.Services
{
    public class TelegramService
    {
        UserRepository users;
        TelegramBotClient client;
        public TelegramService(UserRepository users, TelegramBotHandler botHandler)
        {
            this.users = users;
            this.client = botHandler.GetBot();
        }

        
        public async Task Start(Update update){
            var chatId = update.Message.Chat.Id;
            ChatUser user = new ChatUser{CreactedAt = DateTime.UtcNow, ChatId = chatId, Name = update.Message.Chat.Username};
            users.CreateAsync(user);

        }
        public async Task RegDate(Update update){
            var chatId = update.Message.Chat.Id;
            ChatUser user = await users.ReadByChatAsync(chatId);
            if(user != null)
            await client.SendTextMessageAsync(chatId,"дата регистрирации: " + user.CreactedAt);
            else
            await client.SendTextMessageAsync(chatId,"не могу найти тебя(");
        }

        internal async Task SendError(Update update)
        {
            var chatId = update.Message.Chat.Id;
            await client.SendTextMessageAsync(chatId,"нет такого варианта");
        }

        public async Task MyId(Update update){
            var chatId = update.Message.Chat.Id;
            ChatUser user = await users.ReadByChatAsync(chatId); 
            if(user != null)
            await client.SendTextMessageAsync(chatId,"ваш id: " + user.id);
            else
            await client.SendTextMessageAsync(chatId,"не могу найти тебя(");
        }
        public async Task GetDate(Update update){
             var chatId = update.Message.Chat.Id;
            await client.SendTextMessageAsync(chatId,"дата: " + DateTime.Now.Date.ToString());
        }
        
        public async Task GetDay(Update update){
            var chatId = update.Message.Chat.Id;
            await client.SendTextMessageAsync(chatId,"дата: " + DateTime.Now.Date.ToString());
        }
        public async Task GetTime(Update update){
            var chatId = update.Message.Chat.Id;
            await client.SendTextMessageAsync(chatId,"время: " + DateTime.Now.TimeOfDay.ToString());
        }        
        public async Task SendAll(string message){
            var sendto = await users.ReadAllAsync();
            foreach(var user in sendto)
            {
                await client.SendTextMessageAsync(user.ChatId,message);
            }
        }
    }
}