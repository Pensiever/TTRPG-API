using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model_BLL.Models;
using Model_BLL.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TtrpgApi.Models;
using TtrpgApi.Services.Interfaces;

namespace TtrpgApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;
        private IQuesterService _questerService;

        public TokenService(IOptions<AppSettings> app, IQuesterService questerService)
        {
            _appSettings = app.Value;
            _questerService = questerService;
        }

        public ConnectedQuester Authenticate(string username, string password)
        {
            Quester quester;
            if (_questerService.CheckQuester(new Quester { Username = username, Password = password }) == true)
            {
                quester = _questerService.GetByUsername(username);
            }
            else return null;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, quester.Id.ToString()),
                    new Claim(ClaimTypes.Surname, quester.Username),
                    new Claim(ClaimTypes.Role, quester.IsAdmin ? "Admin" : "Quester")
                }),
                Issuer = _appSettings.Issuer,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new ConnectedQuester
            {
                Id = quester.Id,
                Username = quester.Username,
                Email = quester.Email,
                BirthDate = quester.BirthDate,
                IsActive = quester.IsActive,
                IsAdmin = quester.IsAdmin,
                IsBanned = quester.IsBanned,
                Strikes = quester.Strikes,
                BackgroundId = quester.BackgroundId,
                Bio = quester.Bio,
                OnlinePlay = quester.OnlinePlay,
                OfflinePlay = quester.OfflinePlay,
                PostalCode = quester.PostalCode,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
