using System;
using Microsoft.AspNetCore.Mvc;
using Northwind.UnitOfWork;
using Northwind.WebApi.Authentication;
using Northwind.Models;

namespace Northwind.WebApi.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class TokenControler : ControllerBase
    {
        private ITokenAuthentication _tokenProvider;
        private readonly IUnitOfWork _unitOfWork;

        public TokenControler(ITokenAuthentication tokenProvider, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _tokenProvider = tokenProvider;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _unitOfWork.User.ValidaterUser(userLogin.Email, userLogin.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            return new JsonWebToken{
                Access_Token = _tokenProvider.CreateToken(user, DateTime.Now.AddHours(8)),
                Expires_int = 480, //minutes
            };

        } 
    }
}