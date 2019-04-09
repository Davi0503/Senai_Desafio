using Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;

namespace WishList_Desenvolvimento_Senai.Interfaces
{
    public interface IUserService
    {

        JwtSecurityToken UserLogin(LoginDTO user);

        void CreateUser(User user);

        void EditUser(User user);

    }
}
