namespace Pokemons.Respositories.Common;

public class PokemonJsonStruct
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Growtht { get; set; }
    public string Gender { get; set; }
    public int Generation { get; set; }
}

public class PokemonsAbilityJsonStruct
{
    public string Name { get; set; }
    public string Ability { get; set; }
}

public class StatJsonStruct
{
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public int? EggCycle { get; set; }
    public int? ChanceCatch { get; set; }
    public int? Experients { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Protect { get; set; }
    public int Speed { get; set; }
}

public class PokemonTypeJsonStruct
{
    public string Name { get; set; }
}