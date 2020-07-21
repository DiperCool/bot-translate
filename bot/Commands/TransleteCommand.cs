using System.Threading.Tasks;
using bot.Services;
using bot.Services.Repositoriy;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot.Commands
{
    public class TransleteCommand : ICommand
    {
        public ITranslete _translete;
        public IRepositoriy _context;

        public TransleteCommand(ITranslete translete, IRepositoriy context)
        {
            _translete=translete;
            _context=context;
        }
        public async Task invokeCommand(TelegramBotClient bot, Message mas,string[] p)
        {
            try{
                string[] langs= _context.getLangues(mas.From.Id);
                await bot.SendTextMessageAsync(mas.From.Id, _translete.translete(mas.Text, langs[0],langs[1]));
            }
            catch{
                await bot.SendTextMessageAsync(mas.From.Id, "Error: you invalid");
            }

        }

        public bool isCommand(string command)
        {
            return command[0]!='/';
        }
    }
}