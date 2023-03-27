using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Growtht
{
    public int Idgrowth { get; set; }

    public string Typegrowth { get; set; } = null!;

    public virtual ICollection<Pockemon> Pockemons { get; } = new List<Pockemon>();
}
