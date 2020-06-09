using System;
using Northwind.Models;
using Microsoft.IdentityModel.Tokens;

namespace Northwind.WebApi.Authentication
{
    public interface ITokenAuthentication
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();        
    }
}