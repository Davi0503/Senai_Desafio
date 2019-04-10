using Infra.Data.Domains;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;
using WishList_Desenvolvimento_Senai.Interfaces;
using WishList_Desenvolvimento_Senai.Interfaces.IRespositories;
using WishList_Desenvolvimento_Senai.Repositories;
using Infra.Data.Utils;

namespace WishList_Desenvolvimento_Senai.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _repository;
        private UtilsInfra _utils;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
            _utils = new UtilsInfra();
        }


        public void CreateUser(User user)
        {

            var userCheck = _repository.FindByEmail(user.Email);
            user.Ativo = true;            



           if (userCheck != null)
            {

                throw new Exception("Email já cadastrado");

            }

            using (MD5 md5Hash = MD5.Create())
            {

                var hashSenha = _utils.GetMd5Hash(md5Hash, user.Senha);
                user.Senha = hashSenha;
            }


            _repository.CreateUser(user);

        }


        public void EditUser(User user)
        {

            _repository.EditUser(user);

        }

        public JwtSecurityToken UserLogin(LoginDTO user)
        {


            //var userChecked = _repository.CheckLogin(user);

            var userChecked = _repository.FindByEmail(user.Email);

            using (MD5 md5Hash = MD5.Create())
            {

                bool senha = _utils.VerifyMd5Hash(md5Hash, user.Senha, userChecked.Senha);

                if (userChecked == null || senha == false)
                {
                    throw new Exception("Email ou senha inválido");
                }

            }
            


            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userChecked.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, userChecked.Id.ToString()),
                    new Claim(ClaimTypes.Name, userChecked.Nome)
                };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("WishList.WebApi.Desenvolvimento.Senai"));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "WishList.WebApi",
                    audience: "WishList.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );


            //var tokenresult = new JwtSecurityTokenHandler().WriteToken(token);

            return token;
        }



        
    }
}
