using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Stat
{
    public int Idstats { get; set; }

    public decimal Heights { get; set; }

    public decimal Weights { get; set; }

    public int? Eggcycle { get; set; }

    public int? Chancecatch { get; set; }

    public int? Expirients { get; set; }

    public int Health { get; set; }

    public int Attack { get; set; }

    public int Protect { get; set; }

    public int Speed { get; set; }

    public virtual ICollection<Pockemon> Pockemons { get; } = new List<Pockemon>();
}
