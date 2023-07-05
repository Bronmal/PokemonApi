using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Controllers.Common;
using Pokemons.Respositories;

namespace Pokemons.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Pokemons : ControllerBase
{
    [HttpGet("get_pokemons")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetPokemon()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        string json = JsonSerializer.Serialize(pokemonsRep.GetAllPokemons());
        return Ok(json);
    }
    
    [HttpGet("get_types_of_pokemon")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetTypeOfPokemon()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Ok(JsonSerializer.Serialize(pokemonsRep.GetAllTypesOfPockemon()));
    }
    
    [HttpGet("like_pockemon/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult LikePokemon(string id)
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return int.TryParse(id, out int numId) ? Ok(pokemonsRep.Like(numId)) : Problem();
    }
    
    [HttpPost("get_most_liked_pockemon")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetLikePokemon([FromBody] JsonElement requestBody)
    {
        Dictionary<string, JsonElement>? json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(requestBody);
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Ok(JsonSerializer.Serialize(pokemonsRep.GetMostLikedPockemon(json["time"].GetString())));
    }
        
    [HttpGet("get_stats")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetStats()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Ok(JsonSerializer.Serialize(pokemonsRep.GetStats()));
    }
    
    [HttpGet("get_abilities")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetAbilities()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Ok(JsonSerializer.Serialize(pokemonsRep.GetAbilities()));
    }
    
    [HttpPost("get_image")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetAbilitie([FromBody] Dictionary<string, JsonElement> a)
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Ok(JsonSerializer.Serialize(pokemonsRep.GetImages(a["name"].GetString())));
    }
    
}