using Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;

namespace WishList_Desenvolvimento_Senai.Interfaces.IServices
{
    public interface IWishService
    {

        void CreateWish(WishCreateDTO wish);

        List<Wish> WishList();

        List<Wish> WishUserList(int Id);

    }
}
