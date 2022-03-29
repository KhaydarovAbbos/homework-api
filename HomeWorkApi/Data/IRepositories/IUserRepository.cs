using Homework.Api.Models;
using Homework.Api.Service.ViewModels;
using System.Threading.Tasks;

namespace Homework.Api.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel> UpdatePasswordAsync(UserSignInViewModel model);

        Task<UserModel> GetUserInfoAsync(UserViewModel model);
    }
}
