using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Imagepokemon
{
    public int Idimage { get; set; }

    public byte[]? Image { get; set; }

    public int? Idpokemon { get; set; }

    public virtual Pockemon? IdpokemonNavigation { get; set; }
}
