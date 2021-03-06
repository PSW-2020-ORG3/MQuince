﻿using Microsoft.IdentityModel.Tokens;
using MQuince.StaffManagement.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MQuince.StaffManagement.Application.Controllers.Util
{
    public class JWTRoleDecoder
    {
        public static String DecodeJWTToken(string token)
        {
            try
            {
                string secret = "SECURITASKEYINMQUINCEALLIANCETEST123 phase";
                var key = Encoding.ASCII.GetBytes(secret);
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(token, validations, out var tokenSecure);
                return claims.Claims.Where(c => c.Type == ClaimTypes.Role)
                       .Select(c => c.Value).SingleOrDefault().ToString();
            }
            catch (Exception)
            {
                throw new InvalidJWTTokenException();
            }
        }

    }
}
