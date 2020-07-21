using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bot.Commands;
using bot.Services;
using bot.Services.Repositoriy;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot
{
    public class BotCore:IBotCore
    {
        private TelegramBotClient _bot;
        private IEnumerable<ICommand>  Commands= new List<ICommand>();
        public BotCore(TelegramBotClient bot,IEnumerable<ICommand> commands)
        {
            _bot=bot;
            Commands=commands;
        }
        public async Task invokeCommand(Message mas)
        {
            foreach(ICommand Command in Commands)
            {
                List<string> list=mas.Text.Split(" ").ToList();
                var command= list[0];
                list.RemoveAt(0);
                if(Command.isCommand(command))
                {
                    await Command.invokeCommand(_bot,mas , list.ToArray());
                }
            }
        }
    }
}