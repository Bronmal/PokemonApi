using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pokemons.Models;

namespace Pokemons.Context;

public partial class PokemonsContext : DbContext
{
    public PokemonsContext()
    {
    }

    public PokemonsContext(DbContextOptions<PokemonsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ability> Abilities { get; set; }

    public virtual DbSet<Egggroup> Egggroups { get; set; }

    public virtual DbSet<Gendert> Genderts { get; set; }

    public virtual DbSet<Growtht> Growthts { get; set; }

    public virtual DbSet<Imagepokemon> Imagepokemons { get; set; }

    public virtual DbSet<Likepikemon> Likepikemons { get; set; }

    public virtual DbSet<Pockemon> Pockemons { get; set; }

    public virtual DbSet<Pockemontype> Pockemontypes { get; set; }

    public virtual DbSet<Stat> Stats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Pokemons;Username=postgres;password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ability>(entity =>
        {
            entity.HasKey(e => e.Idabilitys).HasName("abilities_pkey");

            entity.ToTable("abilities");

            entity.Property(e => e.Idabilitys).HasColumnName("idabilitys");
            entity.Property(e => e.Ability1)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ability");

            entity.HasMany(d => d.Idpockemons).WithMany(p => p.Idabilities)
                .UsingEntity<Dictionary<string, object>>(
                    "Abilityespockemon",
                    r => r.HasOne<Pockemon>().WithMany()
                        .HasForeignKey("Idpockemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("abilityespockemon_idpockemon_fkey"),
                    l => l.HasOne<Ability>().WithMany()
                        .HasForeignKey("Idability")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("abilityespockemon_idability_fkey"),
                    j =>
                    {
                        j.HasKey("Idability", "Idpockemon").HasName("abilityespockemon_pkey");
                        j.ToTable("abilityespockemon");
                        j.IndexerProperty<int>("Idability").HasColumnName("idability");
                        j.IndexerProperty<int>("Idpockemon").HasColumnName("idpockemon");
                    });
        });

        modelBuilder.Entity<Egggroup>(entity =>
        {
            entity.HasKey(e => e.Idgroup).HasName("egggroups_pkey");

            entity.ToTable("egggroups");

            entity.Property(e => e.Idgroup).HasColumnName("idgroup");
            entity.Property(e => e.Egggroup1)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("egggroup");

            entity.HasMany(d => d.Idpockemons).WithMany(p => p.Ideggs)
                .UsingEntity<Dictionary<string, object>>(
                    "Pockemonsegg",
                    r => r.HasOne<Pockemon>().WithMany()
                        .HasForeignKey("Idpockemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pockemonseggs_idpockemon_fkey"),
                    l => l.HasOne<Egggroup>().WithMany()
                        .HasForeignKey("Idegg")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pockemonseggs_idegg_fkey"),
                    j =>
                    {
                        j.HasKey("Idegg", "Idpockemon").HasName("pockemonseggs_pkey");
                        j.ToTable("pockemonseggs");
                        j.IndexerProperty<int>("Idegg").HasColumnName("idegg");
                        j.IndexerProperty<int>("Idpockemon").HasColumnName("idpockemon");
                    });
        });

        modelBuilder.Entity<Gendert>(entity =>
        {
            entity.HasKey(e => e.Idgender).HasName("gendert_pkey");

            entity.ToTable("gendert");

            entity.Property(e => e.Idgender).HasColumnName("idgender");
            entity.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Growtht>(entity =>
        {
            entity.HasKey(e => e.Idgrowth).HasName("growtht_pkey");

            entity.ToTable("growtht");

            entity.Property(e => e.Idgrowth).HasColumnName("idgrowth");
            entity.Property(e => e.Typegrowth)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("typegrowth");
        });

        modelBuilder.Entity<Imagepokemon>(entity =>
        {
            entity.HasKey(e => e.Idimage).HasName("imagepokemons_pkey");

            entity.ToTable("imagepokemons");

            entity.Property(e => e.Idimage).HasColumnName("idimage");
            entity.Property(e => e.Idpokemon).HasColumnName("idpokemon");
            entity.Property(e => e.Image).HasColumnName("image");

            entity.HasOne(d => d.IdpokemonNavigation).WithMany(p => p.Imagepokemons)
                .HasForeignKey(d => d.Idpokemon)
                .HasConstraintName("imagepokemons_idpokemon_fkey");
        });

        modelBuilder.Entity<Likepikemon>(entity =>
        {
            entity.HasKey(e => e.IdLike).HasName("likepikemon_pk");

            entity.ToTable("likepikemon");

            entity.Property(e => e.IdLike)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id_like");
            entity.Property(e => e.Datelike).HasColumnName("datelike");
            entity.Property(e => e.Idpockemon).HasColumnName("idpockemon");
            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.HasOne(d => d.IdpockemonNavigation).WithMany(p => p.Likepikemons)
                .HasForeignKey(d => d.Idpockemon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("likepikemon_idpockemon_fkey");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Likepikemons)
                .HasForeignKey(d => d.Iduser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("likepikemon_iduser_fkey");
        });

        modelBuilder.Entity<Pockemon>(entity =>
        {
            entity.HasKey(e => e.Idpockemon).HasName("pockemons_pkey");

            entity.ToTable("pockemons");

            entity.Property(e => e.Idpockemon).HasColumnName("idpockemon");
            entity.Property(e => e.Generation).HasColumnName("generation");
            entity.Property(e => e.Idgender).HasColumnName("idgender");
            entity.Property(e => e.Idgrowth).HasColumnName("idgrowth");
            entity.Property(e => e.Idstatspockemon).HasColumnName("idstatspockemon");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Namepockemon)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("namepockemon");

            entity.HasOne(d => d.IdgenderNavigation).WithMany(p => p.Pockemons)
                .HasForeignKey(d => d.Idgender)
                .HasConstraintName("pockemons_idgender_fkey");

            entity.HasOne(d => d.IdgrowthNavigation).WithMany(p => p.Pockemons)
                .HasForeignKey(d => d.Idgrowth)
                .HasConstraintName("pockemons_idgrowth_fkey");

            entity.HasOne(d => d.IdstatspockemonNavigation).WithMany(p => p.Pockemons)
                .HasForeignKey(d => d.Idstatspockemon)
                .HasConstraintName("pockemons_idstatspockemon_fkey");
        });

        modelBuilder.Entity<Pockemontype>(entity =>
        {
            entity.HasKey(e => e.Idtype).HasName("pockemontypes_pkey");

            entity.ToTable("pockemontypes");

            entity.Property(e => e.Idtype).HasColumnName("idtype");
            entity.Property(e => e.Typename)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("typename");

            entity.HasMany(d => d.Idpockemons).WithMany(p => p.Idtypes)
                .UsingEntity<Dictionary<string, object>>(
                    "Typespockemon",
                    r => r.HasOne<Pockemon>().WithMany()
                        .HasForeignKey("Idpockemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("typespockemon_idpockemon_fkey"),
                    l => l.HasOne<Pockemontype>().WithMany()
                        .HasForeignKey("Idtype")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("typespockemon_idtype_fkey"),
                    j =>
                    {
                        j.HasKey("Idtype", "Idpockemon").HasName("typespockemon_pkey");
                        j.ToTable("typespockemon");
                        j.IndexerProperty<int>("Idtype").HasColumnName("idtype");
                        j.IndexerProperty<int>("Idpockemon").HasColumnName("idpockemon");
                    });
        });

        modelBuilder.Entity<Stat>(entity =>
        {
            entity.HasKey(e => e.Idstats).HasName("stats_pkey");

            entity.ToTable("stats");

            entity.Property(e => e.Idstats).HasColumnName("idstats");
            entity.Property(e => e.Attack).HasColumnName("attack");
            entity.Property(e => e.Chancecatch).HasColumnName("chancecatch");
            entity.Property(e => e.Eggcycle).HasColumnName("eggcycle");
            entity.Property(e => e.Expirients).HasColumnName("expirients");
            entity.Property(e => e.Health).HasColumnName("health");
            entity.Property(e => e.Heights)
                .HasPrecision(4, 1)
                .HasColumnName("heights");
            entity.Property(e => e.Protect).HasColumnName("protect");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Weights)
                .HasPrecision(4, 1)
                .HasColumnName("weights");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Nameuser)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("nameuser");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
