using Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;

namespace WishList_Desenvolvimento_Senai.Interfaces.IRespositories
{
    public interface IUserRepository
    {
        User CheckLogin(LoginDTO user);

        User FindByEmail(string email);

        void CreateUser(User user);

        void EditUser(User user);

        User FindByid(int id);
    }
}
