using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Domains.DTO;
using WishList_Desenvolvimento_Senai.Interfaces.IServices;
using WishList_Desenvolvimento_Senai.Services;

namespace WishList_Desenvolvimento_Senai.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : ControllerBase
    {
        private IWishService _service;

        public WishController(IWishService service)
        {
            _service = service;
        }


        [HttpGet]
        [Authorize]
        public IActionResult WishList()
        {
            return Ok(_service.WishList());
        }


        //[HttpGet]
        //public IActionResult WishUserList(int ID)
        //{

        //    return Ok(_service.WishUserList(ID));
        //}


        [HttpPost]
        [Authorize]
        public IActionResult CreateWish(WishCreateDTO wish)
        {
            try
            {
                WishCreateDTO newWish = new WishCreateDTO();
                try
                {
                    newWish.IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                }catch(Exception ex)
                {
                    throw new Exception("Erro no carregamento, usuário não encontrado");
                }
                newWish.descwish = wish.descwish;
                _service.CreateWish(newWish);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }            

            return Ok();
        }
    }
}
