using System.Threading.Tasks;
using bot.Services;
using bot.Services.Repositoriy;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot.Commands
{
    public class SetCommand : ICommand
    {
        public IRepositoriy _context;
        public  ITranslete _translete;
        public SetCommand(IRepositoriy context, ITranslete translete)
        {
            _context=context;
            _translete=translete;
    
        }
        public async Task invokeCommand(TelegramBotClient bot, Message mas, string[] parametres)
        {
            try{
                string from = parametres[0];
                string to = parametres[1];
                var langues=await _translete.supportLangue();
                if(langues.ContainsKey(from.ToLower())&&langues.ContainsKey(to.ToLower()))
                {
                    _context.setLangues(mas.From.Id, from, to);
                    await bot.SendTextMessageAsync(mas.From.Id, "ок");
                    return;
                }
                await bot.SendTextMessageAsync(mas.From.Id, "Такой язык не поддерживается");
            }
            catch{
                await bot.SendTextMessageAsync(mas.From.Id, "Error: you invalid");
            }

        }

        public bool isCommand(string command)
        {
            return command=="/set";
        }
    }
}