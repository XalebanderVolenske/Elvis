namespace Elvis.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ElvisModel : DbContext
    {
        public ElvisModel()
            : base("name=ElvisModel")
        {
        }

        public virtual DbSet<Communities> Communities { get; set; }
        public virtual DbSet<Constituencies> Constituencies { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Election_Parties> Election_Parties { get; set; }
        public virtual DbSet<Elections> Elections { get; set; }
        public virtual DbSet<Parties> Parties { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Vote_Data> Vote_Data { get; set; }
        public virtual DbSet<Electorial_Register> Electorial_Register { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Communities>()
                .HasMany(e => e.Electorial_Register)
                .WithRequired(e => e.Communities)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Communities>()
                .HasOptional(e => e.Vote_Data)
                .WithRequired(e => e.Communities);

            modelBuilder.Entity<Constituencies>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.Constituencies)
                .HasForeignKey(e => e.regional_constituency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Districts>()
                .HasMany(e => e.Communities)
                .WithRequired(e => e.Districts)
                .HasForeignKey(e => e.District_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Election_Parties>()
                .HasMany(e => e.Vote_Data)
                .WithRequired(e => e.Election_Parties)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elections>()
                .HasMany(e => e.Election_Parties)
                .WithRequired(e => e.Elections)
                .HasForeignKey(e => e.Election_Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elections>()
                .HasMany(e => e.Electorial_Register)
                .WithRequired(e => e.Elections)
                .HasForeignKey(e => e.ElectionCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Parties>()
                .HasOptional(e => e.Election_Parties)
                .WithRequired(e => e.Parties);

            modelBuilder.Entity<Provinces>()
                .HasMany(e => e.Constituencies)
                .WithRequired(e => e.Provinces)
                .HasForeignKey(e => e.ProvinceCode)
                .WillCascadeOnDelete(false);
        }
    }
}
