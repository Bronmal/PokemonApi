using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class Likepikemon
{
    public DateOnly Datelike { get; set; }

    public int Iduser { get; set; }

    public int Idpockemon { get; set; }

    public int IdLike { get; set; }

    public virtual Pockemon IdpockemonNavigation { get; set; } = null!;

    public virtual User IduserNavigation { get; set; } = null!;
}
