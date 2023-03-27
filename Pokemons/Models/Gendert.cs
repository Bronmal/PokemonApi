using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Gendert
{
    public int Idgender { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<Pockemon> Pockemons { get; } = new List<Pockemon>();
}
