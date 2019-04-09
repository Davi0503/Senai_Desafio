using Infra.Data.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using WishList_Desenvolvimento_Senai.Domains;
using WishList_Desenvolvimento_Senai.Interfaces;
using WishList_Desenvolvimento_Senai.Services;

namespace WishList_Desenvolvimento_Senai.Controllers
{
    [Produces("application/json")]    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;

        }          

        

        [HttpPost]
        public IActionResult CreateUser(User newUser)
        {
            try
            {
                _service.CreateUser(newUser);

                return Ok("Adicionado com Sucesso!");

            }catch(Exception ex)
            {

                throw new Exception(ex.Message);
            }            

        }

        [HttpPut]
        public IActionResult EditUser(User user)
        {
            try
            {
                _service.EditUser(user);

                return Ok("Atualizado com Sucesso!");

            }catch(Exception ex)
            {
                throw new Exception("Erro ao Atualizar!");
            }

        }


    }
}
