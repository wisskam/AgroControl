using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using AgroControl.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AgroControl.DBContexts
{
    public class GospodarstwoContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Gospodarstwo> Gospodarstwo { get; set; }
        public DbSet<ObiektGospodarczy> ObiektyGospodarcze { get; set; }
        public DbSet<EventRejestrTransportu> EventsRejestrTransportu { get; set; }
        public DbSet<EventRejestrWejscWyjsc> EventsRejestrWejscWyjsc { get; set; }
        public DbSet<EventSpisZwierzat> EventsSpisZwierzat { get; set; }
        public DbSet<EventDezynfekcja> EventsDezynfekcja { get; set; }
        public DbSet<EventPrzegladZabezpieczen> EventsPrzegladZabezpieczen { get; set; }

        public GospodarstwoContext(DbContextOptions<GospodarstwoContext> options)
            : base(options) { }
        public GospodarstwoContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gospodarstwo>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nazwa).IsRequired();
                entity.Property(e => e.Wlasciciel).IsRequired();
            });

            modelBuilder.Entity<ObiektGospodarczy>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Nazwa).IsRequired();
                //entity.Property(e => e.GospodarstwoID).IsRequired();
            });

            modelBuilder.Entity<EventRejestrTransportu>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.EventType).IsRequired();
                entity.Property(e => e.GospodarstwoID).IsRequired();

                entity.Property(e => e.CelWjazdu).IsRequired();
                entity.Property(e => e.DataIGodzinaWjazdu).IsRequired();
                entity.Property(e => e.NazwaLubNrRejestracji).IsRequired();
                entity.Property(e => e.OstatniPobytPojazdu).IsRequired();
            });

            modelBuilder.Entity<EventRejestrWejscWyjsc>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.EventType).IsRequired();
                entity.Property(e => e.GospodarstwoID).IsRequired();

                entity.Property(e => e.DataIGodzinaWejścia).IsRequired();
                entity.Property(e => e.NazwaOsobyWchodzacej).IsRequired();
                entity.Property(e => e.NazwaFirmy).IsRequired();
                entity.Property(e => e.CelWejscia).IsRequired();
                entity.Property(e => e.NazwaNumerBudynku).IsRequired();
                entity.Property(e => e.DataOstatniegoPobytu).IsRequired();
                entity.Property(e => e.MiejsceOstatniegoPobytu).IsRequired();
                entity.Property(e => e.CzyZastosowanoOchrone).IsRequired();
            });


            modelBuilder.Entity<EventSpisZwierzat>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.EventType).IsRequired();
                entity.Property(e => e.GospodarstwoID).IsRequired();

            });

            modelBuilder.Entity<EventDezynfekcja>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.EventType).IsRequired();
                entity.Property(e => e.GospodarstwoID).IsRequired();

            });

            modelBuilder.Entity<EventPrzegladZabezpieczen>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.EventType).IsRequired();
                entity.Property(e => e.GospodarstwoID).IsRequired();

            });
        }

        //public DbSet<AgroControl.Models.EventRejestrTransportu> EventRejestrTransportu { get; set; }

        //public DbSet<AgroControl.Models.EventRejestrWejscWyjsc> EventRejestrWejscWyjsc { get; set; }
    }
}