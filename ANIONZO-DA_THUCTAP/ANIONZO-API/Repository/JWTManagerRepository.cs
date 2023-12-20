using ANIONZO_API.Models;
using ANIONZO_API.Repository.InterfaceRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ANIONZO_API.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration _iconfiguration;
        private readonly IAccountRepository _accountRepository;

        public JWTManagerRepository(IConfiguration iconfiguration, IAccountRepository accountRepository)
        {
            _iconfiguration = iconfiguration;
            _accountRepository = accountRepository;
        }
        public Tokens Authenticate(AccountModel account)
        {
            if (!_accountRepository.Login(account))
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);

            // Thêm các thông tin cần thiết vào đối tượng ClaimsIdentity
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                //new Claim(ClaimTypes.NameIdentifier, account.Id), 
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }

    }
}
