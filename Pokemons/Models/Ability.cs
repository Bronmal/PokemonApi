using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Ability
{
    public int Idabilitys { get; set; }

    public string Ability1 { get; set; } = null!;

    public virtual ICollection<Pockemon> Idpockemons { get; } = new List<Pockemon>();
}
