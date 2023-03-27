using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Pockemon
{
    public int Idpockemon { get; set; }

    public string Namepockemon { get; set; } = null!;

    public int? Idstatspockemon { get; set; }

    public int? Idgrowth { get; set; }

    public int? Idgender { get; set; }

    public int Generation { get; set; }

    public byte[]? Image { get; set; }

    public virtual Gendert? IdgenderNavigation { get; set; }

    public virtual Growtht? IdgrowthNavigation { get; set; }

    public virtual Stat? IdstatspockemonNavigation { get; set; }

    public virtual ICollection<Imagepokemon> Imagepokemons { get; } = new List<Imagepokemon>();

    public virtual ICollection<Likepikemon> Likepikemons { get; } = new List<Likepikemon>();

    public virtual ICollection<Ability> Idabilities { get; } = new List<Ability>();

    public virtual ICollection<Egggroup> Ideggs { get; } = new List<Egggroup>();

    public virtual ICollection<Pockemontype> Idtypes { get; } = new List<Pockemontype>();
}
