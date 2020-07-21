using System.Threading.Tasks;

namespace bot.Services.Repositoriy
{
    public interface IRepositoriy
    {
        Task<bool> loginIsExist(int id);
        void setLangues(int id,string from, string to);
        void setLogin(int id);
        string[] getLangues(int id);
    }
}