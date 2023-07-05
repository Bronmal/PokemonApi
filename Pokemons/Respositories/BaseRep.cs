using Pokemons.Context;

namespace Pokemons.Respositories;

public class BaseRep
{
    public PokemonsContext Context;
    public int UserId { get; }

    public BaseRep(int userId)
    {
        Context = new PokemonsContext();
        UserId = userId;
    }
    
}