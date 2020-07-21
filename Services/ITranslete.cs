using System.Collections.Generic;
using System.Threading.Tasks;

namespace bot.Services
{
    public interface ITranslete
    {
        string translete(string text,string from, string to);
        Task<Dictionary<string,string>> supportLangue();
    }
}