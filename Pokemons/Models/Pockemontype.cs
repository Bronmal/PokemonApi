using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Pockemontype
{
    public int Idtype { get; set; }

    public string Typename { get; set; } = null!;

    public virtual ICollection<Pockemon> Idpockemons { get; } = new List<Pockemon>();
}
