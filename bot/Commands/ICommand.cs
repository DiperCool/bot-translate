using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bot.Commands
{
    public interface ICommand
    {
        bool isCommand(string command);
        Task invokeCommand(TelegramBotClient bot, Message mas, string[] parametres);
    }
}