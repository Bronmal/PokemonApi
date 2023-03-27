using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Pokemons.Models;

namespace Pokemons.Respositories;

public class AuthRep: BaseRep
{
    public bool Auth(string login, string password, out string? jwtToken)
    {
        User? user = Context.Users.FirstOrDefault(user => user.Login == login && user.Password == password);
        if (user is not null)
        {
            List<Claim> claims = new() {  new Claim("user_id", user.Iduser.ToString())}; 
            JwtSecurityToken jwt = new(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            jwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            return true;
        }

        jwtToken = null;
        return false;
    }

    public AuthRep(int userId) : base(userId)
    {
    }
}