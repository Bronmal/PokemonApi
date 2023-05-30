using Pokemons.Context;

namespace Pokemons.Respositories;

public class BaseRep
{
    public NeondbContext Context;
    public int UserId { get; }

    public BaseRep(int userId)
    {
        Context = new NeondbContext();
        UserId = userId;
    }
    
}