using KGGames.CORE.JWT.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace KGGames.CORE.JWT
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, Guid Id)
        {
            IEnumerable<Claim> claims = new Claim[] {
                new Claim("Id",userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Role,userAccounts.Role.ToString()),
                new Claim(ClaimTypes.Email,userAccounts.EmailId),
                //new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
                };

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            try
            {
                var UserToken = new UserTokens();
                if (model == null) throw new ArgumentNullException(nameof(model));
                //Get secret key
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);
                Guid Id = Guid.Empty;
                DateTime expireTime = DateTime.UtcNow.AddDays(1);
                UserToken.Validaty = expireTime.TimeOfDay;
                //var JWToken = new JwtSecurityToken(jwtSettings.ValidIssuer,jwtSettings.ValidAudience,GetClaims(model,out Id),new DateTimeOffset(DateTime.Now).DateTime,new DateTimeOffset(expireTime).DateTime,new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256));
                //If we want to determine ValidAudience and ValidIssuer in Token, we must define ValidIssuer and ValidAudience properties are true in appsettings.json file.
                var JWToken = new JwtSecurityToken("", "", GetClaims(model, out Id), new DateTimeOffset(DateTime.Now).DateTime, new DateTimeOffset(expireTime).DateTime, new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                UserToken.Id = model.Id;
                UserToken.GuidId = Id;
                return UserToken;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
