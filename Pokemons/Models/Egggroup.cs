using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Egggroup
{
    public int Idgroup { get; set; }

    public string Egggroup1 { get; set; } = null!;

    public virtual ICollection<Pockemon> Idpockemons { get; } = new List<Pockemon>();
}
