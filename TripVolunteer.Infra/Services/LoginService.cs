using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class LoginService : ILoginService

    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public void CreateLogin(Login login)
        {
            _loginRepository.CreateLogin(login);
        }

        public void DeleteLogin(int id)
        {
            _loginRepository.DeleteLogin(id);
        }

        public List<Login> GetAllLogin()
        {
            return _loginRepository.GetAllLogin();
        }

        public Login GetLoginById(int id)
        {
            return _loginRepository.GetLoginById(id);
        }

        public void UpdateLogin(Login login)
        {
            _loginRepository.UpdateLogin(login);
        }
        public string Auth(Login login)
        {

            var result = _loginRepository.Auth(login);

            if (result == null)
            {
                return null;
            }
            else
            {
                var secertKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKeyDana@345"));
                var signCredential = new SigningCredentials(secertKey, SecurityAlgorithms.Aes128CbcHmacSha256);
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name , result.Username),
                    new Claim("RoleId" , result.Roleid.ToString()),
                    new Claim("userId", result.Userid.ToString())
                };
                var tokenOption = new JwtSecurityToken(claims: claims,
                                                        expires: DateTime.Now.AddHours(24),
                                                        signingCredentials: signCredential);

                var tokenAsString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return tokenAsString;

            }

        }
    }
}
