using Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains.DTO;
using WishList_Desenvolvimento_Senai.Interfaces.IRespositories;

namespace WishList_Desenvolvimento_Senai.Repositories
{
    public class UserRepository : IUserRepository
    {
              

        public User CheckLogin (LoginDTO user)
        {
            using (WishContext ctx = new WishContext())
            {

                User userValidate = ctx.Usuarios.Where(x => x.Email == user.Email && x.Senha == user.Senha).FirstOrDefault();

                return userValidate;

            }
            
        }

        public void CreateUser(User user)
        {
            using (WishContext ctx = new WishContext())
            {
                ctx.Usuarios.Add(user);
                ctx.SaveChanges();
            }
        }

        public void EditUser(User user)
        {
            using (WishContext ctx = new WishContext())
            {
                var userSearch = ctx.Usuarios.Where(x => x.Id == user.Id).FirstOrDefault();

                userSearch.Email = user.Email;
                userSearch.Nome = user.Nome;
                userSearch.Senha = user.Senha;

                ctx.Usuarios.Update(userSearch);
                ctx.SaveChanges();


            }
        }

        public User FindByEmail(string email)
        {
            using (WishContext ctx = new WishContext())
            {
                var userByEmail = ctx.Usuarios.Where(x => x.Email == email).FirstOrDefault();

                return userByEmail;
            }
        }

        public User FindByid(int id)
        {
            using (WishContext ctx = new WishContext())
            {
                var user = ctx.Usuarios.Where(x => x.Id == id).FirstOrDefault();

                return user;             
                
            }
        }
    }
}
