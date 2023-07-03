using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace RazorPokedex.Data;

public class Context : DbContext
{
    public DbSet<PokeDexEntry> PokeDexEntries { get; set; }

    public Context() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../RazorPokedex.Data/Pokedex.db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PokeDexEntry>().ToTable("PokeDexEntries");
    }
}