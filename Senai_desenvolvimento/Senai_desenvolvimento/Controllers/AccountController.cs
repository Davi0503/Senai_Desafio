using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WishList_Desenvolvimento_Senai.Domains.DTO;
using WishList_Desenvolvimento_Senai.Interfaces;
using WishList_Desenvolvimento_Senai.Services;

namespace WishList_Desenvolvimento_Senai.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;             
        }

        [HttpPost]
        [Route("Login")]
        
        public IActionResult Login(LoginDTO user)
        {
            try
            {

                var token = _service.UserLogin(user);


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }             
        }
        
    }
}
