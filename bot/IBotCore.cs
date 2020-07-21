using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace bot
{
    public interface IBotCore
    {
        Task invokeCommand(Message mas);
    }
}