using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Homework.Api.Models;
using Homework.Api.Models.Common;
using Homework.Api.Service.ViewModels;

namespace Homework.Api.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> CreateAsync(UserRegisterViewModel model);

        Task<UserModel> UpdateAsync(UserUpdatingViewModel model);

        Task<UserModel> UpdatePasswordAsync(UserSignInViewModel model);

        Task<bool> DeleteAsync(Expression<Func<UserModel, bool>> expression);

        Task<IEnumerable<UserModel>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<UserModel, bool>> expression = null);

        Task<BaseResponse<UserModel>> GetAsync(Expression<Func<UserModel, bool>> expression);

        Task<BaseResponse<UserModel>> GetUserInfoAsync(UserViewModel model);
    }
}
