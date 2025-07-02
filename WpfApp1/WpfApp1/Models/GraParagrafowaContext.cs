using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Models;

public partial class GraParagrafowaContext : DbContext
{
    public GraParagrafowaContext()
    {
    }

    public GraParagrafowaContext(DbContextOptions<GraParagrafowaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kampanium> Kampania { get; set; }

    public virtual DbSet<Paragraf> Paragrafs { get; set; }

    public virtual DbSet<ParagrafPolaczenie> ParagrafPolaczenies { get; set; }

    public virtual DbSet<Postac> Postacs { get; set; }

    public virtual DbSet<Przedmiot> Przedmiots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Komputer-KJ\\MSSQLSERVER01;Database=GraParagrafowa;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kampanium>(entity =>
        {
            entity.HasKey(e => e.IdKampanii).HasName("PK__kampania__D82A8CA91FDD6CF3");

            entity.ToTable("kampania");

            entity.Property(e => e.IdKampanii).HasColumnName("id_kampanii");
            entity.Property(e => e.Opis).HasColumnName("opis");
            entity.Property(e => e.Tytul)
                .HasMaxLength(255)
                .HasColumnName("tytul");
        });

        modelBuilder.Entity<Paragraf>(entity =>
        {
            entity.HasKey(e => e.Numer).HasName("PK__paragraf__AF86E6531942EAC7");

            entity.ToTable("paragraf");

            entity.Property(e => e.Numer)
                .ValueGeneratedNever()
                .HasColumnName("numer");
            entity.Property(e => e.Dzialanie).HasColumnName("dzialanie");
            entity.Property(e => e.IdKampanii).HasColumnName("id_kampanii");
            entity.Property(e => e.Streszczenie).HasColumnName("streszczenie");
            entity.Property(e => e.Tresc).HasColumnName("tresc");

            entity.HasOne(d => d.IdKampaniiNavigation).WithMany(p => p.Paragrafs)
                .HasForeignKey(d => d.IdKampanii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_paragraf_kampania");
        });

        modelBuilder.Entity<ParagrafPolaczenie>(entity =>
        {
            entity.HasKey(e => new { e.IdZrodla, e.IdCelu }).HasName("PK__paragraf__910C317C2C694EAC");

            entity.ToTable("paragraf_polaczenie");

            entity.Property(e => e.IdZrodla).HasColumnName("id_zrodla");
            entity.Property(e => e.IdCelu).HasColumnName("id_celu");
            entity.Property(e => e.OpisAkcji)
                .HasMaxLength(255)
                .HasColumnName("opis_akcji");

            entity.HasOne(d => d.IdCeluNavigation).WithMany(p => p.ParagrafPolaczenieIdCeluNavigations)
                .HasForeignKey(d => d.IdCelu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cel");

            entity.HasOne(d => d.IdZrodlaNavigation).WithMany(p => p.ParagrafPolaczenieIdZrodlaNavigations)
                .HasForeignKey(d => d.IdZrodla)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_zrodlo");
        });

        modelBuilder.Entity<Postac>(entity =>
        {
            entity.HasKey(e => e.IdPostaci).HasName("PK__postac__20DB4519A799F9A5");

            entity.ToTable("postac");

            entity.Property(e => e.IdPostaci).HasColumnName("id_postaci");
            entity.Property(e => e.IdKampanii).HasColumnName("id_kampanii");
            entity.Property(e => e.Imie)
                .HasMaxLength(100)
                .HasColumnName("imie");
            entity.Property(e => e.Statystyki).HasColumnName("statystyki");

            entity.HasOne(d => d.IdKampaniiNavigation).WithMany(p => p.Postacs)
                .HasForeignKey(d => d.IdKampanii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_postac_kampania");
        });

        modelBuilder.Entity<Przedmiot>(entity =>
        {
            entity.HasKey(e => e.IdPrzedmiotu).HasName("PK__przedmio__E056DA0A4B345CC6");

            entity.ToTable("przedmiot");

            entity.Property(e => e.IdPrzedmiotu).HasColumnName("id_przedmiotu");
            entity.Property(e => e.IdKampanii).HasColumnName("id_kampanii");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(100)
                .HasColumnName("nazwa");
            entity.Property(e => e.Opis).HasColumnName("opis");
            entity.Property(e => e.Statystyki).HasColumnName("statystyki");
            entity.Property(e => e.Typ)
                .HasMaxLength(50)
                .HasColumnName("typ");

            entity.HasOne(d => d.IdKampaniiNavigation).WithMany(p => p.Przedmiots)
                .HasForeignKey(d => d.IdKampanii)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_przedmiot_kampania");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
