using EventReg.Common;
using EventReg.DB.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventReg.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EventDBContext _context;
        public UserRepository(EventDBContext context)
        {
            this._context = context;
        }

        public async Task<bool> Login(string name, string password)
        {
          return  await _context.Users.AnyAsync(s => s.Name == name && s.Password == password);
        }
    }
}
