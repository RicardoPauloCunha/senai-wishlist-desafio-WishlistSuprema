using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using WebApi.WishList.Interfaces;
using WebApi.WishList.Repositorios;
using Microsoft.AspNetCore.Authorization;
using WebApi.WishList.Domains;
using WebApi.WishList.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.WishList.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository Repositorio;

        public UsuarioController()
        {
            Repositorio = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize]
        [Route("desejos")]
        public IActionResult Listar()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(Repositorio.ListarDesejos(usuarioId));
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("listar/novos/{ehAtual}")]
        [Authorize]
        public IActionResult ListarNovos(bool ehAtual)
        {
            try {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                Usuario usuario = Repositorio.ListarDesejos(usuarioId);

                switch (ehAtual)
                {
                    case false:
                        return Ok(usuario.Desejos.OrderBy(x => x.DataCriacao));

                    default:
                        return Ok(usuario.Desejos.OrderByDescending(x => x.DataCriacao));
                }
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("cadastro")]
        public IActionResult Cadastrar(UsuarioViewModel usuario) {
            try
            {
                Repositorio.Cadastrar(usuario);

                return Ok($"Usuario {usuario.Nome} cadastrado com sucesso!");
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel user) {
            try
            {
                Usuario usuario = Repositorio.Login(user.Email, user.Senha);

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Email)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Autenticação-Wishlist"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "Wishlist.WebApi",
                    audience: "Wishlist.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credenciais
                );

                return Ok(new {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}