using System;
using System.Threading.Tasks;
using bot.Services;
using bot.Services.Repositoriy;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot.Commands
{
    public class CommandHello : ICommand
    {
        private string Command="/start";
        public ITranslete _itran;
        public IRepositoriy _irep;

        public CommandHello(ITranslete itran, IRepositoriy irep)
        {
            _irep=irep;
            _itran=itran;
        }
        public async Task invokeCommand(TelegramBotClient bot, Message mas, string[] p)
        {
            await bot.SendTextMessageAsync(mas.From.Id,"Я переводчик");
            if(! await _irep.loginIsExist(mas.From.Id))
            {
                _irep.setLogin(mas.From.Id);
            }


        }

        public bool isCommand(string command)
        {
            return Command==command;
        }
    }
}