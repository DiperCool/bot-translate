using System.Linq;
using System.Threading.Tasks;
using bot.Services.db;
using bot.Services.db.Entity;
using Microsoft.EntityFrameworkCore;

namespace bot.Services.Repositoriy
{
    public class Repositoriy:IRepositoriy
    {
        private Context _context;
        public Repositoriy(Context context)
        {
            _context=context;
        }

        public string[] getLangues(int id)
        {
            User user= _context.Users.FirstOrDefault(x=>x.UserIdintifiticator==id);
            return new string[]{user.From, user.To};
        }

        public async Task<bool> loginIsExist(int id)
        {
            return await _context.Users.AnyAsync(x=>x.UserIdintifiticator==id);
        }

        public void setLangues(int id,string from, string to)
        {
            User user= _context.Users.FirstOrDefault(x=>x.UserIdintifiticator==id);
            user.To=to;
            user.From=from;
            _context.Users.Update(user);
            _context.SaveChanges();

        }

        public void setLogin(int id)
        {
            User user= new User{UserIdintifiticator=id, To="En", From="Ru"};
            _context.Add(user);
            _context.SaveChanges();
        }
    }
}