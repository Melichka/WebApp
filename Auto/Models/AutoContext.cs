using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Auto.Models
{
    public partial class AutoContext : DbContext
    {
        #region Constructor
        public AutoContext(DbContextOptions<AutoContext>options)
            : base(options)
        { }
        #endregion
        public virtual DbSet<Auto> Auto { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Incident> Incident { get; set; }
        public virtual DbSet<IncidentStatus> IncidentStatu { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<Insuranceagent> Insuranceagent { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<InsuranceType> InsuranceType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.Property(e => e.NumberAuto).IsRequired();
            });
            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.HasOne(d => d.Auto)
                .WithMany(p => p.Insurance)
                .HasForeignKey(d => d.AutoId);
            });
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Insurance)
                .WithMany(p => p.Payment)
                .HasForeignKey(d => d.InsuranceId);
            });
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.HasOne(d => d.Insurance)
                .WithMany(p => p.Incident)
                .HasForeignKey(d => d.InsuranceId);
            });
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.HasOne(d => d.IncidentStatus)
                .WithMany(p => p.Incident)
                .HasForeignKey(d => d.StatusId);
            });
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.HasOne(d => d.Insuranceagent)
                .WithMany(p => p.Incident)
                .HasForeignKey(d => d.InsuranceAgentId);
            });
            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.HasOne(d => d.InsuranceType)
                .WithMany(p => p.Insurance)
                .HasForeignKey(d => d.TypeId);
            });
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.HasOne(d => d.Client)
                .WithMany(p => p.Auto)
                .HasForeignKey(d => d.ClientId);
            });


        }
    }
}
