using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.WishList.Domains;
using WebApi.WishList.Interfaces;
using WebApi.WishList.Repositorios;

namespace WebApi.WishList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DesejoController : ControllerBase
    {
        private readonly IDesejoRepository Repositorios;

        public DesejoController()
        {
            Repositorios = new DesejoRepository();
        }

        [HttpGet]
        [Route("listar")]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(Repositorios.Listar());
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("cadastro")]
        [Authorize]
        public IActionResult Cadastrar(DesejoViewModel desejo) {
            try
            {
                desejo.Usuarioid = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                Repositorios.Cadastrar(desejo);

                return Ok($"Desejo {desejo.Nome} cadastrado com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}