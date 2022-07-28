using Mercadinho.Application.Interface;
using Mercadinho.Application.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Application.App
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsuarioAplicacao(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<UsuarioToken> Login(LoginViewModel usuarioVM)
        {
            var resultado = await _signInManager.PasswordSignInAsync(usuarioVM.Email, usuarioVM.Senha, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
                return GerarToken(usuarioVM);
            else
                return null;
        }

        public async Task<string> RegistrarUsuario(UsuarioViewModel usuarioVM)
        {
            var usuario = new IdentityUser
            {
                UserName = usuarioVM.Email,
                Email = usuarioVM.Email,
                EmailConfirmed = true
            };

            if (usuarioVM.Senha != usuarioVM.ConfimaSenha)
                return "A senha está diferente da comfirmação de senha";

            var resultado = await _userManager.CreateAsync(usuario, usuarioVM.Senha);

            if (!resultado.Succeeded)
                return resultado.Errors.ToString();

            await _signInManager.SignInAsync(usuario, false);

            return "Usuário registrado";
        }

        private UsuarioToken GerarToken(LoginViewModel usuarioVM)
        {
            if (usuarioVM == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var expiracao = _configuration["TokenCofiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["TokenCofiguration:Issuer"],
                Audience = _configuration["TokenCofiguration:Audience"],
                Expires = expiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);

            return new UsuarioToken
            {
                Autenticado = true,
                Token = tokenHandler.WriteToken(token),
                Expiracao = expiration,
                Mensagem = "Token Ok"
            };
        }

    }
}
