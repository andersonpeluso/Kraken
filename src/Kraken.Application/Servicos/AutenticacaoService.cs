using Kraken.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Kraken.Application.Servicos
{
    public class AutenticacaoService
    {
        private readonly IConfiguration _configuracao;

        public AutenticacaoService(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public async Task<ResultadoAPI<object>> AutenticarAsync(string login, string chave)
        {
            ResultadoAPI<object> resultado = null;

            try
            {
                if (!string.IsNullOrEmpty(login) && login == "admin" && !string.IsNullOrEmpty(chave) && chave == "123456")
                    resultado = new ResultadoAPI<object>(HttpStatusCode.OK, GerarToken());
                else
                    resultado = new ResultadoAPI<object>(HttpStatusCode.NotFound, mensagem: "Usuário não encontrada!");
            }
            catch (Exception ex)
            {
                resultado = new ResultadoAPI<object>(System.Net.HttpStatusCode.InternalServerError, mensagem: ex.Message);
            }
            return resultado;
        }

        private AutenticacaoModel GerarToken()
        {
            // Cria os "claims" (informações adicionais no token)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Obtem os valores de configuração
            var secredo = _configuracao["ConfiguracaoToken:Secredo"];
            var emissor = _configuracao["ConfiguracaoToken:Emissor"];
            var validoEm = _configuracao["ConfiguracaoToken:ValidoEm"];
            var expiracaoHoras = int.Parse(_configuracao["ConfiguracaoToken:ExpiracaoHoras"]);

            // Configura a chave de assinatura
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secredo));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Configura o token JWT
            var token = new JwtSecurityToken(
                issuer: emissor,
                audience: validoEm,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expiracaoHoras),
                signingCredentials: creds
            );

            // return new JwtSecurityTokenHandler().WriteToken(token);

            var resultado = new AutenticacaoModel
            {
                Token = $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}",
                ExpiraEm = DateTime.UtcNow.AddHours(1)
            };
            return resultado;
        }
    }
}