namespace Pokemons.Respositories.Common;

public class PokemonJsonStruct
{
    public string Name { get; set; }
    public string Growtht { get; set; }
    public string Gender { get; set; }
    public int Generation { get; set; }
    public byte[] Image { get; set; }
}

public class PokemonTypeJsonStruct
{
    public string Name { get; set; }
}