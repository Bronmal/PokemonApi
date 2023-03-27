using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Respositories;

namespace Pokemons.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Authorization : ControllerBase
{
    [HttpPost("auth")]
    public IResult Auth()
    {
        Stream req = Request.Body;
        Task<string> jsonText = new StreamReader(req).ReadToEndAsync();
        jsonText.Wait();
        if (jsonText.Result == "")
            return Results.Problem("Json is empty", statusCode: 406);
        
        Dictionary<string, JsonElement>? json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonText.Result);
        string? login = json?["login"].GetString();
        string? password = json?["password"].GetString();
        if (login != null && password != null)
        {
            AuthRep authRep = new AuthRep(0);
            if (authRep.Auth(login, password, out var jwtToken))
                return Results.Ok(jwtToken);
        }

        return Results.Empty;
    }
    
}