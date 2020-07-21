using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bot.Services.db;
using bot.Services.Repositoriy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace bot.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private IBotCore _bot;
        IRepositoriy _context;

        public WeatherForecastController(IBotCore bot, IRepositoriy context)
        {
            _context=context;
            _bot=bot;
        }

        [HttpPost("/update")]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if(update.Message.Type!=MessageType.Text)
            {
                return Ok();
            }
            await _bot.invokeCommand(update.Message);
            return Ok(HttpContext.Request.Query);
        }
        [HttpGet("/")]
        public IActionResult hello(){
            return Ok();
        }
    }
}
