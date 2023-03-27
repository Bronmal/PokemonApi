using System.IdentityModel.Tokens.Jwt;

namespace Pokemons.Controllers.Common;

public class Utils
{
    public static int GetUserIdByJwtTokenString(string token)
    {
        token = token.Remove(0, 7);
        JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
        return int.Parse(jwtToken.Claims.First(c => c.Type == "user_id").Value); 
    }
}