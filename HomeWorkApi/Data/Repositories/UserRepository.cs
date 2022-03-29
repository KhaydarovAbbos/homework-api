using Homework.Api.Data.Contexts;
using Homework.Api.Data.IRepositories;
using Homework.Api.Models;
using System.Linq;
using System.Threading.Tasks;
using Homework.Api.Enums;
using Homework.Api.Service.ViewModels;

namespace Homework.Api.Data.Repositories
{
#pragma warning disable
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserModel> GetUserInfoAsync(UserViewModel model)
        {
            return _dbSet.FirstOrDefault(
                p => p.Password == model.Password
                && p.Email == model.Email);
        }

        public async Task<UserModel> UpdatePasswordAsync(UserSignInViewModel model)
        {
            var user = await _dbSet.FindAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                user.Password = model.Password;
                user.State = ItemState.Updated;

                await _dbContext.SaveChangesAsync();

                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
