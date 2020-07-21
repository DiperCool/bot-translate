using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bot.Services;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot.Commands
{
    public class PrintAllLanguesCommand : ICommand
    {
        public ITranslete _translete;

        public PrintAllLanguesCommand(ITranslete translete)
        {
            _translete=translete;
        }
        public async Task invokeCommand(TelegramBotClient bot, Message mas, string[] parametres)
        {
            Dictionary<string, string> allLang= await _translete.supportLangue();
            string s= "Все поддерживаемые языки \n\n\n";
            s += string.Join("", allLang.Select(x => $"{x.Key} : {x.Value}"+"\n").ToArray());
            await bot.SendTextMessageAsync(mas.From.Id, s);
        }

        public bool isCommand(string command)
        {
            return command=="/print";
        }
    }
}