﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Homework.Api.Service.Interfaces;
using Homework.Api.Service.ViewModels;
using Homework.Api.Services.Services;

namespace Homework.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterViewModel model)
        {
            model.Password = HashPassword.Create(model.Password);
            return Created("User succesfully created", await _userService.CreateAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageSize, int pageIndex)
        {
            return Ok(await _userService.GetAllAsync(pageSize, pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _userService.GetAsync(p => p.Id.Equals(id));

            return result.Error?.Code == 404 ? NotFound(result) : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetInfo(UserViewModel model)
        {
            model.Password = HashPassword.Create(model.Password);
            var result = await _userService.GetUserInfoAsync(model);

            return result.Error?.Code == 404 ? NotFound("User not found") : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            bool result = await  _userService.DeleteAsync(p => p.Id == id);

            return result == true ? Ok("User succesfully deleted") : NotFound("User not found");

        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdatingViewModel user)
        {
            user.Password = HashPassword.Create(user.Password);
            var entry = await _userService.UpdateAsync(user);

            return entry == null ? NotFound("User not found") : Ok(entry);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSignIn(UserSignInViewModel model)
        {
            model.Password = HashPassword.Create(model.Password);
            var user = await _userService.UpdatePasswordAsync(model);

            return user == null ? NotFound("User not found") : Ok(user);
        }
    }
}
