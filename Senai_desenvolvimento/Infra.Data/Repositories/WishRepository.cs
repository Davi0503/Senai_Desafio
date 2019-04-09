using Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;
using WishList_Desenvolvimento_Senai.Interfaces.IRespositories;

namespace WishList_Desenvolvimento_Senai.Repositories
{
    public class WishRepository : IWishRepository
    {      

        public void CreateWish(Wish wish)
        {
            using (WishContext ctx = new WishContext())
            {
                ctx.Wish.Add(wish);
                ctx.SaveChanges();
            }
        }

        public List<Wish> WishList()
        {
            using (WishContext ctx = new WishContext())
            {
               var list =  ctx.Wish.Where(x => x.Descwish != null);

               return list.ToList();

            }
        }

        public List<Wish> WishUserList(int id )
        {
            using (WishContext ctx = new WishContext())
            {

                var list = ctx.Wish.Where(x => x.IdUsuario == id).ToList();

                return list;

            }

        }
    }
}
