using System.Collections.Generic;
using System.Threading.Tasks;
using YandexTranslateCSharpSdk;

namespace bot.Services
{
    public class Translete : ITranslete
    {
        private YandexTranslateSdk _wrapper;
        public Translete(string key)
        {
            _wrapper=new YandexTranslateSdk(){ApiKey=key};
        }
        public async Task<Dictionary<string,string>> supportLangue()
        {
            return await _wrapper.GetLanguagesAsync();
        }

        public string translete(string text,string from, string to)
        {
            return _wrapper.TranslateTextAsync(text, $"{from.ToLower()}-{to.ToLower()}").Result;
        }
    }
}