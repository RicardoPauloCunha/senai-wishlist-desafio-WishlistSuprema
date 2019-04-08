using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.Wishlist.Domains;
using Senai.WebApi.Wishlist.Interfaces;
using Senai.WebApi.Wishlist.Repositorios;

namespace Senai.WebApi.Wishlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DesejoController : ControllerBase
    {
        private readonly IDesejoRepository Repositorios;

        public DesejoController() {
            Repositorios = new DesejoRepository();
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try {
                return Ok(Repositorios.Listar());
            }catch(Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("cadastrar")]
        public IActionResult Cadastrar(Desejo desejo) {
            try {
                desejo.Usuarioid = Convert.ToInt32(
                    HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value
                );
                Repositorios.Cadastrar(desejo);
                return Ok();
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

    }
}