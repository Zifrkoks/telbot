using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot;
using telbot.Domain.Database.Models;
using telbot.Domain.Services;
using Newtonsoft.Json;

namespace telbot.Controllers
{
    public class BotController : ControllerBase
    {
        private readonly ILogger<BotController> _logger;
        public readonly CommandHandler commandHandler;
        public readonly IConfiguration conf;


        public BotController(ILogger<BotController> logger, CommandHandler commandHandler,IConfiguration configuration)
        {
            _logger = logger;
            this.commandHandler = commandHandler;
            conf = configuration;
        }
        [Route("api/message")]
        [HttpGet]
        public async Task<string> index(){
            
            return "так то работает:" + conf["Token"] + " " + conf["Url"];
        }
        [Route("api/message/update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]object update){
            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            await commandHandler.Execute(upd);
            return Ok();
        }
        [Route("api/send")]
        [HttpPost]
        public async Task<IActionResult> SendAll([FromBody]string message){
            _logger.LogInformation($"ThisWork");

            commandHandler.SendAll(message);
            return Ok();

        }

    }
}