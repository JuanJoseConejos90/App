using AutoMapper;
using deliveryAppCore.DTOs;
using deliveryAppCore.Entities;
using deliveryAppCore.Interfaces;
using deliveryAppCore.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliveryAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _ILogin;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public LoginController(ILogin ILogin, IConfiguration config, IMapper mapper)
        {
            _ILogin = ILogin;
            _config = config;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("Autheticate")]
        public async Task<IActionResult> Autheticate([FromBody] LoginDto loginDto)
        {
            var user = _mapper.Map<User>(loginDto);
            var dataAsync = await _ILogin.Login(user);
            string msg = _config["msgs:Unauthorized"];
            var response = dataAsync != null ? ApiResponse<LoginResponse>.Success(dataAsync) : ApiResponse<LoginResponse>.Fail(msg);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        public async Task<IActionResult> signUp([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var dataAsync = await _ILogin.SignUp(user);
            string msg = _config["msgs:ErrorRequest"];
            var response = dataAsync ? ApiResponse<Boolean>.Success(dataAsync) : ApiResponse<Boolean>.Fail(msg);
            return Ok(response);
        }
    }
}
