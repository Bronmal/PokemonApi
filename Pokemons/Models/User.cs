using System;
using System.Collections.Generic;

namespace Pokemons.Models;

public partial class User
{
    public int Iduser { get; set; }

    public string Nameuser { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Likepikemon> Likepikemons { get; } = new List<Likepikemon>();
}
