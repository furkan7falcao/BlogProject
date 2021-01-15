using Furkan.Furkan_BlogProject.Business.Interfaces;
using Furkan.Furkan_BlogProject.Business.Tools.JwtTool;
using Furkan.Furkan_BlogProject.DTO.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furkan.Furkan_BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(AppUserLoginDTO appUserLoginDTO)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDTO);

            if(user != null)
                return Created("", _jwtService.GenerateJwt(user));

            return BadRequest("kullanıcı adı veya şifre hatalı");
        }


        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);
            return Ok(new AppUserActiveDTO { Name = user.Name, SurName = user.SurName });
        }



    }
}
