using System.Runtime.InteropServices.JavaScript;
using Pokemons.Models;
using Pokemons.Respositories.Common;
using PokemonsModel = Pokemons.Models.Pockemon;

namespace Pokemons.Respositories;

public class PokemonsRep: BaseRep
{
    public PokemonsRep(int userId) : base(userId)
    {
    }
    public List<PokemonJsonStruct> GetAllPokemons()
    {
        List<PokemonJsonStruct> result = new List<PokemonJsonStruct>();
        foreach (PokemonsModel pockemon in Context.Pockemons.ToList())
        {
            PokemonJsonStruct pokemonJ = new PokemonJsonStruct()
            {
                Name = pockemon.Namepockemon,
                Gender = Context.Genderts.FirstOrDefault(x => x.Idgender == pockemon.Idgender)?.Gender!,
                Generation = pockemon.Generation,
                Growtht = Context.Growthts.FirstOrDefault(x => x.Idgrowth == pockemon.Idgrowth)?.Typegrowth!,
                Image = Context.Imagepokemons.FirstOrDefault(x => x.Idpokemon == pockemon.Idpockemon)?.Image!
            };
            result.Add(pokemonJ);
        }

        return result;
    }

    public List<PokemonTypeJsonStruct> GetAllTypesOfPockemon()
    {
        List<PokemonTypeJsonStruct> result = new List<PokemonTypeJsonStruct>();
        foreach (Pockemontype pockemontype in Context.Pockemontypes.ToList())
        {
            PokemonTypeJsonStruct type = new PokemonTypeJsonStruct()
            {
                Name = pockemontype.Typename
            };
            result.Add(type);
        }

        return result;
    }

    public bool Like(int idPokemon)
    {
        Likepikemon like = new Likepikemon()
        {
            Datelike = DateOnly.FromDateTime(DateTime.Now),
            Idpockemon = idPokemon,
            Iduser = UserId
        };
        Context.Likepikemons.Add(like);
        Context.SaveChanges();
        return true;
    }

    public PokemonJsonStruct GetMostLikedPockemon(string time)
    {
        int? idPokemon = null;
        List<Likepikemon>? day = null;
        Dictionary<int, IGrouping<int, Likepikemon>>? group = null;
        List<IEnumerable<Likepikemon>>? a = null;
        switch (time)
        {
            case "day":
                day = Context.Likepikemons.Where(x => x.Datelike == DateOnly.FromDateTime(DateTime.Now)).ToList();
                a = day.GroupBy(x => x.Idpockemon).OrderBy(x => x.ToList().Count).Select(x => x.Select(y => y))
                    .ToList();
                idPokemon = a[^1].ToList()[0].Idpockemon;
                break;
            case "month":
                day = Context.Likepikemons.Where(x => x.Datelike.AddMonths(1) <= DateOnly.FromDateTime(DateTime.Now)).ToList();
                a = day.GroupBy(x => x.Idpockemon).OrderBy(x => x.ToList().Count).Select(x => x.Select(y => y))
                    .ToList();
                idPokemon = a[^1].ToList()[0].Idpockemon;
                break;
            case "year":
                day = Context.Likepikemons.Where(x => x.Datelike.AddYears(1) <= DateOnly.FromDateTime(DateTime.Now)).ToList();
                a = day.GroupBy(x => x.Idpockemon).OrderBy(x => x.ToList().Count).Select(x => x.Select(y => y))
                    .ToList();
                idPokemon = a[^1].ToList()[0].Idpockemon;
                break;
        }

        Pockemon pokemonDb = Context.Pockemons.FirstOrDefault(x => x.Idpockemon == idPokemon)!;
        PokemonJsonStruct result = new PokemonJsonStruct()
        {
            Name = pokemonDb.Namepockemon,
            Gender = Context.Genderts.FirstOrDefault(x => x.Idgender == pokemonDb.Idgender)?.Gender!,
            Generation = pokemonDb.Generation,
            Growtht = Context.Growthts.FirstOrDefault(x => x.Idgrowth == pokemonDb.Idgrowth)?.Typegrowth!,
            Image = Context.Imagepokemons.FirstOrDefault(x => x.Idpokemon == pokemonDb.Idpockemon)?.Image!
        };
        return result;
        
    }
}