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
        return Results.Json(pokemonsRep.GetAllPokemons().GetRange(0, 20));
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
    
    [HttpGet("get_most_liked_pockemon")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IResult LikePokemon()
    {
        Stream req = Request.Body;
        Task<string> jsonText = new StreamReader(req).ReadToEndAsync();
        jsonText.Wait();
        if (jsonText.Result == "")
            return Results.Problem("Json is empty", statusCode: 406);
        
        Dictionary<string, JsonElement>? json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonText.Result);
        int userId = Utils.GetUserIdByJwtTokenString(Request.Headers["Authorization"]!);
        PokemonsRep pokemonsRep = new PokemonsRep(userId);
        return Results.Json(pokemonsRep.GetMostLikedPockemon(json["time"].GetString()));
    }
    
}