using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Senai.WebApi.Wishlist.Interfaces;
using Senai.WebApi.Wishlist.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Senai.WebApi.Wishlist.Domains;
using Senai.WebApi.Wishlist.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;

namespace Senai.WebApi.Wishlist.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository Repositorio;

        public UsuarioController() {
            Repositorio = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize]
        [Route("desejos")]
        public IActionResult Listar()
        {
            try {
                int ID = Convert.ToInt32(
                    HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value
                );
                return Ok(Repositorio.ListarDesejos(ID));
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        [Route("listar{ordem}")]
        [Authorize]
        public IActionResult Listar(string ordem) {
            try {
                int ID = Convert.ToInt32(
                    HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value
                );

                Usuario usuario = Repositorio.ListarDesejos(ID);
                switch (ordem) {
                    case "asc":
                        return Ok(usuario.Desejo.OrderBy(i => i.Datacriacao));
                    default:
                        return Ok(usuario.Desejo.OrderByDescending(i => i.Datacriacao));
                }
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
        [Route("cadastro")]
        public IActionResult Cadastrar(Usuario usuario) {
            try {
                Repositorio.Cadastrar(usuario);
                return Ok($"Usuario {usuario.Nome} cadastrado com sucesso!");
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel user) {
            try {
                Usuario usuario = Repositorio.Login(user.Email, user.Senha);

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Jti,usuario.Usuarioid.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Email)
                };
                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Autenticação-Wishlist"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
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
            catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
    }
}