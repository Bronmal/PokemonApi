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
    public IResult GetPokemon()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetAllPokemons());
    }
    
    [HttpGet("get_types_of_pokemon")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult GetTypeOfPokemon()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetAllTypesOfPockemon());
    }
    
    [HttpGet("like_pockemon/{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult LikePokemon(string id)
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return int.TryParse(id, out int numId) ? Results.Ok(pokemonsRep.Like(numId)) : Results.Problem();
    }
    
    [HttpPost("get_most_liked_pockemon")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult GetLikePokemon([FromBody] JsonElement requestBody)
    {
        Dictionary<string, JsonElement>? json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(requestBody);
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetMostLikedPockemon(json["time"].GetString()));
    }
        
    [HttpGet("get_stats")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult GetStats()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetStats());
    }
    
    [HttpGet("get_abilities")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult GetAbilities()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetAbilities());
    }
    
    [HttpGet("get_images")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult GetAbilitie()
    {
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetImages());
    }
    
}