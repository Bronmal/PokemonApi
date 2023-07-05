using System.IO.Pipelines;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Respositories;

namespace Pokemons.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class Authorization : ControllerBase
{
    [HttpPost("auth")]
    public IActionResult Auth([FromBody] JsonElement requestBody)
    {
        Dictionary<string, JsonElement>? json = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(requestBody);
        string? login = json?["login"].GetString();
        string? password = json?["password"].GetString();
        if (login != null && password != null)
        {
            AuthRep authRep = new AuthRep(0);
            if (authRep.Auth(login, password, out var jwtToken))
                return Ok(jwtToken);
        }

        return BadRequest();
    }
    
}