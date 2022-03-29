using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Homework.Api.Data.IRepositories;
using Homework.Api.Models;
using Homework.Api.Models.Common;
using Homework.Api.Service.Extensions;
using Homework.Api.Service.Interfaces;
using Homework.Api.Service.ViewModels;

namespace Homework.Api.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Create
        public Task<UserModel> CreateAsync(UserRegisterViewModel model)
        {
            UserModel user = new UserModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };

            return _userRepository.CreateAsync(user);
        }
        #endregion

        #region Delete
        public Task<bool> DeleteAsync(Expression<Func<UserModel, bool>> expression)
        {
            return _userRepository.DeleteAsync(expression);
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<UserModel>> GetAllAsync(int pageSize, int pageIndex, Expression<Func<UserModel, bool>> expression = null)
        {
            var users = await _userRepository.GetAllAsync(expression);

            return users.ToPagenation(pageSize, pageIndex);
        }
        #endregion

        #region Get
        public async Task<BaseResponse<UserModel>> GetAsync(Expression<Func<UserModel, bool>> expression)
        {
            var response = new BaseResponse<UserModel>();

            var user = await _userRepository.GetAsync(expression);

            if(user is null)
            {
                response.Error = new ErrorModel(404, "User not found!");
                return response;
            }

            response.Data = user;

            return response;
        }
        #endregion

        #region GetUserInfo
        public async Task<BaseResponse<UserModel>> GetUserInfoAsync(UserViewModel model)
        {
            var response = new BaseResponse<UserModel>();

            var user = await _userRepository.GetUserInfoAsync(model);

            if(user is null)
            {
                response.Error = new ErrorModel(404, "User not found!");
                return response;
            }

            response.Data = user;

            return response;
        }
        #endregion

        #region Update
        public Task<UserModel> UpdateAsync(UserUpdatingViewModel model)
        {
            UserModel user = new UserModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
            };

            return _userRepository.UpdateAsync(user);
        }
        #endregion

        #region UpdateSignIn
        public Task<UserModel> UpdatePasswordAsync(UserSignInViewModel model)
        {
            return _userRepository.UpdatePasswordAsync(model);
        }
        #endregion
    }
}