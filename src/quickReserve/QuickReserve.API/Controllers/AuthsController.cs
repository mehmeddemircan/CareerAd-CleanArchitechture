﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReserve.Application.Features.UserOperationClaims.Commands.Create;
using QuickReserve.Application.Services.AuthService;
using QuickReserve.Domain.AuthDto;

namespace QuickReserve.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        private IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);

            if (result.Success)
            {
                // Kullanıcı başarılı bir şekilde kayıt olduktan sonra rol ekleme işlemi
                var createUserOperationClaimCommand = new CreateUserOperationClaimCommand
                {
                    UserId = registerResult.Data.Id,
                    OperationClaimId = 2
                };

                var roleResult = await Mediator.Send(createUserOperationClaimCommand);

                if (!roleResult.Success)
                {
                    return BadRequest(roleResult.Message);
                }

                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
