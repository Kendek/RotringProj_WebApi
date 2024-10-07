using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RotringWebApi2._0.Entities;

public partial class RotringContext : DbContext
{
    public RotringContext()
    {
    }

    public RotringContext(DbContextOptions<RotringContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tantargyak> Tantargyaks { get; set; }

    public virtual DbSet<Tanulo> Tanulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tantargyak>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tantargyak");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Evesora)
                .HasColumnType("int(10)")
                .HasColumnName("evesora");
            entity.Property(e => e.Evfolyam)
                .HasMaxLength(20)
                .HasColumnName("evfolyam");
            entity.Property(e => e.Hetiora)
                .HasColumnType("int(8)")
                .HasColumnName("hetiora");
            entity.Property(e => e.KozSzak)
                .HasMaxLength(50)
                .HasColumnName("koz_szak");
            entity.Property(e => e.Tantargy)
                .HasMaxLength(50)
                .HasColumnName("tantargy");
        });

        modelBuilder.Entity<Tanulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tanulo");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Anyjanev)
                .HasMaxLength(50)
                .HasColumnName("anyjanev");
            entity.Property(e => e.BeirIdo)
                .HasColumnType("date")
                .HasColumnName("beirIdo");
            entity.Property(e => e.Fizika)
                .HasMaxLength(100)
                .HasColumnName("fizika");
            entity.Property(e => e.Idegennyelv)
                .HasMaxLength(100)
                .HasColumnName("idegennyelv");
            entity.Property(e => e.Irodalom)
                .HasMaxLength(100)
                .HasColumnName("irodalom");
            entity.Property(e => e.Koli)
                .HasMaxLength(50)
                .HasColumnName("koli");
            entity.Property(e => e.Kolise)
                .HasColumnType("int(1)")
                .HasColumnName("kolise");
            entity.Property(e => e.Lakcim)
                .HasMaxLength(50)
                .HasColumnName("lakcim");
            entity.Property(e => e.Matek)
                .HasMaxLength(100)
                .HasColumnName("matek");
            entity.Property(e => e.Naploszam)
                .HasColumnType("int(8)")
                .HasColumnName("naploszam");
            entity.Property(e => e.Nev)
                .HasMaxLength(50)
                .HasColumnName("nev");
            entity.Property(e => e.Nyelvtan)
                .HasMaxLength(100)
                .HasColumnName("nyelvtan");
            entity.Property(e => e.Osztaly)
                .HasMaxLength(10)
                .HasColumnName("osztaly");
            entity.Property(e => e.Szak)
                .HasMaxLength(50)
                .HasColumnName("szak");
            entity.Property(e => e.Szakma)
                .HasMaxLength(100)
                .HasColumnName("szakma");
            entity.Property(e => e.SzulHely)
                .HasMaxLength(50)
                .HasColumnName("szulHely");
            entity.Property(e => e.SzulIdo)
                .HasColumnType("date")
                .HasColumnName("szulIdo");
            entity.Property(e => e.Tesi)
                .HasMaxLength(100)
                .HasColumnName("tesi");
            entity.Property(e => e.Torzsszam)
                .HasColumnType("int(8)")
                .HasColumnName("torzsszam");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
