using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace USCivilWarBattles_DB.Models
{
    public partial class USCivilWarBattlesContext : DbContext
    {
        public USCivilWarBattlesContext()
        {
        }

        public USCivilWarBattlesContext(DbContextOptions<USCivilWarBattlesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Battle> Battles { get; set; }
        public virtual DbSet<Commander> Commanders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=USCivilWarBattles;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Battle>(entity =>
            {
                entity.HasIndex(e => e.BattleCode, "UQ__Battles__2BF0D252075BE7AF")
                    .IsUnique();

                entity.Property(e => e.BattleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BattleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Theatre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Victor)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Commander>(entity =>
            {
                entity.Property(e => e.Army)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CommanderName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Commander");

                entity.HasOne(d => d.Battle)
                    .WithMany(p => p.Commanders)
                    .HasForeignKey(d => d.BattleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commander__Battl__6FE99F9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
