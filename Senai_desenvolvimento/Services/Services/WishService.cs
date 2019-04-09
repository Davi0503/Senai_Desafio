using Infra.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;
using WishList_Desenvolvimento_Senai.Interfaces.IRespositories;
using WishList_Desenvolvimento_Senai.Interfaces.IServices;
using WishList_Desenvolvimento_Senai.Repositories;

namespace WishList_Desenvolvimento_Senai.Services
{
    public class WishService : IWishService
    {

        private IWishRepository _repository;
        private IUserRepository _userRepository;

        public WishService(IWishRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public void CreateWish(WishCreateDTO wish)
        {
            if(string.IsNullOrEmpty(wish.descwish))
            {

                throw new Exception("Informações de cadastros inválidas");
            }

            Wish newWish = new Wish()
            {
                Descwish = wish.descwish,
                IdUsuario = wish.IdUsuario,
                Creationdt = DateTime.Now,
                Ativo = true

            };

            _repository.CreateWish(newWish);
        }

        public List<Wish> WishList()
        {

            var list = _repository.WishList();

            return list;

            
        }

        public List<Wish> WishUserList(int Id)
        {

           var user =  _userRepository.FindByid(Id);

            if(user == null){

                throw new Exception("Usuário não existe");
            }

          var list =  _repository.WishUserList(Id);

            return list;
        }
    }
}
